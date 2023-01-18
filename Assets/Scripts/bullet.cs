using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
   
   
    void Start()
    {
        rb.velocity = transform.right * speed;      
    }

    private void Update()
    {
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "bullet") 
        {
            Debug.Log(collision.gameObject.tag);
            Destroy(gameObject);
        }
               
    }

}
