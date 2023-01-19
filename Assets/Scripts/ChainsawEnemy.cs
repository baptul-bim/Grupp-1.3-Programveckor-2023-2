using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainsawEnemy : MonoBehaviour
{

    public int chainsawHealth = 3;
    //int healthComparison;

    //private Animator animator;

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
            if (searchHit.distance <= 5f && searchHit.transform.tag == ("Player"))
            {
                //här ska den revva upp motorsågen och kanske se arg ut.
                rage = true;
                //this.GameObject.GetComponent<Animator>().Play("chainsaw-charge");
            }

        }
        //rage activated
        else if (searchHit.collider != null && rage == true)
        {
           // this.GameObject.GetComponent<Animator>().Play("chainsaw-run");
            //checks if terrain in front.
            RaycastHit2D groundHit = Physics2D.Raycast(this.gameObject.transform.position, direction);

            if (facingRight == false)
            {
                transform.position -= transform.right * enemySpeed * Time.deltaTime;
            }

            else if (facingRight == true)
            {
                transform.position += transform.right * enemySpeed * Time.deltaTime;
            }

            if (groundHit.distance <= 2.5f && groundHit.transform.tag == ("Ground"))
            {

                if (jumping == false)
                {
                    rb.AddForce(new Vector2(rb.velocity.x, jump));
                    jumping = true;
                }
            }



        }

       /* if (healthComparison != healthChanger.enemyHealth)
        {
            //GameObject.GetComponent<Animator>().Play("chainsaw-charge");
            healthComparison = HealthChanger.enemyHealth;
        }*/

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        RaycastHit2D Grounded = Physics2D.Raycast(this.gameObject.transform.position, direction);
        if (Grounded.collider != null)
        {
            if (collision.gameObject.CompareTag("Ground") && Grounded.distance <= 0.4f && Grounded.transform.tag == ("Ground"))
            {
                jumping = false;
            }
        }
        
    }

    /*private void awake()
    {
        animator = GetComponent<Animator>();
    }*/




}
