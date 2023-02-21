using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeEnemy : MonoBehaviour
{
    //Kod av Louie W. Stormdal [SU22b]
    //Kod för 'Axe' fiende

    [SerializeField]
    float enemySpeed;

    bool facingRight;

    public Vector2 direction;

    private Animator animator;

    //blood splatter
    [SerializeField]
    ParticleSystem bloodParticles;

    bool axeattack;

    int facing;

    //axe health
    public int axeHealth = 1;

    private Animation anim;






    // Start is called before the first frame update
    void Start()
    {
        //hälsa och riktning
        facingRight = false;
        EnemyDeath healthChanger = this.GetComponent<EnemyDeath>();
        healthChanger.enemyHealth = axeHealth;
        animator = GetComponent<Animator>();
        animator.Play("Axeman");

    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position, direction);

        //går framåt konstant
        if (facingRight == false)
        {
            transform.position -= transform.right * enemySpeed * Time.deltaTime;
        }
        else if (facingRight == true)
        {
            transform.position += transform.right * enemySpeed * Time.deltaTime;
        }


        if (hit.collider != null)
        {
            //byter riktning när den når en vägg
            if (hit.distance <= 0.16f && hit.transform.tag == ("Ground"))
            {
                Debug.DrawRay(this.gameObject.transform.position, direction);
                Debug.Log("attack haaha");

                Flip();



            }
            //så att den inte knuffar spelaren eller gör skada fler gånger
            else if (hit.distance <= 0.16f && hit.transform.tag == ("Player"))
            {
                enemySpeed = 0;


            }
            //springer snabbare om den "ser" spelaren
            else if (hit.transform.tag == ("Player"))
            {
                enemySpeed = 2;
            }
            else
            {
                enemySpeed = 1;
            }


        }
        else
        {
            enemySpeed = 1;
        }
    }



    void Flip()
    {
        //byter riktning
        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z);
        facingRight = !facingRight;
        direction = direction * (-1);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //skadar spelaren när den rör
        if (collision.gameObject.tag == "Player" && axeattack == false)
        {
            collision.gameObject.GetComponent<healthPlayer>().Damaged();
            StartCoroutine(AttackCoolDown());
            Debug.Log("Attackerar spelare");
             animator.Play("Axeman-Attack");
            //här ska den spela attack-animationen, annars ska den alltid springa

        }

    }


    IEnumerator AttackCoolDown()
    {
        //kan inte döda jättemycket
        axeattack = true;
        enemySpeed = 0;

        yield return new WaitForSecondsRealtime(5);
        axeattack = false;

        enemySpeed = 1;

    }




    
}
