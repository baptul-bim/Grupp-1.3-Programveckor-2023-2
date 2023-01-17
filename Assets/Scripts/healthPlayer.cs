using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthPlayer : MonoBehaviour
{
    public Image healthBar;

    public float health;
    public float maxHealth;

    float lerpSpeed;

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

        lerpSpeed = 3.5f * Time.deltaTime;

        HealthBarFiller();
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = health / maxHealth;
    }

    public void Damaged(/*float damagePoints*/)
    {
        if (health > 0)
        {
            health -= 1;
        }
    }
}
