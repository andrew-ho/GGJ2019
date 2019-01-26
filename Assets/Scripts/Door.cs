using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{ 
    public bool doNotRenderDoor;
    public bool moveCamera;
    private Camera cam;
    public GameObject roomView;

    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
        if (doNotRenderDoor)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cam.transform.parent = this.gameObject.transform.parent.transform.parent;
            //moveCamera = true;
            cam.transform.position = roomView.transform.position;
        }
    }

    private void Update()
    {
        if (moveCamera)
        {
            MoveCam();
        }
    }

    public void MoveCam()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, roomView.transform.position, Time.deltaTime);
    }
}
