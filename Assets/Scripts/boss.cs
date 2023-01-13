using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class boss : MonoBehaviour
{
    public Slider slider;
    logfirepoint logfirepoint;
    jumpdmg jumpdmg;

    public float jumpforce;
    Rigidbody2D rb;
    //public float movetimer
    public float move;
    public float bosshealth;

   
    void Start()
    {
        logfirepoint = FindObjectOfType<logfirepoint>();
        jumpdmg = FindObjectOfType<jumpdmg>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        //movetimer -= Time.deltaTime;
        //if (movetimer<=0)
        {
            //movetimer = 3;
        }
        
        

        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void Shoot()
    {
        logfirepoint.shoot = true;
    }
    void Jump()
    {
        jumpdmg.jump = true;
        rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="bullet")
        {
            bosshealth -= 0.25f;
        }
    }

}
