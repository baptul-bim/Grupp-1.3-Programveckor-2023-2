using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banan : MonoBehaviour
{
    public Animator animator;
    healthPlayer health;
    bool moving1;
    bool moving2;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        health = FindObjectOfType<healthPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving1==true)
        {
            transform.position += new Vector3(0, 0.2f, 0) * Time.deltaTime;
        }
        if (moving1 == false)
        {
            transform.position += new Vector3(0, -0.2f, 0) * Time.deltaTime;
        }
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
        moving1 = true;
    }
    void up2()
    {

    }
    void dn2()
    {

    }
    void dn1()
    {
        moving1 = false;
    }
}
