using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class intro : MonoBehaviour
{
    public float timer1;
    public float timer2;
    public float timer3;
    [SerializeField]
    TextMeshProUGUI introtext;
    [SerializeField]
    TextMeshProUGUI introtext2;
    [SerializeField]
    TextMeshProUGUI introtext3;
    // Start is called before the first frame update
    void Start()
    {
        timer1 = 15;
        //timer2 = 5;
        //timer3 = 10;
    }

    // Update is called once per frame
    void Update()
    {
        timer1 -= Time.deltaTime;
        //timer2 -= Time.deltaTime;
        //timer3 -= Time.deltaTime;
        if (timer1<14)
        {
            introtext.text = "The humans have taken everything from me";
        }
        else
        {
            introtext.text = "";
        }
        if (timer1<10)
        {
            introtext2.text = "Someone needs to do something about this";
        }
        else
        {
            introtext2.text = "";
        }
        if (timer1<5)
        {
            introtext3.text = "I need to do something about this";
        }
        else
        {
            introtext3.text = "";
        }
    }
}
