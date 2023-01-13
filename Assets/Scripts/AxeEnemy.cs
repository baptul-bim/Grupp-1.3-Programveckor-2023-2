using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeEnemy : MonoBehaviour
{

    [SerializeField]
    float enemySpeed;

    public Vector2 direction;



    // Start is called before the first frame update
    void Start()
    {
        Ray ray = new Ray(transform.position, transform.right);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position, direction);

        if (hit.collider != null)
        {
            if (hit.distance <= 1f && hit.transform.tag == ("Player"))
            {
                Debug.DrawRay(this.gameObject.transform.position, direction);
                Debug.Log("attack haaha");

            }
        }
    }
}
