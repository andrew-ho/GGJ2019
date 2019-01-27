using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    public static int SlimesToDie = 0;
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
            Destroy(this.gameObject);
            SlimesToDie -= 1;
        }
        if(health<=DivisionHealth&&Large)
        {
            GameObject slime1 = Object.Instantiate(SubSlime, this.transform.position + new Vector3(0.5f - Random.value, SubSlime.transform.position.y, 0.5f - Random.value), Quaternion.identity);
            GameObject slime2 = Object.Instantiate(SubSlime, this.transform.position + new Vector3(0.5f - Random.value, SubSlime.transform.position.y, 0.5f - Random.value), Quaternion.identity);
            slime1.SetActive(true);
            slime2.SetActive(true);
            slime1.GetComponent<Slime>().chase = true;
            slime2.GetComponent<Slime>().chase = true;
            SlimesToDie += 1;
            Destroy(this.gameObject);
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
    void OnTriggerEnter(Collider collider)
    {
        if (LayerMask.LayerToName(collider.gameObject.layer) == "Bullet")
        {
            health -= 1;
            collider.gameObject.SetActive(false);
        }
    }

}
