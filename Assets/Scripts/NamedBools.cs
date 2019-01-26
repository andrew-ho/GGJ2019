using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NamedBools
{
    public string doorName;
    [SerializeField]
    public bool renderDoor;
    [SerializeField]
    public bool trigger;
}
