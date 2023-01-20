using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ChainsawEnemy : MonoBehaviour
{

    public int chainsawHealth = 3;
    int healthComparison;

    private Animator animator;

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
        animator = GetComponent<Animator>();
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
            if (searchHit.distance <= 2f && searchHit.transform.tag == ("Player"))
            {
                //här ska den revva upp motorsågen och kanske se arg ut.
                Charge();
                animator.Play("chainsaw-charge");

            }

        }
        //rage activated
        if (rage == true)
        {
            Vector3 enemyPos = transform.position;
            enemyPos.y -= 0.2f;
            RaycastHit2D groundHit = Physics2D.Raycast(enemyPos, direction);
            Debug.DrawRay(enemyPos, direction, Color.green);
            timer += Time.deltaTime;

            transform.position -= transform.right * enemySpeed * Time.deltaTime;




            if (timer >= 3)
            {
                enemySpeed = 0;
                Flip();
                Charge();
                timer = 0;
            }
            animator.Play("Chainsaw-run");

            //this.GameObject.GetComponent<Animator>().Play("chainsaw-run");
            //checks if terrain in front.



            

            if (groundHit.distance <= 0.7f && groundHit.transform.tag == ("Ground")&&jumping==false)
            {

                Jump();
            }



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
        if (collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<healthPlayer>().Damaged();
        }

    }

    /*private void awake()
    {
        animator = GetComponent<Animator>();
    }*/

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
    {
        enemySpeed = 0;
        rage = rage;
        yield return new WaitForSeconds(1);
        enemySpeed = 3;
        rage = true;
    }

    /*IEnumerator Rage()
    {
       

        Charge();

        facingRight =! facingRight;
    }*/




}
