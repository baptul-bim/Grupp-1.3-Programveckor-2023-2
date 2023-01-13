using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public bool facer;
    public bool facel; 
    //private SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        //sp = GetComponent<SpriteRenderer>();
        facer = true;
        facel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)&&facer==false)
        {
            Flip();
            facer = true;
            facel = false;
        }
        if (Input.GetKeyDown(KeyCode.A) &&facel==false)
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
