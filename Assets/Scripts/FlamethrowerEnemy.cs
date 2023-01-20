using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class FlamethrowerEnemy : MonoBehaviour
{

    public int flamethrowerHealth = 3;

    private Animator animator;
    float timer;

    [SerializeField]
    ParticleSystem[] flameParticles;

    public GameObject flameHitbox;

    bool flamesActive;

    bool facingRight;
    public Vector2 direction;


    private ParticleSystem flames;

    public Transform playerTarget;

    [SerializeField]
    float enemySpeed;

    public float playerDistance;
    public Vector2 direction1;
    public Vector2 direction2;
    public Vector2 direction3;

    public ParticleSystem Flames { get => flames; set => flames = value; }

    // Start is called before the first frame update
    void Start()
    {
        flameHitbox.gameObject.SetActive(false);
        flamesActive = false;
        animator = GetComponentInChildren<Animator>();

        EnemyDeath healthChanger = this.GetComponent<EnemyDeath>();
        healthChanger.enemyHealth = flamethrowerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //-2.4, -1.2

        Vector3 playerPos = playerTarget.position;

        RaycastHit2D flameRay = Physics2D.Raycast(this.gameObject.transform.position, playerPos - transform.position);


        Debug.DrawRay(this.gameObject.transform.position, playerPos - transform.position);

        if (flameRay.collider != null)
        {
            if (flameRay.distance <= 6f && flameRay.transform.tag == ("Player") && flamesActive == false)
            {
                Debug.Log(flameRay.transform.tag);
                StartCoroutine(AttackDuration());
            }

           //  animator.Play("flamethrower-standing");

        }



        //Checks if the player is close enough to fire
        /*if (Vector3.Distance(target.position, transform.position) > 5f)
        {

            //Checks if the players position relative to the enemy and moves towards them
            if (target.position.x > transform.position.x)
            {
                transform.position += transform.right * enemySpeed * Time.deltaTime;

            }
            else if (target.position.x < transform.position.x)
            {
                transform.position -= transform.right * enemySpeed * Time.deltaTime;

            }
        }
        else
        {
            timer = timer + Time.deltaTime;
            if (timer >= 1 && flamesActive == false)
            {
                timer = 0;
                flamesActive = true;
                Flames.Play();



            }

        }*/


    }
    IEnumerator AttackDuration()
    {
        flamesActive = true;
        //när den ser dig grej.
       // animator.Play("flamethrower-look!");
        yield return new WaitForSeconds(2.5f);
        flameParticles[1].Play();
        flameParticles[0].Play();
        flameHitbox.gameObject.SetActive(true);
        // animator.Play("flamethrower-attack");
        animator.SetBool("flameattack", true);

        yield return new WaitForSeconds(5);
        flameHitbox.gameObject.SetActive(false);
        flamesActive = false;
        //idle igen.
        // animator.Play("flamethrower-standing");
        animator.SetBool("flameattack", false);

        yield return new WaitForSeconds(1);
        if (playerTarget.position.x < transform.position.x && facingRight == true)
        {
            Flip();
        }
        else if (playerTarget.position.x > transform.position.x && facingRight == false)
        {
            Flip();
        }


    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z);
        facingRight = !facingRight;
        direction = direction * (-1);
    }
}
