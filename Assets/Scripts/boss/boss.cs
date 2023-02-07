using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

//Albin
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

    public float linetimer = 4;
    public float movetimer;
    public float move;
    public float jumpforce;
    bool bossdeath = false;
    public bool bubbla = false;
    Rigidbody2D rb;


    void Start()
    {
        animator = GetComponent<Animator>();
        sprender = gameObject.GetComponent<SpriteRenderer>();
        phealth = FindObjectOfType<healthPlayer>();
        rb = GetComponent<Rigidbody2D>();
        bosshealth = FindObjectOfType<bosshealth>();
        movetimer = 4; //för att den ska ha tid att prata innan den attackerar
        move = 21; //för att den inte ska göra någon attack
    }

    void Update()
    {
        #region lines
        linetimer -= Time.deltaTime;
        if (linetimer>0) //de första 4sekundrarna pratar bossen
        {
            startline.text = "Hesitation is defeat, Monke";
        }
        else
        {
            startline.text = "";
        }
        if (phealth.health<=0) // om spelaren dör pratar bossen
        {
            playerdeathline.text = "Put these foolish ambitions to rest";
            move = 21; // så att den inte ska fortsätta attackera när spelaren dött
        }
        else
        {
            playerdeathline.text = "";
        }
        #endregion
        animator.SetBool("death", bossdeath == true);//om bossen dör spelas death animation
        movetimer -= Time.deltaTime;
        if (movetimer>0&&movetimer<0.1)
        {
            attack();
        }
        if (move<=10) //50% att den väljer denna attack
        {
            animator.SetTrigger("log"); //spela kasta stock animation
        }
        if (move > 10 && move < 21) //50% att den väljer denna attack
        {
            animator.SetTrigger("jumping"); //spela hoppanimatione
        }

        if (bosshealth.currenthealth <= 0) //om bossen får mindre än 1 hp dör den
        {
            deathanim();
        }
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            phealth.health -= 10; //om spelaren nuddar bossen dör spelaren
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="bullet")
        {
            bosshealth.currenthealth -= 1; //om bossen träffar en kula förvinner ett hp
        }
    }
    void Shoot() //när log animationen kommer till en viss punkt händer "Shoot()"
    {
        Instantiate(logprefab, firepoint.position, firepoint.rotation); //en stock spawnar framför bossen
    }
    void Jump() //när jump animationen kommer till en viss punkt händer "Jump()"
    {
        GetComponent<jumpdmg>().jump = true; //triggar en bool som tilllåter spelaren att ta skada från att bossen landar.
        rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse); //bossen lyfter från marken
    }

    void land() //när jump animationen kommer till en viss punkt händer "land()"
    {
        animator.SetTrigger("landing"); //ifall bossen är mitt i animationen så stannar den
        animator.ResetTrigger("log"); //ifall bossen är mitt i animationen så stannar den
        animator.ResetTrigger("jumping"); //ifall bossen är mitt i animationen så stannar den
    }
    void attack() //när någon av attack animationerna tar slut händer "attack()"
    {
        move = Random.Range(1, 20);//randomizear attacker
    }
    void victoryscreen() //i slutet av bossdeath animationen händer "victoryscreen()"
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //laddar victory scenen
    }
    void deathline()
    {
        bossdeathline.text = "Brave Monke, Thy strength befits a crown";
        bubbla = true;
    }
    void deathanim()
    {
        bossdeath = true;
        animator.ResetTrigger("log"); //ifall bossen är mitt i animationen så stannar den
        animator.ResetTrigger("jumping"); //ifall bossen är mitt i animationen så stannar den
        animator.ResetTrigger("landing"); //ifall bossen är mitt i animationen så stannar den
    }
}
