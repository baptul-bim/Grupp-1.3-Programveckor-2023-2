using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testmov : MonoBehaviour
{
    public Animator animator;

    //raycast direction
    public Vector2 direction;

    public float moveSpeed = 5;
    public float jumpforce;
    public float jump;
    public float jumping;
    private Rigidbody2D rb;
    private bool isJumping;
    public bool isfalling = false;
    bool horizontalMove;
    bool jumpanim;
    bool fallanim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        //raycast ground detection
        RaycastHit2D GroundHit = Physics2D.Raycast(this.gameObject.transform.position, direction);

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Vector3.right * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
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
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            isfalling = false;
        }
    }
}
