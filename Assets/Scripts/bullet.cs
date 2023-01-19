using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    bosshealth bosshealth;
    public float speed = 20f;
    public Rigidbody2D rb;
   
   
    void Start()
    {
        bosshealth = FindObjectOfType<bosshealth>();
        rb.velocity = transform.right * speed;      
    }

    private void Update()
    {
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            FindObjectOfType

            collision.gameObject.GetComponents().EnemyDeath();

            Destroy(gameObject);
        }

        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "bullet") 
        {
            Debug.Log(collision.gameObject.tag);
            Destroy(gameObject);
        }
               
    }

}
