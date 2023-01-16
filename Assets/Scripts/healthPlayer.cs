using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthPlayer : MonoBehaviour
{
    public Image healthBar;

    float health, maxHealth = 3;
    float lerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > maxHealth) health = maxHealth;

        HealthBarFiller();

        lerpSpeed = 3f * Time.deltaTime;
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, lerpSpeed);
    }

    public void Damaged(/*float damagePoints*/)
    {
        if (health > 0)
            health -= 1;
    }
}
