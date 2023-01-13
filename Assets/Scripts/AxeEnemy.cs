using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeEnemy : MonoBehaviour
{

    [SerializeField]
    float enemySpeed;



    // Start is called before the first frame update
    void Start()
    {
        Ray ray = new Ray(transform.position, transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.right);

        if (Physics2D.Raycast(transform.position, -Vector2.right))
        {
            Debug.DrawRay(transform.position, -Vector2.right, Color.green);
            Debug.Log("goofy attack");

        }

    }
}
