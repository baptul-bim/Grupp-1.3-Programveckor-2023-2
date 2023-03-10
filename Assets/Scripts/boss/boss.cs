using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

//Albin
public class boss : MonoBehaviour
{
    public Animator animator;//animator

    public Transform firepoint;//d?r stockarna spawnar
    public GameObject logprefab;//stock som ska spawnas
    bosshealth bosshealth;//referera till bosshealth
    healthPlayer phealth;//referera till healthPlayer

    [SerializeField]
    TextMeshProUGUI startline;//det bossen s?ger i b?rjan
    [SerializeField]
    TextMeshProUGUI playerdeathline;//det bossen s?ger n?r spelaren d?r
    [SerializeField]
    TextMeshProUGUI bossdeathline;//det bossen s?ger n?r bossen d?r
    public SpriteRenderer sprender;//rendera bossens sprite

    public float linetimer = 4;//sekunder som bossen s?ger f?rsta meningen
    public float movetimer;//timer p? att bossen inte ska attackera i b?rjan
    public float move;//best?mmer vilken attack
    public float jumpforce;//kraft f?r att hoppa
    bool bossdeath = false;//om bossen ?r d?d eller inte
    public bool bubbla = false;//om pratbubblan finns eller inte
    Rigidbody2D rb;//kalla rigidbodyn


    void Start()
    {
        animator = GetComponent<Animator>();//kalla animator
        sprender = gameObject.GetComponent<SpriteRenderer>();//kalla spriterendere
        phealth = FindObjectOfType<healthPlayer>();//hitta healthPlayer
        rb = GetComponent<Rigidbody2D>();//kalla rigidbody
        bosshealth = FindObjectOfType<bosshealth>();//hitta bosshealth
        movetimer = 4; //f?r att den ska ha tid att prata innan den attackerar
        move = 21; //f?r att den inte ska g?ra n?gon attack
    }

    void Update()
    {
        #region lines
        linetimer -= Time.deltaTime;
        if (linetimer>0) //de f?rsta 4sekundrarna pratar bossen
        {
            startline.text = "DiE mOnKey, you will never win hihihaha";
        }
        else
        {
            startline.text = "";
        }
        if (phealth.health<=0) // om spelaren d?r pratar bossen
        {
            playerdeathline.text = "forwarder 750f will always win";
            move = 21; // s? att den inte ska forts?tta attackera n?r spelaren d?tt
        }
        else
        {
            playerdeathline.text = "";
        }
        #endregion
        animator.SetBool("death", bossdeath == true);//om bossen d?r spelas death animation
        movetimer -= Time.deltaTime;
        if (movetimer>0&&movetimer<0.1)//n?r movetimer ?r slut, g?r en attack
        {
            attack();
        }
        if (move<=10) //50% att den v?ljer denna attack
        {
            animator.SetTrigger("log"); //spela kasta stock animation
        }
        if (move > 10 && move < 21) //50% att den v?ljer denna attack
        {
            animator.SetTrigger("jumping"); //spela hoppanimatione
        }

        if (bosshealth.currenthealth <= 0) //om bossen f?r mindre ?n 1 hp d?r den
        {
            deathanim();
        }
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            phealth.health -= 20; //om spelaren nuddar bossen d?r spelaren
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="bullet")
        {
            bosshealth.currenthealth -= 1; //om bossen tr?ffar en kula f?rvinner ett hp
        }
    }
    void Shoot() //n?r log animationen kommer till en viss punkt h?nder "Shoot()"
    {
        Instantiate(logprefab, firepoint.position, firepoint.rotation); //en stock spawnar framf?r bossen
    }
    void Jump() //n?r jump animationen kommer till en viss punkt h?nder "Jump()"
    {
        GetComponent<jumpdmg>().jump = true; //triggar en bool som tilll?ter spelaren att ta skada fr?n att bossen landar.
        rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse); //bossen lyfter fr?n marken
    }

    void land() //n?r jump animationen kommer till en viss punkt h?nder "land()"
    {
        animator.SetTrigger("landing"); //ifall bossen ?r mitt i animationen s? stannar den
        animator.ResetTrigger("log"); //ifall bossen ?r mitt i animationen s? stannar den
        animator.ResetTrigger("jumping"); //ifall bossen ?r mitt i animationen s? stannar den
    }
    void attack() //n?r n?gon av attack animationerna tar slut h?nder "attack()"
    {
        move = Random.Range(1, 20);//randomizear attacker
    }
    void victoryscreen() //i slutet av bossdeath animationen h?nder "victoryscreen()"
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
        animator.ResetTrigger("log"); //ifall bossen ?r mitt i animationen s? stannar den
        animator.ResetTrigger("jumping"); //ifall bossen ?r mitt i animationen s? stannar den
        animator.ResetTrigger("landing"); //ifall bossen ?r mitt i animationen s? stannar den
    }
}
