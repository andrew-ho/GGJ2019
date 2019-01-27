using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    public static int SlimesToDie = 0;
    public GameObject SubSlime;
    public bool Large;
    private Vector3 startPos;

    public float speed;
    public float startSpeed;
    public int DivisionHealth;
    public int Damage;
    public int NumSlimesOnDeath = 2;
    private int RealNumSlimesOnDeath;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startSpeed = speed;
        RealNumSlimesOnDeath = NumSlimesOnDeath;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (TempControl.fill >= 0.4f && TempControl.fill <= 0.6f)
        {
            RealNumSlimesOnDeath = NumSlimesOnDeath + 2;
        }
        else
        {
            RealNumSlimesOnDeath = NumSlimesOnDeath;
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
            SlimesToDie -= 1;
        }
        if(health<=DivisionHealth&&Large)
        {
            for(int i = 0; i < RealNumSlimesOnDeath; i++)
            {
                GameObject slime1 = Object.Instantiate(SubSlime, this.transform.position + new Vector3(4*Random.value-2.0f, SubSlime.transform.position.y, 4*Random.value-2.0f), Quaternion.identity);
                slime1.SetActive(true);
                slime1.GetComponent<Slime>().chase = true;
                SlimesToDie += 1;
            }
            SlimesToDie -= 1;
            Destroy(this.gameObject);
        }
        

        if (chase)
        {
            transform.LookAt(DataManager.Instance.Player.transform.position);
            Vector3 EnemyPosition = this.transform.position;
            Vector3 position = DataManager.Instance.Player.transform.position;
            Vector2 CartesianPosition = Vector2.Lerp(new Vector2(EnemyPosition.x, EnemyPosition.z), new Vector2(position.x, position.z), Time.deltaTime * speed * (Random.value+0.2f));
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
