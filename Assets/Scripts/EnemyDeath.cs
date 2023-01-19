using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    //blood splatter
    [SerializeField]
    ParticleSystem bloodParticles;

    public int enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyDamage()
    {

        enemyHealth -= 1;



        if (enemyHealth <= 0)
        {
            Instantiate(bloodParticles, gameObject.transform.position, transform.rotation);
            Debug.Log("jag dog :(");
            Destroy(this.gameObject);
            themometer.currenttemp -= 5;
        }



    }
}
