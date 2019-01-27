using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomTrigger : MonoBehaviour
{
    public UnityEvent EnterEvent;
    public UnityEvent ExitEvent;
    public Enemy[] enemies;
    int numEnemies;
    private bool active;
    private bool FirstCheck=true;
    private Camera cam;
    public GameObject roomView;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            int count = 0;
            for (int i = 0; i < enemies.Length; i++)
            {
                if (FirstCheck)
                {
                    if (enemies[i].gameObject.GetComponent<Slime>() != false)
                    {
                        Slime.SlimesToDie += 1;
                    }
                    FirstCheck = false;
                }
                if (enemies[i] != null)
                {
                    count++;
                }
            }
            Debug.Log(Slime.SlimesToDie);
            if (count == 0&&Slime.SlimesToDie==0)
            {
                ExitEvent.Invoke();
            }
            numEnemies = count;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Enter();
        }


    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.type == Enemy.EnemyType.CHASING)
                {
                    enemy.chase = false;
                }
                else if (enemy.type == Enemy.EnemyType.STATIONARY)
                {
                    enemy.shoot = false;
                }
            }
        }
    }

    private void Enter()
    {
        EnterEvent.Invoke();
        cam.transform.parent = this.gameObject.transform.parent.transform.parent;
        cam.transform.position = roomView.transform.position;
        foreach (Enemy enemy in enemies)
        {
            if (enemy.type == Enemy.EnemyType.CHASING)
            {
                enemy.chase = true;
            }
            else if (enemy.type == Enemy.EnemyType.STATIONARY)
            {
                enemy.shoot = true;
            }
        }
        active = true;

    }
}
