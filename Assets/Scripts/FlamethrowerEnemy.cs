using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerEnemy : MonoBehaviour
{

    float timer;

    [SerializeField]
    ParticleSystem flameParticles;

    bool flamesActive;

    public GameObject player1;
    public Transform target;
    public ParticleSystem flames;

    [SerializeField]
    float enemySpeed;

    public float playerDistance;

    // Start is called before the first frame update
    void Start()
    {
        flamesActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the player is close enough to fire
        if (Vector3.Distance(target.position, transform.position) > 5f)
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
                flames.Play();



            }

        }


    }

}
