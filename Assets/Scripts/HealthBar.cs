using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image image;
    public float fill;

    Movement player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        fill = player.characterHealth / 50f;
        image.fillAmount = fill;
    }
}
