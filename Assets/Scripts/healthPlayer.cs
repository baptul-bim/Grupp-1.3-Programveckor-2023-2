using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class healthPlayer : MonoBehaviour
{
    public Image healthBar;
    public Animator animator;

    public float health;
    public float maxHealth;

    public bool onFire;

    public gameManagerScript gameManager;

    private bool isDead;

    public ParticleSystem burning;





    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 10;
        health = maxHealth;
        animator = FindObjectOfType<Animator>();
        gameManager = FindObjectOfType<gameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        healthBar.fillAmount = health / maxHealth;

        if(health <= 0 && !isDead)
        {
            isDead = true;
            gameManager.gameOver();
            Debug.Log ("Dead");
        }

        if(health <= 0)
        {
            testmov.moveSpeed = 0;
        }

        if (onFire == true)
        {

            health -= Time.deltaTime / 2;

        }


    }

    public void Damaged(/*float damagePoints*/)
    {
        if (health > 0)
        {
            animator.SetTrigger("damage");
            health -= 1;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Fire")
        {
            health-=Time.deltaTime / 2;
            StartCoroutine(BurnTimer());

        }

    }


    IEnumerator BurnTimer()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Play();

        onFire = true;

        yield return new WaitForSeconds(5);

        onFire = false;
        ps.Stop();

    }

}
