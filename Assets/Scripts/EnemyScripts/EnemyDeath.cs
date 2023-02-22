using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    //Kod av Louie W. Stormdal [SU22b]
    //kontrollerar den varierade hälsan av fiender

    //blood splatter
    [SerializeField]
    ParticleSystem bloodParticles;
    [SerializeField]
    GameObject screamObject;// ljud där sitter det clara

    public int enemyHealth;

    public int enemyMaxHealth;

    public GameObject[] enemies;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();//clara
        enemyMaxHealth = enemyHealth;
        //Physics2D.IgnoreCollision(enemies[3].GetComponent<Collider2D>(), GetComponent<Collider2D>());

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("life", enemyHealth);
    }

    public void EnemyDamage()
    {
        enemyMaxHealth = enemyHealth;
        enemyHealth -= 1;
        



        if (enemyHealth <= 0)
        {
            Instantiate(bloodParticles, gameObject.transform.position, transform.rotation);
            Debug.Log("jag dog :(");
            Instantiate(screamObject);//clara, ljudobjektet spanar 
            Destroy(this.gameObject);
            themometer.currenttemp -= enemyMaxHealth * 2;
            
        }



    }
}
