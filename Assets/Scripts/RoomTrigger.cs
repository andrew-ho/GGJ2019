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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            int count = 0;
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i] != null)
                {
                    count++;
                }
            }
            if (count == 0)
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
                enemy.chase = false;
            }
        }
    }

    private void Enter()
    {
        EnterEvent.Invoke();
        active = true;
        foreach (Enemy enemy in enemies)
        {
            enemy.chase = true;
        }
    }
}
