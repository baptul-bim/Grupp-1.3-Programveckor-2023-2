using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testmov : MonoBehaviour
{
    public Animator animator;

    //raycast direction
    public Vector2 direction;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.A);
        jumpanim = isJumping;
        fallanim = isfalling;
        animator.SetBool("moving", horizontalMove);
        animator.SetBool("jumping", jumpanim);
        animator.SetBool("falling", fallanim);

        MovePlayer();
        Debug.DrawRay(transform.position, Vector2.down * 0.5f, Color.green);

        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            print("hipp");
            Jump();
        }

        //raycast ground detection
        //RaycastHit2D GroundHit = Physics2D.Raycast(this.gameObject.transform.position, direction);

        /*
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Vector3.right * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            isJumping = true;
        }
        if (isJumping == false)
        {
            jumping = 0;
        }
        if (isJumping == true)
        {
            jumping = 1;
        }*/




    }



    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")|| collision.gameObject.CompareTag("enemy"))
        {
            isJumping = false;
            isfalling = false;
        }
    }
    */

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
        var groundCheck = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, mask );
        
        print("groundcheck: " + (groundCheck.collider != null && groundCheck.collider.CompareTag("Ground")));
        return groundCheck.collider != null && groundCheck.collider.CompareTag("Ground");
    }
}
