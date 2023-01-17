using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class intro : MonoBehaviour
{
    float timer1;
    float timer2;
    float timer3;
    [SerializeField]
    TextMeshProUGUI introtext;
    [SerializeField]
    TextMeshProUGUI introtext2;
    [SerializeField]
    TextMeshProUGUI introtext3;
    // Start is called before the first frame update
    void Start()
    {
        timer1 = 1;
        timer2 = 5;
        timer3 = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer1<=0)
        {
            introtext.text = "dhskjfhjsdhfgsjhdfsdfd";
        }
        if (timer2<=0)
        {
            introtext2.text = "asfjbsdjfhgsdjhvjdsvv";
        }
        if (timer3<=0)
        {
            introtext3.text = "kfdshfjdfhjdf";
        }
    }
}
