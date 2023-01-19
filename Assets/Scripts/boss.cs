using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class boss : MonoBehaviour
{
    public Animator animator;

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

    float linetimer = 4;
    public float movetimer;
    public float move;
    public float logtimer = 1.5f;
    float logtimer2;
    float jumptimer = 3;
    public float jumpforce;
    public float logtossf = 0;
    public float landingf = 0;
    float loganimtimer;
    Rigidbody2D rb;

   
    void Start()
    {
        sprender = gameObject.GetComponent<SpriteRenderer>();
        //sprender.enabled = false;
        jumpdmg = FindObjectOfType<jumpdmg>();
        player = FindObjectOfType<healthPlayer>();
        rb = GetComponent<Rigidbody2D>();
        bosshealth = FindObjectOfType<bosshealth>();
        movetimer = 4;
        move = 21;
    }

    void Update()
    {
        #region animation
        if (jumpdmg.landingj==1)
        {
            landingf = 1;
        }
        if (jumpdmg.landingj==0)
        {
            landingf = 0;
        }
        animator.SetFloat("logtoss", logtossf);
        animator.SetFloat("landing", landingf);
        #endregion
        #region lines
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
        #endregion
        if (movetimer<=0)
        {
            move = Random.Range(1, 20);
            movetimer = 4;
            print("move");
        }        
        if (move<=10)
        {
            loganimtimer = 3.5f;
            logtimer -= Time.deltaTime;
            loganimtimer -= Time.deltaTime;
            if (logtimer>-0.5f&&logtimer<1.5f)
            {
                logtossf = 1;
            }
            if (logtimer<-0.5f)
            {
                logtossf = 0;
            }
            if (logtimer<=0)
            {
                Shoot();
                logtimer = 1.5f;
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
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<healthPlayer>().Damaged();

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="bullet")
        {
            bosshealth.currenthealth -= 1;
        }
    }
    void Shoot()
    {
        Instantiate(logprefab, firepoint.position, firepoint.rotation);
        print("shoot");
    }
    void Jump()
    {
        GetComponent<jumpdmg>().jump = true;
        rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
    }
    void bossdeath()
    {
        Destroy(gameObject);
    }
}
