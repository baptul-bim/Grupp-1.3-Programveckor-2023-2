using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Albin
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
        rb.velocity = transform.right * speed; //åk fram
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3); //förstör stocken efter 3s
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag=="Player")
        {
            Destroy(gameObject); 
            phealth.Damaged(); //ta skada för att trigga damage animationen
            phealth.health -= 3; //ta ytterligare 3 skada
        }
        if (collision.gameObject.tag == "object")
        {
            Destroy(gameObject);
        }
    }
}
