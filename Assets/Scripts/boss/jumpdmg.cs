using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Albin
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
        
    }


    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (jump == true)
        {
            if (collision.gameObject.tag == "dmgtrigger1") //om bossen nuddar taket
            {
                dmgtrigger1 = true;
            }
            if (collision.gameObject.tag == "Ground"&&dmgtrigger1==true) //om bossen nuddar marken efter att ha nuddat taket
            {
                dmgtrigger2 = true;
            }
            if (dmgtrigger1 == true && dmgtrigger2 == true) //om den har gjort båda
            {
                if (player.jumping == 0) //om spelar inte hoppar
                {
                    phealth.Damaged(); //ta skada för att trigga damage animationen
                    phealth.health -= 3; //ta ytterligare 3 skada
                    dmgtrigger1 = false; //sätt till false igen
                    dmgtrigger2 = false; //sätt till false igen
                    jump = false; //sätt till false igen
                }
                else if(player.jumping == 1) //om spelaren hoppar
                {
                    dmgtrigger1 = false; //sätt till false igen
                    dmgtrigger2 = false; //sätt till false igen
                    jump = false; //sätt till false igen
                }
            }
        }
        
    }
}
