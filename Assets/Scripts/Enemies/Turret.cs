using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZObjectPools;

public class Turret : Enemy
{
    public GameObject enemyBullets;
    public float shotDelay = 0.3f;

    private EZObjectPool enemyBulletPool;
    private float time = 99f;
    void Awake()
    {
        //Object pool parameters: (object, name of pool, starting pool size, auto resize (should be true), instantiate immediate (should be true), shared pools)
        enemyBulletPool = EZObjectPool.CreateObjectPool(enemyBullets, "EnemyBullets", 300, true, true, true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (TempControl.fill == 0)
        {
            shotDelay = .6f;
        }
        else if (TempControl.fill == 1)
        {
            shotDelay = .05f;
        }
        else
        {
            shotDelay = .3f;
        }
        if (shoot && time > shotDelay)
        {
            Shoot();
            time = 0;
        }

        time += Time.deltaTime;
    }
    void Shoot()
    {
        Transform target = DataManager.Instance.Player.transform;
        Vector3 targetPostition = new Vector3(target.position.x,
                                       transform.position.y,
                                       target.position.z);
        this.transform.GetChild(1).LookAt(targetPostition);
        enemyBulletPool.TryGetNextObject(transform.GetChild(1).position + (3.0f * transform.GetChild(1).forward), transform.GetChild(1).rotation);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (LayerMask.LayerToName(collision.collider.gameObject.layer) == "Bullet")
        {
            if (TempControl.fill > 0 && TempControl.fill < 1)
            {
                health -= 1;
                collision.collider.gameObject.SetActive(false);
            }
            else if (TempControl.fill == 0)
            {
                health -= .5f;
                collision.collider.gameObject.SetActive(false);
            }
            else if (TempControl.fill == 1)
            {
                health -= 2f;
                collision.collider.gameObject.SetActive(false);
            }
        }

    }
}
