using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chainsawman : MonoBehaviour
{
    [SerializeField]
    Transform cast;
    public Transform player;
    public float speed;
    public float agrorange;
    Rigidbody2D rb;
    public float timer = 2;
    public float distance;
    public bool move = false;
    public bool stun = false;
    float health = 3;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.Rotate(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (move == true)
        {
            timer -= Time.deltaTime;
        }
        if (stun == true)
        {
            distance = 100;
        }
        else
        {
            distance = Vector2.Distance(transform.position, player.position);
            if (distance < agrorange)
            {
                Charge();
                move = true;
            }
            else
            {
                donothing();
            }
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "object" || collision.gameObject.tag == "player")
        {
            stun = true;
            collision.gameObject.GetComponent<healthPlayer>().Damaged();
        }
    }
    void Charge()
    {
        if (transform.position.x > player.position.x)
        {
            if (timer <= 0)
            {
                rb.velocity = transform.right * speed;
            }
        }
    }
    void donothing()
    {
        rb.velocity = new Vector2(0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            health -= 1;
        }
    }
    
}
