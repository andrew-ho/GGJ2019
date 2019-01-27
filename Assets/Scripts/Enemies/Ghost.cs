using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{

    public float speed;
    public float startSpeed;
    // Start is called before the first frame update
    void Start()
    {
        startSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (Timer.timer == 0)
        {
            if (TempControl.fill == 0)
            {
                speed = startSpeed * 2;
            }
            else if (TempControl.fill < 0.2f)
            {
                speed = startSpeed * 1.5f;
            }
            else if (TempControl.fill < 0.8f)
            {
                speed = startSpeed;
            }
            else if (TempControl.fill < 1)
            {
                speed = startSpeed * 0.75f;
            }
            else
            {
                speed = startSpeed * 0.5f;
            }
            transform.LookAt(DataManager.Instance.Player.transform.position);
            Vector3 EnemyPosition = this.transform.position;
            Vector3 position = DataManager.Instance.Player.transform.position;
            Vector3 CartesianVelocity = speed * Time.deltaTime * transform.forward;

            this.transform.position = new Vector3(transform.position.x+CartesianVelocity.x, EnemyPosition.y, transform.position.z+CartesianVelocity.z);
        }
    }
}
