using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class themometer : MonoBehaviour
{
    private Image thermometer;
    public static float currenttemp = 30f; 
    public float maxtemp = 50f;
    public float temptimer = 2;
    // Start is called before the first frame update
    void Start()
    {
        currenttemp = 15;
        thermometer = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        temptimer -= Time.deltaTime;
        if (temptimer<=0)
        {
            currenttemp += 1;
            temptimer = 2;
        }
        thermometer.fillAmount = currenttemp / maxtemp;
    }
}
