using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EasterEgg : MonoBehaviour
{
    float time;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            text.gameObject.SetActive(true);
        }
    }
}
