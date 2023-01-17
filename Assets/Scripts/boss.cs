using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class boss : MonoBehaviour
{
    public Transform firepoint;
    public GameObject logprefab;
    public bosshealth bosshealth;
    healthPlayer player;

    [SerializeField]
    TextMeshProUGUI bossname;
    [SerializeField]
    TextMeshProUGUI startline;
    [SerializeField]
    TextMeshProUGUI playerdeathline;
    [SerializeField]
    TextMeshProUGUI bossdeathline;

    public float linetimer = 4;
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
        player = FindObjectOfType<healthPlayer>();
        rb = GetComponent<Rigidbody2D>();
        currentbosshealth = maxbosshealth;
        bosshealth.SetMaxHealth(maxbosshealth);
        movetimer = 4;
        move = 21;
    }

    void Update()
    {
        linetimer -= Time.deltaTime;
        movetimer -= Time.deltaTime;
        if (linetimer>0)
        {
            startline.text = "Hesitation is defeat, Monke";
        }
        else
        {
            startline.text = "";
        }
        if (player.health<=0)
        {
            playerdeathline.text = "Put these foolish ambitions to rest";
        }
        else
        {
            playerdeathline.text = "";
        }
        bossname.text = "xXMONKE SLAYERXx";
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
            bossdeathline.text = "Brave Monke, Thy strength befits a crown";
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
