using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

//Albin
public class boss : MonoBehaviour
{
    public Animator animator;//animator

    public Transform firepoint;//där stockarna spawnar
    public GameObject logprefab;//stock som ska spawnas
    bosshealth bosshealth;//referera till bosshealth
    healthPlayer phealth;//referera till healthPlayer

    [SerializeField]
    TextMeshProUGUI startline;//det bossen säger i början
    [SerializeField]
    TextMeshProUGUI playerdeathline;//det bossen säger när spelaren dör
    [SerializeField]
    TextMeshProUGUI bossdeathline;//det bossen säger när bossen dör
    public SpriteRenderer sprender;//rendera bossens sprite

    public float linetimer = 4;//sekunder som bossen säger första meningen
    public float movetimer;//timer på att bossen inte ska attackera i början
    public float move;//bestämmer vilken attack
    public float jumpforce;//kraft för att hoppa
    bool bossdeath = false;//om bossen är död eller inte
    public bool bubbla = false;//om pratbubblan finns eller inte
    Rigidbody2D rb;//kalla rigidbodyn


    void Start()
    {
        animator = GetComponent<Animator>();//kalla animator
        sprender = gameObject.GetComponent<SpriteRenderer>();//kalla spriterendere
        phealth = FindObjectOfType<healthPlayer>();//hitta healthPlayer
        rb = GetComponent<Rigidbody2D>();//kalla rigidbody
        bosshealth = FindObjectOfType<bosshealth>();//hitta bosshealth
        movetimer = 4; //för att den ska ha tid att prata innan den attackerar
        move = 21; //för att den inte ska göra någon attack
    }

    void Update()
    {
        #region lines
        linetimer -= Time.deltaTime;
        if (linetimer>0) //de första 4sekundrarna pratar bossen
        {
            startline.text = "DiE mOnKey, you will never win hihihaha";
        }
        else
        {
            startline.text = "";
        }
        if (phealth.health<=0) // om spelaren dör pratar bossen
        {
            playerdeathline.text = "forwarder 750f will always win";
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
        bossdeathline.text = "fuck i said i would never let a monkey kill me";
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
