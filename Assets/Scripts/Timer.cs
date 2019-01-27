using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static float timer = 0;
    public TextMeshProUGUI text;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, timer);
        text.text = timer.ToString();
    }
}
