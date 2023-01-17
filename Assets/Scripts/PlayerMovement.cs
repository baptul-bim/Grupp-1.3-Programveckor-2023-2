using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    public Animator animator;

    public float moveSpeed = 5;
    public float jump;
    public float jumping;

    
    private Rigidbody2D rb;
    private bool isJumping;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> 
    {
    
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horz = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(horz));
        transform.position += Vector3.right * horz * moveSpeed * Time.deltaTime;


        if (Input.GetButton("MoveR") == true)
        {
           
        }
        if (Input.GetButton("MoveL") == true)
        {
           // transform.position += Vector3.left * moveSpeed * Time.deltaTime;
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
           animator.SetBool("isjumping", true);
        }
    }

     public void OnLanding() 
      {
     animator.SetBool("isjumping", false);
      }
     

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
