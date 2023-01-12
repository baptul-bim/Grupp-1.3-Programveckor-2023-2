using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour
{
    [SerializeField]
    bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    public void Smashed()
    {
        if (grounded == true)
        {
            Debug.Log("Damaged");
        }
    }
}
