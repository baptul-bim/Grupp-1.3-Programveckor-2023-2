using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class jumpdmg : MonoBehaviour
{
    boss boss;
    testmov player;
    healthPlayer phealth;
    public bool jump;
    public bool dmgtrigger1=false;
    public bool dmgtrigger2=false;
    public float t1;
    public float t2;
    // Start is called before the first frame update
    void Start()
    {
        boss = FindObjectOfType<boss>();
        player = FindObjectOfType<testmov>();
        phealth = FindObjectOfType<healthPlayer>();
        jump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dmgtrigger1==false)
        {
            t1 = 0;
        }
        if (dmgtrigger1==true)
        {
            t1 = 1;
        }
        if (dmgtrigger2 == false)
        {
            t2 = 0;
        }
        if (dmgtrigger2 == true)
        {
            t2 = 1;
        }

    }


    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (jump == true)
            print("jump");
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
                if (player.jumping == 0)
                {
                    print("jumpkill");
                    phealth.Damaged();
                    phealth.health -= 3;
                    dmgtrigger1 = false;
                    dmgtrigger2 = false;
                    jump = false;
                }
                else if(player.jumping == 1)
                {
                    print("nojumpdmg");
                    dmgtrigger1 = false;
                    dmgtrigger2 = false;
                    jump = false;
                }
            }
        }
        
    }
}
