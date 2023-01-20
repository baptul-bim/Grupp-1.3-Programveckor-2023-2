using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class themometer : MonoBehaviour
{
    private Image thermometer;
    public static float currenttemp = 30f; 
    public float maxtemp = 50f; 
    // Start is called before the first frame update
    void Start()
    {
        thermometer = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        currenttemp -= Time.deltaTime;
        thermometer.fillAmount = currenttemp / maxtemp;
    }
}
