﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Collider HitBox;
    public int health;
    public bool chase;

    public enum EnemyType
    {
        CHASING,
        STATIONARY
    };

    // Start is called before the first frame update
    void Start()
    {
        HitBox = this.GetComponent<Collider>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (health < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
