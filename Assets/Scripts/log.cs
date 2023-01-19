using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : MonoBehaviour
{
    boss boss;
    public float speed = 20f;
    public Rigidbody2D rb;

    void Start()
    {
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
            collision.gameObject.GetComponent<healthPlayer>().Damaged();
        }
        if (collision.gameObject.tag == "object")
        {
            Destroy(gameObject);
        }
    }
}
