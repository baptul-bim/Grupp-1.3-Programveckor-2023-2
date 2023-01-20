using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class FlamethrowerEnemy : MonoBehaviour
{

    float timer;

    [SerializeField]
    ParticleSystem[] flameParticles;

    public GameObject flameHitbox;

    bool flamesActive;


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
    }

    // Update is called once per frame
    void Update()
    {
        //-2.4, -1.2

        Vector3 playerPos = playerTarget.position;

        RaycastHit2D flameRay = Physics2D.Raycast(this.gameObject.transform.position, playerPos - transform.position);

        /*
        RaycastHit2D flameRay1 = Physics2D.Raycast(this.gameObject.transform.position, direction1);
        RaycastHit2D flameRay2 = Physics2D.Raycast(this.gameObject.transform.position, direction2);
        RaycastHit2D flameRay3 = Physics2D.Raycast(this.gameObject.transform.position, direction3);
        */

        Debug.DrawRay(this.gameObject.transform.position, playerPos - transform.position);
        Debug.DrawRay(this.gameObject.transform.position, direction1, color: Color.green);
        Debug.DrawRay(this.gameObject.transform.position, direction2, color: Color.green);
        Debug.DrawRay(this.gameObject.transform.position, direction3, color: Color.green);

        if (flameRay.collider != null/* || flameRay2.collider != null || flameRay3.collider != null*/)
        {
            if (flameRay.distance <= 6f && flameRay.transform.tag == ("Player") && flamesActive == false)
            {
                Debug.Log(flameRay.transform.tag);
                StartCoroutine(AttackDuration());
            }
                
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
        yield return new WaitForSeconds(2.5f);
        flameHitbox.gameObject.SetActive(true);
        

        yield return new WaitForSeconds(5);
        flameHitbox.gameObject.SetActive(false);
        flamesActive = false;


    }
}
