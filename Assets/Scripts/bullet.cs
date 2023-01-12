using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float despawn;
   
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        despawn -= Time.deltaTime;
        if (despawn<=0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="enemy")
        {
            Destroy(gameObject);
        }
               
    }

}
