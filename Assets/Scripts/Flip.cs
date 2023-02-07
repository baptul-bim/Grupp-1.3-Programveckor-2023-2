using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Albin
public class Flip : MonoBehaviour
{
    public bool facer; //förkorting för facing right
    public bool facel; //förkorting för facing left

    // Start is called before the first frame update
    void Start()
    {
        facer = true; //börjar att titta höger
        facel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && facer == false) //om man går åt höger och inte redan tittar åt höger
        {
            Flip(); //vänd håll spelaren tittar
            facer = true;
            facel = false;
        }
        if (Input.GetKeyDown(KeyCode.A) && facel == false) //om man går åt vänster och inte redan tittar åt vänster
        {
            Flip();
            facel = true;
            facer = false;
        }
        void Flip()
        {
            transform.Rotate(0, 180, 0);
        }
        
    }
   
}
