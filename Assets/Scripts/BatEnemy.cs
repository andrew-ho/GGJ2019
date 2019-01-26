using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BatEnemy : Enemy
{
    private Vector3 startPos;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (chase)
        {
            transform.LookAt(DataManager.Instance.Player.transform.position);
            Vector3 EnemyPosition = this.transform.position;
            Vector3 position = DataManager.Instance.Player.transform.position;
            Vector2 CartesianPosition = Vector2.Lerp(new Vector2(EnemyPosition.x, EnemyPosition.z), new Vector2(position.x, position.z), Time.deltaTime*speed);
            this.transform.position = new Vector3(CartesianPosition.x, EnemyPosition.y, CartesianPosition.y);
        }
        else
        {
            Vector3 tempos = Vector3.Lerp(transform.position, startPos, Time.deltaTime);
            this.transform.position = new Vector3(tempos.x,this.transform.position.y,tempos.z);
        }
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
