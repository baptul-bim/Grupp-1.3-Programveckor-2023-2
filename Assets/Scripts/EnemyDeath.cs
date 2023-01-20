using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    //blood splatter
    [SerializeField]
    ParticleSystem bloodParticles;

    public int enemyHealth;

    public int enemyMaxHealth;

    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemyMaxHealth = enemyHealth;
        //Physics2D.IgnoreCollision(enemies[3].GetComponent<Collider2D>(), GetComponent<Collider2D>());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyDamage()
    {
        enemyMaxHealth = enemyHealth;
        enemyHealth -= 1;
        



        if (enemyHealth <= 0)
        {
            Instantiate(bloodParticles, gameObject.transform.position, transform.rotation);
            Debug.Log("jag dog :(");
            Destroy(this.gameObject);
            themometer.currenttemp -= enemyMaxHealth * 2;
        }



    }
}
