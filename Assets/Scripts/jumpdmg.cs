using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class jumpdmg : MonoBehaviour
{
    boss boss;
    public bool jump;
    bool dmg=false;
    bool dmgtrigger1=false;
    bool dmgtrigger2=false;
    // Start is called before the first frame update
    void Start()
    {
        boss = FindObjectOfType<boss>();
        jump = false;
    }

    // Update is called once per frame
    void Update()
    {

    }


    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (jump==true)
        {
            if (collision.gameObject.tag == "dmgtrigger1")
            {
                dmgtrigger1 = true;
            }
            if (collision.gameObject.tag == "dmgtrigger2")
            {
                if (dmgtrigger1 == true)
                {
                    dmgtrigger2 = true;
                }

            }
            if (dmgtrigger1 == true && dmgtrigger2 == true)
            {
                dmg = true;
            }
            if (dmg == true)
            {
                if (collision.gameObject.tag == "player")
                {
                    print("jumpkill");
                    dmg = false;
                    dmgtrigger1 = false;
                    dmgtrigger2 = false;
                }
                else if (collision.gameObject.tag == "nodmg")
                {
                    print("nodmg");
                    dmg = false;
                    dmgtrigger1 = false;
                    dmgtrigger2 = false;
                }
            }
        }
        
    }
}
