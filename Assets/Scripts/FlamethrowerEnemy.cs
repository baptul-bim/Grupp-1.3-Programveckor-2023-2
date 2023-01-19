using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerEnemy : MonoBehaviour
{

    float timer;

    [SerializeField]
    ParticleSystem flameParticles;

    bool flamesActive;


    private ParticleSystem flames;

    public Transform playerTarget;

    [SerializeField]
    float enemySpeed;

    public float playerDistance;
    public Vector2 direction;

    public ParticleSystem Flames { get => flames; set => flames = value; }

    // Start is called before the first frame update
    void Start()
    {
        flamesActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        //-2.4, -1.2

        Vector3 playerPos = playerTarget.position;

        RaycastHit2D flameRay = Physics2D.Raycast(this.gameObject.transform.position, playerPos - transform.position);

        RaycastHit2D flameRay2 = Physics2D.Raycast(this.gameObject.transform.position, direction);

        Debug.DrawRay(this.gameObject.transform.position, playerPos - transform.position);
        Debug.DrawRay(this.gameObject.transform.position, direction, color:Color.green);

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

}
