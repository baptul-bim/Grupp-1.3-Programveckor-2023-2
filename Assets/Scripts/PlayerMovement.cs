using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator animator;

    public float moveSpeed = 5;
    public float jump;
    public float jumping;

    
    private Rigidbody2D rb;
    private bool isJumping;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("speed", );

        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if(Input.GetButton("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            isJumping = true;
        }
        if (isJumping==false)
        {
            jumping = 0;
        }
        if (isJumping==true)
        {
            jumping = 1;
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
