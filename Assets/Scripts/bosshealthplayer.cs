using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bosshealthplayer : MonoBehaviour
{
    public Image healthBar;
    public Animator animator;
    gun gun;

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

        if (health <= 0 && !isDead)
        {
            isDead = true;
            gameManager.gameOver();
            Debug.Log("Dead");
        }

        if (health <= 0)
        {
            testmov.moveSpeed = 0;
            testmov.jumpforce = 0;
            gun.cooldown = 999;
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
}
