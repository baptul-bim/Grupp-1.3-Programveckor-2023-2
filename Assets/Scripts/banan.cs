using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banan : MonoBehaviour
{
    public Animator animator;
    healthPlayer health;
    bool idle;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        health = FindObjectOfType<healthPlayer>();
        idle = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            if (health.health<7)
            {
                health.health += 3;
            }
            else
            {
                health.health = 10;
            }
        }
    }
    void up1()
    {

    }
    void up2()
    {

    }
    void dn1()
    {

    }
}
