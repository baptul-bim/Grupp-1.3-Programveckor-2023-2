using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainsawEnemy : MonoBehaviour
{


    [SerializeField]
    float enemySpeed;

    public Transform playerTarget;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(transform.position, playerTarget.transform.position - transform.position);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
    
}
