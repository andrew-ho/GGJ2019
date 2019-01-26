using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class TempControl : MonoBehaviour
{

    public PostProcessProfile postProcess;

    public Image image;
    public static float fill = 0.5f;
    public float Velocity = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.Temperature = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Velocity = -Velocity;
        }
        postProcess.GetSetting<ColorGrading>().temperature.Override(fill*100-50);
        fill += 0.3f*(Velocity - (0.99f * (fill - 0.5f)))*Time.deltaTime;
        fill = Mathf.Clamp(fill, 0, 1);
        image.fillAmount = fill;
        image.color = new Color(Mathf.Lerp(0,1,fill),0,Mathf.Lerp(0,1,1.0f-fill));
        
        
    }
}
