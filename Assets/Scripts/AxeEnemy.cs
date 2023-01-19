using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeEnemy : MonoBehaviour
{

    [SerializeField]
    float enemySpeed;

    bool facingRight;

    public Vector2 direction;

    //blood splatter
    [SerializeField]
    ParticleSystem bloodParticles;

    bool axeattack;

    int facing;

    //axe health
    public int axeHealth = 1;

    




    // Start is called before the first frame update
    void Start()
    {
        facingRight = false;
        EnemyDeath healthChanger = this.GetComponent<EnemyDeath>();
        healthChanger.enemyHealth = axeHealth;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position, direction);

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
            if (hit.distance <= 0.5f && hit.transform.tag == ("Ground"))
            {
                Debug.DrawRay(this.gameObject.transform.position, direction);
                Debug.Log("attack haaha");

                Flip();



            }
            else if (hit.distance <= 0.16f && hit.transform.tag == ("Player"))
            {
                enemySpeed = 0;


            }
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
        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z);
        facingRight = !facingRight;
        direction = direction * (-1);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<healthPlayer>().Damaged();
            StartCoroutine(AttackCoolDown());
            Debug.Log("Attackerar spelare");

        }
     
    }


    IEnumerator AttackCoolDown()
    {
        axeattack = true;
        enemySpeed = 0;

        yield return new WaitForSecondsRealtime(5);
        axeattack = false;

        enemySpeed = 1;

    }




    
}
