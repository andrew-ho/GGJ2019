﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BatEnemy : Enemy
{
    private Vector3 startPos;
    
    public int speed;
    public int startSpeed;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
        base.Update();
        if (TempControl.fill == 0)
        {
            speed = startSpeed / 2;
        }
        else if (TempControl.fill == 1)
        {
            speed = startSpeed * 2;
        }
        else
        {
            speed = startSpeed;
        }
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
        
         if (LayerMask.LayerToName(collider.gameObject.layer) == "Bullet")
         {
            if (TempControl.fill > 0 && TempControl.fill < 1)
            {
                health -= 1;
                collider.gameObject.SetActive(false);
            }
            else if (TempControl.fill == 0)
            {
                health -= .5f;
                collider.gameObject.SetActive(false);
            }
            else if (TempControl.fill == 1)
            {
                health -= 2f;
                collider.gameObject.SetActive(false);
            }
         }

    }

}
