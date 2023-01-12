using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class temp : MonoBehaviour
{
    public float timer;
    public float temperature;

    TextMeshProUGUI celsius;
    
    void Start()
    {
        celsius = FindObjectOfType<TextMeshProUGUI>();
    }

    
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer<=0)
        {
            temperature += 1;
            timer = 15;
        }
        celsius.text = temperature + "°C";
    }
}
