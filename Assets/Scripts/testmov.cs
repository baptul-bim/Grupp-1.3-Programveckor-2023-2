using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testmov : MonoBehaviour
{
    public Animator animator;
    healthPlayer health;

    //raycast direction
    public Vector2 direction;

    public Vector2 boxSize;

    public static float moveSpeed = 3;
    public float jumpforce;
    public float jump;
    public float jumping;
    private Rigidbody2D rb;
    private bool isJumping;
    public bool isfalling = false;
    bool horizontalMove;
    bool jumpanim;
    bool fallanim;

    [SerializeField]
    LayerMask mask;

    private BoxCollider2D boxCollider2d;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 3;
        health = FindObjectOfType<healthPlayer>();

        boxSize = new Vector2(0.4f, 0.48f);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.A);
        animator.SetBool("moving", horizontalMove);
        animator.SetBool("jump", isJumping);

        MovePlayer();
        Debug.DrawRay(transform.position, Vector2.down * 0.5f, Color.green);

        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            print("hipp");
            Jump();
        }
        if (IsGrounded()==false)
        {
            jumping = 1;
            isJumping = true;
        }
        if (IsGrounded()==true)
        {
            jumping = 0;
            isJumping = false;
        }






    }





    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }
    private void Jump()
    {
        rb.velocity = new Vector2(0, jumpforce);
        print("hopp");
    }
    



    private bool IsGrounded()
    {
        var groundCheck = Physics2D.BoxCast(transform.position, boxSize, 0f, Vector2.down, 0.25f, mask );
        
        
        print("groundcheck: " + (groundCheck.collider != null && groundCheck.collider.CompareTag("Ground")));
        return groundCheck.collider != null && groundCheck.collider.CompareTag("Ground");

    }
}
