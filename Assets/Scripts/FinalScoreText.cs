using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreText : MonoBehaviour
{
    public float timer;
    public TextMeshProUGUI text;
    float time = 0;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        text.text = "Final Time: " + timer.ToString();
    }
}
