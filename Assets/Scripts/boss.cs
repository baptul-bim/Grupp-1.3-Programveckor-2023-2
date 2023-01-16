using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class boss : MonoBehaviour
{
    logfirepoint logfirepoint;
    jumpdmg jumpdmg;
    public bosshealth bosshealth;

    public float jumpforce;
    Rigidbody2D rb;
    public float maxbosshealth = 40;
    public float currentbosshealth;

   
    void Start()
    {
        logfirepoint = FindObjectOfType<logfirepoint>();
        jumpdmg = FindObjectOfType<jumpdmg>();
        rb = GetComponent<Rigidbody2D>();
        currentbosshealth = maxbosshealth;
        bosshealth.SetMaxHealth(maxbosshealth);
    }

    void Update()
    {
        if (currentbosshealth<=0)
        {
            bossdeath();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.F))
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
            TakeDamage(0.25f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<healthPlayer>().Damaged();

        }
    }
    void TakeDamage(float damage)
    {
        currentbosshealth -= damage;
        bosshealth.SetHealth(currentbosshealth);
    }
    void bossdeath()
    {
        Destroy(gameObject);
    }
}
