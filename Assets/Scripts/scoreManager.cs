using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    string temp;

    // Start is called before the first frame update
    void Start()
    {
        temp += themometer.currenttemp;
        scoreText.text = temp + "ºC";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
