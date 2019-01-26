using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Collider HitBox;
    public float health;
    public bool chase;
    public bool shoot;
    public EnemyType type;
    public enum EnemyType
    {
        CHASING,
        STATIONARY
    };
    public enum EnemyWeakness
    {
        ALL,
        HEAT,
        ICE
    };
    public EnemyWeakness weakness;
    // Start is called before the first frame update
    void Start()
    {
        HitBox = this.GetComponent<Collider>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
