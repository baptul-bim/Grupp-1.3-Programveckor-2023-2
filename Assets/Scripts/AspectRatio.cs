using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatio : MonoBehaviour
{
    //Kod av Louie W. Stormdal [SU22b]

    // Start is called before the first frame update
    void Start()
    {
        //vi har en oortodox aspect ratio så det här scriptet bara sätter resolution till det vi har när spelet startar och låter den vara så.s
        Screen.SetResolution(720, 480, true);

    }

}
