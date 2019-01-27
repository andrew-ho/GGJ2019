using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EasterEgg : MonoBehaviour
{
    public float time = 20f;
    public TextMeshProUGUI text;
    public GameObject title;

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            text.gameObject.SetActive(true);
        }

        if (!title.activeSelf) {
            time = 20f;
        }
    }
}
