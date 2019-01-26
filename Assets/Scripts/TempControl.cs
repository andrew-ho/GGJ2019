using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class TempControl : MonoBehaviour
{

    public PostProcessProfile postProcess;

    public Image image;
    public float fill = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        postProcess.GetSetting<ColorGrading>().temperature.Override(fill*100-50);
        if (Input.GetKey(KeyCode.E))
        {
            if (fill < 100)
            {
                fill += .01f;
                fill = Mathf.Clamp(fill , 0, 1);
            }
        }
        image.fillAmount = fill;
        
    }
}
