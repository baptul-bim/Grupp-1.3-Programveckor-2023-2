using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLayers : MonoBehaviour
{
    //Kod av Louie W. Stormdal [SU22b]
    //Styr backgrundens parallaxing-funktioner.

    float length, startpos;
    public float parallaxFactor;
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        //s�tter bakgrundens startposition till apans position.


        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //bakgrundslager f�ljer apan i olika hastighet och teleporterar fram eller bak n�r de �r utanf�r kameran.

        float temp = cam.transform.position.x * (1 - parallaxFactor);
        float distance = cam.transform.position.x * parallaxFactor;

        Vector3 newPosition = new Vector3(startpos + distance, transform.position.y, transform.position.z);
        transform.position = newPosition;

        if (temp > startpos + (length / 2))
        {
            startpos += length;
        }
        else if (temp < startpos - (length / 2))
        {
            startpos -= length;
        }
    }
}
