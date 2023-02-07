using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Albin
public class Flip : MonoBehaviour
{
    public bool facer; //f�rkorting f�r facing right
    public bool facel; //f�rkorting f�r facing left

    // Start is called before the first frame update
    void Start()
    {
        facer = true; //b�rjar att titta h�ger
        facel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && facer == false) //om man g�r �t h�ger och inte redan tittar �t h�ger
        {
            Flip(); //v�nd h�ll spelaren tittar
            facer = true;
            facel = false;
        }
        if (Input.GetKeyDown(KeyCode.A) && facel == false) //om man g�r �t v�nster och inte redan tittar �t v�nster
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
