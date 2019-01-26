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
        enemyBulletPool = EZObjectPool.CreateObjectPool(enemyBullets, "EnemyBullets", 30, true, true, true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shoot && time > shotDelay)
        {
            Shoot();
            time = 0;
        }

        time += Time.deltaTime;
    }
    void Shoot()
    {
        transform.LookAt(DataManager.Instance.Player.transform.position);
        enemyBulletPool.TryGetNextObject(transform.position + (3.0f * transform.forward), transform.rotation);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == 8)
        {
            health -= 1;
            collider.gameObject.SetActive(false);

        }
    }
}
