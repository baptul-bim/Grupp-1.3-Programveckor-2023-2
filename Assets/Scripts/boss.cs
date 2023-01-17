using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class boss : MonoBehaviour
{
    public Transform firepoint;
    public GameObject logprefab;
    public bosshealth bosshealth;

    TextMeshProUGUI bossname;

    public float movetimer;
    public float move;
    public float logtimer = 3;
    public float jumptimer = 3;
    public float jumpforce;
    Rigidbody2D rb;
    float maxbosshealth = 40;
    float currentbosshealth;

   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentbosshealth = maxbosshealth;
        bosshealth.SetMaxHealth(maxbosshealth);
        bossname = FindObjectOfType<TextMeshProUGUI>();
        movetimer = 3;
        move = 21;
    }

    void Update()
    {
        bossname.text = "xXMONKE SLAYERXx";
        movetimer -= Time.deltaTime;
        if (movetimer<=0)
        {
            move = Random.Range(1, 20);
            movetimer = 4;
            print("move");
        }        
        if (move<=10)
        {
            logtimer -= Time.deltaTime;
            if (logtimer<=0)
            {
                Shoot();
                logtimer = 3;
            }
        }
        if (move > 10 && move < 21)
        {
            jumptimer -= Time.deltaTime;
            if (jumptimer<=0)
            {
                Jump();
                jumptimer = 3;
            }
        }
        if (currentbosshealth <= 0)
        {
            bossdeath();
        }
    }
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="bullet")
        {
            TakeDamage(1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<healthPlayer>().Damaged();

        }
    }
    void Shoot()
    {
        Instantiate(logprefab, firepoint.position, firepoint.rotation);
    }
    void Jump()
    {
        GetComponent<jumpdmg>().jump = true;
        rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
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
