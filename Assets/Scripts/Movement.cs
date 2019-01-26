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
        if (Invulnerable)
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

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    private void FixedUpdate()
    {
        //rb.velocity = moveVelocity;
        //Vector3 moveDirection = moveVelocity;
        //moveDirection = moveDirection.normalized;
        moveVelocity *= Time.deltaTime;
        rb.MovePosition(transform.position + moveVelocity);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<BatEnemy>() != null)
        {
            characterHealth -= 5;
            Invulnerable = true;
            StartCoroutine(WaitForIt());
        }
        if (collision.collider.GetComponent<Fire>() != null)
        {
            characterHealth -= 5;
            Destroy(collision.gameObject);
        }
        
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(1.0f);
        Invulnerable = false;
        this.GetComponent<Renderer>().enabled = true;
    }
    public void GameOver()
    {

    }
}
