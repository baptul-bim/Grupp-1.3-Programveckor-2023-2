using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logfirepoint : MonoBehaviour
{
    public Transform firepoint;
    public GameObject logprefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(logprefab, firepoint.position, firepoint.rotation);
        
    }
}
