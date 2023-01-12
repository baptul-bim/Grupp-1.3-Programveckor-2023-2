using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public float jumpforce;
    Rigidbody2D rb;
    public float movetimer;
    public Transform firepoint;
    public GameObject logprefab;

    bool bigJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bigJump = false;
    }
    void Update()
    {
        movetimer -= Time.deltaTime;
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void Shoot()
    {
        Instantiate(logprefab, firepoint.position, firepoint.rotation);
    }
    void Jump()
    {
        rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        bigJump = true;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == ("dmgtrigger2") && bigJump == true)
        {
            Debug.Log("Collided");
            collision.gameObject.GetComponent<test1>().Smashed();

        }

    }
}
