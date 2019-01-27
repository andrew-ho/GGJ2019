using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    public static int SlimesToDie;
    public GameObject SubSlime;
    public bool Large;
    private Vector3 startPos;

    public int speed;
    public int startSpeed;
    public int DivisionHealth;
    public int Damage;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startSpeed = speed;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(this);
            SlimesToDie -= 1;
        }
        if(health<=DivisionHealth&&Large)
        {
            Object.Instantiate(SubSlime, this.transform.position + new Vector3(0.5f - Random.value, SubSlime.transform.position.y, 0.5f - Random.value), Quaternion.identity);
            Object.Instantiate(SubSlime, this.transform.position + new Vector3(0.5f - Random.value, SubSlime.transform.position.y, 0.5f - Random.value), Quaternion.identity);
            SlimesToDie += 1;
            Destroy(this);
        }
        

        if (chase)
        {
            transform.LookAt(DataManager.Instance.Player.transform.position);
            Vector3 EnemyPosition = this.transform.position;
            Vector3 position = DataManager.Instance.Player.transform.position;
            Vector2 CartesianPosition = Vector2.Lerp(new Vector2(EnemyPosition.x, EnemyPosition.z), new Vector2(position.x, position.z), Time.deltaTime * speed);
            this.transform.position = new Vector3(CartesianPosition.x, EnemyPosition.y, CartesianPosition.y);
        }
        else
        {
            Vector3 tempos = Vector3.Lerp(transform.position, startPos, Time.deltaTime);
            this.transform.position = new Vector3(tempos.x, this.transform.position.y, tempos.z);
        }
    }
}
