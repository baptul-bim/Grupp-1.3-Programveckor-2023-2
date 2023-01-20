using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class themometer : MonoBehaviour
{
    private Image thermometer;
    public static float currenttemp = 30f; 
    public float maxtemp = 50f;
    public float temptimer = 1; 
    // Start is called before the first frame update
    void Start()
    {
        thermometer = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        temptimer -= Time.deltaTime;
        thermometer.fillAmount = currenttemp / maxtemp;
        if (temptimer<=0)
        {
            currenttemp += 3;
            temptimer = 1;
        }
    }
}
