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
       
        if (doNotRenderDoor)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    public void Open()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().isTrigger = true;
    }

    public void Close()
    {
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().isTrigger = false;
    }

}
