using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletInitialVelocity = 200f;
    public float despawnTime = 2f;

    private Rigidbody rb;
    private float time = 0;

    // Use this for initialization
    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable() {
        rb.velocity = Vector3.zero;

        Vector3 bulletPosOnScreen = Camera.main.WorldToScreenPoint(transform.position);
        bulletPosOnScreen = new Vector3(bulletPosOnScreen.x, bulletPosOnScreen.y, 0);
        float angle = Vector3.Angle(Input.mousePosition - bulletPosOnScreen, Vector3.right);
        float xForce = Mathf.Cos(Mathf.Deg2Rad * angle);
        float zForce = Mathf.Sin(Mathf.Deg2Rad * angle);
        if (Input.mousePosition.y < bulletPosOnScreen.y) {
            zForce *= -1;
        }
        //rb.AddForce(new Vector3(Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.y) * bulletInitialVelocity, 0, Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.y) * bulletInitialVelocity));
        rb.AddForce(new Vector3(xForce * bulletInitialVelocity, 0, zForce * bulletInitialVelocity));

        time = 0;
    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;
        if (time >= despawnTime) {
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy") {
            other.gameObject.GetComponent<Enemy>().health -= 1;
        }
        print(other.name);
        if (other.name != "EnemyTriggerZone") {
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision other) {
        print(other);
        this.gameObject.SetActive(false);
    }
}