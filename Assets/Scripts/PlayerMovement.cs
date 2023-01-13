using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public float jump;

    
    private Rigidbody2D rb;
    private bool isJumping;
    private SpriteRenderer sp;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            sp.flipX = false;
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            sp.flipX = true;
        }

        if(Input.GetButton("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
