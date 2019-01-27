using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int characterHealth = 50;

    public float moveSpeed;
    public Rigidbody rb;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;
    private bool Invulnerable = false;


    private float time = 0.0f;
    private bool dashing;



    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.Player = this.gameObject;
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Invulnerable&&!dashing)
        {
            if (this.GetComponent<Renderer>().enabled == true)
            {
                this.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                this.GetComponent<Renderer>().enabled = true;
            }
        }
        if (characterHealth < 1)
        {
            GameOver();
        }
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        if (Input.GetButton("Fire2")&&time<0.0f) {
            time = 1.5f;
            dashing = true;
            WaitForIt(0.5f);
        }
        

        

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        time -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        //rb.velocity = moveVelocity;
        //Vector3 moveDirection = moveVelocity;
        //moveDirection = moveDirection.normalized;
        moveVelocity *= Time.deltaTime;
        if (time > 1.0f)
        {
            this.transform.position += moveVelocity + 50*transform.forward*Time.deltaTime; 
        }
        else
        {
            this.transform.position += moveVelocity;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!Invulnerable)
        {
            if (collision.collider.GetComponent<BatEnemy>() != null)
            {
                characterHealth -= 5;
                Invulnerable = true;
                StartCoroutine(WaitForIt(1.0f));
            }
            if (collision.collider.GetComponent<Fire>() != null)
            {
                characterHealth -= 5;
                Destroy(collision.gameObject);
            }
            if(collision.collider.gameObject.layer == 11)
            {
                characterHealth -= 3;
                Destroy(collision.gameObject);
                Invulnerable = true;
                StartCoroutine(WaitForIt(0.5f));

            }
        }
    }

    IEnumerator WaitForIt(float time)
    {
        yield return new WaitForSeconds(time);
        Invulnerable = false;
        this.GetComponent<Renderer>().enabled = true;
        dashing = false;
    }


    public void GameOver()
    {

    }
}
