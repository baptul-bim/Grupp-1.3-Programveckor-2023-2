using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeEnemy : MonoBehaviour
{
    //Kod av Louie W. Stormdal [SU22b]
    //Kod f�r 'Axe' fiende

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
        //h�lsa och riktning
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

        //g�r fram�t konstant
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
            //byter riktning n�r den n�r en v�gg
            if (hit.distance <= 0.16f && hit.transform.tag == ("Ground"))
            {
                Debug.DrawRay(this.gameObject.transform.position, direction);
                Debug.Log("attack haaha");

                Flip();



            }
            //s� att den inte knuffar spelaren eller g�r skada fler g�nger
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
        //skadar spelaren n�r den r�r
        if (collision.gameObject.tag == "Player" && axeattack == false)
        {
            collision.gameObject.GetComponent<healthPlayer>().Damaged();
            StartCoroutine(AttackCoolDown());
            Debug.Log("Attackerar spelare");
             animator.Play("Axeman-Attack");
            //h�r ska den spela attack-animationen, annars ska den alltid springa

        }

    }


    IEnumerator AttackCoolDown()
    {
        //kan inte d�da j�ttemycket
        axeattack = true;
        enemySpeed = 0;

        yield return new WaitForSecondsRealtime(5);
        axeattack = false;

        enemySpeed = 1;

    }




    
}
