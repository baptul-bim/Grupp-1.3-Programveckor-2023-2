using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ChainsawEnemy : MonoBehaviour
{
    //Kod av Louie W. Stormdal [SU22b]
    //Kod f�r 'Chainsaw' fiende

    public int chainsawHealth = 5;
    int healthComparison;

    [SerializeField]
    GameObject ChainsawsoundObject;//clara, d�r ljudet sitter

    private Animator animator;//clara

    [SerializeField]
    float enemySpeed;
    [SerializeField]
    float jump;
    bool jumping;

    //timer
    float timer;

    public Transform playerTarget;

    public Vector2 direction;

    bool rage;
    bool facingRight;

    private Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rage = false;
        facingRight = false;

        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        EnemyDeath healthChanger = this.GetComponent<EnemyDeath>();
        healthChanger.enemyHealth = chainsawHealth;
        animator = GetComponentInChildren<Animator>();//clara
        //healthComparison = healthChanger.enemyHealth;




    }


    // Update is called once per frame
    void Update()
    {

        Vector3 playerPos = playerTarget.position;



        //searches for player.
        RaycastHit2D searchHit = Physics2D.Raycast(this.gameObject.transform.position, playerPos - transform.position);




        Debug.DrawRay(this.gameObject.transform.position, playerPos - transform.position);

        if (searchHit.collider != null && rage == false)
        {
            print("ser n�got");
            if (searchHit.distance <= 2f && searchHit.transform.tag == ("Player"))
            {
                print("Ska springa");
                //h�r ska den revva upp motors�gen och kanske se arg ut.
                Instantiate(ChainsawsoundObject);//clara, ljud till motors�g
                StartCoroutine(Charge());
               // animator.Play("chainsaw-charge");
               

            }

        }
        //rage activated
        if (rage == true)
        {
            //h�r ska springa attackera animation vara
            Vector3 enemyPos = transform.position;
            enemyPos.y -= 0.2f;

            //checkar om det �r terr�ng framf�r f�r att veta om den ska kl�ttra �ver det.
            RaycastHit2D groundHit = Physics2D.Raycast(enemyPos, direction);
            Debug.DrawRay(enemyPos, direction, Color.green);

            timer += Time.deltaTime;
            animator.Play("chainsaw-run");//clara

            if (facingRight == false)
            {
                transform.position -= transform.right * enemySpeed * Time.deltaTime;
            }
            else if (facingRight == true)
            {
                transform.position += transform.right * enemySpeed * Time.deltaTime;
            }



            if (timer >= 3)
            {
                enemySpeed = 0;
                animator.Play("chainsaw-stop");//clara
                Flip();
                StartCoroutine(Charge());
                timer = 0;
            }
            animator.Play("Chainsaw-run");//clara

            //this.GameObject.GetComponent<Animator>().Play("chainsaw-run");



            

            if (groundHit.distance <= 0.7f && groundHit.transform.tag == ("Ground")&&jumping==false)
            {

                Jump();
            }



        }
        if (rage == true && searchHit.collider != null && searchHit.transform.tag == "Player")
        {
            enemySpeed = 4;
        }

       /* if (healthComparison != healthChanger.enemyHealth)
         {
             animator.Play("chainsaw-charge");
             healthComparison = HealthChanger.enemyHealth;
         }*/

        Vector3 groundRay = transform.position;
        RaycastHit2D Grounded = Physics2D.Raycast(groundRay, new Vector2(0, -0.5f));
        Debug.DrawRay(groundRay, new Vector2(0, -0.5f));
        if (Grounded.collider != null)
        {
            Debug.Log(Grounded.collider.tag);
            if (Grounded.collider.CompareTag("Ground") && Grounded.distance <= 0.4f)
            {

                jumping = false;
            }
        }


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && rage == true)
        {
            collision.gameObject.GetComponent<healthPlayer>().Damaged();
        }

    }



    void Jump()
    {
        rb.AddForce(new Vector2(rb.velocity.x, jump));
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z);
        facingRight = !facingRight;
        direction = direction * (-1);
    }



    IEnumerator Charge()
        //h�r ska charge animation vara.
    {
        // animator.Play("chainsaw-charge"); 
        animator.SetBool("attackchainsaw", true);//clara
        print("b�rjar");
        enemySpeed = 0;
        yield return new WaitForSeconds(1);
        enemySpeed = 3;
        rage = true;
        print("slutar");
    }





}
