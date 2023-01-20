using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class boss : MonoBehaviour
{
    public Animator animator;

    public Transform firepoint;
    public GameObject logprefab;
    bosshealth bosshealth;
    healthPlayer phealth;

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
    public float jumpforce;
    bool bossdeath = false;
    Rigidbody2D rb;


    void Start()
    {
        animator = GetComponent<Animator>();
        sprender = gameObject.GetComponent<SpriteRenderer>();
        //sprender.enabled = false;
        phealth = FindObjectOfType<healthPlayer>();
        rb = GetComponent<Rigidbody2D>();
        bosshealth = FindObjectOfType<bosshealth>();
        movetimer = 4;
        move = 21;
    }

    void Update()
    {
        #region lines
        linetimer -= Time.deltaTime;
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
        if (phealth.health<=0)
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
        animator.SetBool("death", bossdeath == true);
        movetimer -= Time.deltaTime;
        if (movetimer>0&&movetimer<0.1)
        {
            attack();
        }
        if (move<=10)
        {
            animator.SetTrigger("log");
        }
        if (move > 10 && move < 21)
        {
            animator.SetTrigger("jumping");
        }

        if (bosshealth.currenthealth <= 0)
        {
            deathanim();
        }
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            phealth.health -= 10;
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
    }
    void Jump()
    {
        GetComponent<jumpdmg>().jump = true;
        rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
    }

    void land()
    {
        animator.SetTrigger("landing");
        animator.ResetTrigger("log");
        animator.ResetTrigger("jumping");
    }
    void attack()
    {
        move = Random.Range(1, 20);
    }
    void TriggerReset()
    {
        animator.ResetTrigger("log");
        animator.ResetTrigger("jumping");
    }
    void victoryscreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void deathline()
    {
        bossdeathline.text = "Brave Monke, Thy strength befits a crown";
        //sprender.enabled = true;
    }
    void deathanim()
    {
        bossdeath = true;
        animator.ResetTrigger("log");
        animator.ResetTrigger("jumping");
        animator.ResetTrigger("landing");
    }
}
