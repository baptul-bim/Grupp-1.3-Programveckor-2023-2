using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatio : MonoBehaviour
{
    //Kod av Louie W. Stormdal [SU22b]

    // Start is called before the first frame update
    void Start()
    {
        //vi har en oortodox aspect ratio s� det h�r scriptet bara s�tter resolution till det vi har n�r spelet startar och l�ter den vara s�.s
        Screen.SetResolution(720, 480, true);

    }

}
