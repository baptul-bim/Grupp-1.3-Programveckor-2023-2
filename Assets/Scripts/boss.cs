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
    jumpdmg jumpdmg;

    [SerializeField]
    TextMeshProUGUI bossname;
    [SerializeField]
    TextMeshProUGUI startline;
    [SerializeField]
    TextMeshProUGUI playerdeathline;
    [SerializeField]
    TextMeshProUGUI bossdeathline;
    public SpriteRenderer sprender;

    public float linetimer = 4;
    public float movetimer;
    public float move;
    public float logtimer = 3;
    public float jumptimer = 3;
    public float jumpforce;
    Rigidbody2D rb;

   
    void Start()
    {
        sprender = gameObject.GetComponent<SpriteRenderer>();
        //sprender.enabled = false;
        player = FindObjectOfType<healthPlayer>();
        bosshealth = FindObjectOfType<bosshealth>();
        jumpdmg = FindObjectOfType<jumpdmg>();
        rb = GetComponent<Rigidbody2D>();
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
            //sprender.enabled = true;
        }
        else
        {
            startline.text = "";
            //sprender.enabled = false;
        }
        if (player.health<=0)
        {
            playerdeathline.text = "Put these foolish ambitions to rest";
            //sprender.enabled = true;
            movetimer = 1000;
            move = 21;
        }
        else
        {
            playerdeathline.text = "";
            //sprender.enabled = false;
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
        if (bosshealth.currenthealth <= 0)
        {
            bossdeathline.text = "Brave Monke, Thy strength befits a crown";
            //sprender.enabled = true;
            bossdeath();
        }
    }
   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="bullet")
        {
            bosshealth.currenthealth -= 1;
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
        jumpdmg.jump= true;
        rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
    }
    void bossdeath()
    {
        Destroy(gameObject);
    }
}
