using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Albin
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
        if (temptimer<=0) //om timern går ner till 0
        {
            currenttemp += 1; //temperaturen går upp en grad
            temptimer = 1.5f; //starta om timern
        }
        thermometer.fillAmount = currenttemp / maxtemp;
    }
}
