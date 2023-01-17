using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthPlayer : MonoBehaviour
{
    public Image healthBar;

    public float health;
    public float maxHealth;

    public gameManagerScript gameManager;

    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 3;
        health = maxHealth;
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

    }

    public void Damaged(/*float damagePoints*/)
    {
        if (health > 0)
        {
            health -= 1;
        }
    }
}
