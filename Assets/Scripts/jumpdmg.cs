using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class jumpdmg : MonoBehaviour
{
    boss boss;
    testmov player;
    healthPlayer health;
    public bool jump;
    public bool dmgtrigger1=false;
    bool dmgtrigger2=false;
    public float t1;
    public float landingj;
    float landingtimer = 0.01f;
    float landingtimer2 = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        boss = FindObjectOfType<boss>();
        player = FindObjectOfType<testmov>();
        health = FindObjectOfType<healthPlayer>();
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
                landingtimer = 0.01f;
                landingtimer2 = 0.5f;
                landingtimer2 -= Time.deltaTime;
                if (landingtimer2 <= 0)
                {
                    landingj = 0;
                }
                landingtimer -= Time.deltaTime;
                if (landingtimer<=0)
                {
                    landingj = 1;
                }
                if (player.jumping == 0)
                {
                    print("jumpkill");
                    health.Damaged();
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
