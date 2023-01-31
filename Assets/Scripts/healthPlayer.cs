using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class healthPlayer : MonoBehaviour
{
    private Renderer rend;
    public Image healthBar;
    public Animator animator;
    gun gun;
    testmov testmov;

    [SerializeField]
    private Color red = Color.red;
    [SerializeField]
    private Color white = Color.white;

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
        rend = GetComponent<Renderer>();
        testmov = FindObjectOfType<testmov>();
        gun = FindObjectOfType<gun>();
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
            testmov.jumpforce = 0;
            gun.cooldown = 999;
            animator.SetTrigger("death");
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
            health -= 1;
            animator.SetTrigger("damage");
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
    private void Red()
    {
        rend.material.color = red;
    }
    private void White()
    {
        rend.material.color = white;
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
