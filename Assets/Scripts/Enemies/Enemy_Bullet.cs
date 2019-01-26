using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Bullet : MonoBehaviour
{

    public float bulletInitialVelocity = 200f;
    public float despawnTime = 3f;

    private Rigidbody rb;
    private float time = 0;
    private static float _angle = 0;
    private Vector3 center;
    GameObject target;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //target = DataManager.Instance.Player;
    }

    public void OnEnable()
    {
        //center = transform.position;
        BulletPatternNormal();
    }

    void BulletPatternNormal()
    {
        //target = GameObject.Find("Player");
        target = DataManager.Instance.Player;
        //target = GameObject.Find("PlayerCharacter");
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.forward * bulletInitialVelocity);
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= despawnTime)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if (other.tag == "Player")
        {
            
        }
    }
}