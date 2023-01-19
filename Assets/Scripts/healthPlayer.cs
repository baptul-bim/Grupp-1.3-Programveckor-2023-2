using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthPlayer : MonoBehaviour
{
    public Image healthBar;
    public Animator animator;

    public float health;
    public float maxHealth;

    public gameManagerScript gameManager;

    private bool isDead;

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
