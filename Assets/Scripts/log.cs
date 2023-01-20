using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : MonoBehaviour
{
    healthPlayer phealth;
    boss boss;
    public float speed = 20f;
    public Rigidbody2D rb;

    void Start()
    {
        phealth = FindObjectOfType<healthPlayer>();
        boss = FindObjectOfType<boss>();
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3);
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag=="Player")
        {
            print("logkill");
            Destroy(gameObject);
            phealth.health -= 4;
        }
        if (collision.gameObject.tag == "object")
        {
            Destroy(gameObject);
        }
    }
}
