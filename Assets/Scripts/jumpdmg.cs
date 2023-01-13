using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class jumpdmg : MonoBehaviour
{
    boss boss;
    public bool jump;
    bool dmg=false;
    public bool dmgtrigger1=false;
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
                print("t1");
            }
            if (collision.gameObject.tag == "Ground"&&dmgtrigger1==true)
            {
                dmgtrigger2 = true;
                print("t2");
            }
            if (dmgtrigger1 == true && dmgtrigger2 == true)
            {
                dmg = true;
                print("dmg");
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
                else
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
