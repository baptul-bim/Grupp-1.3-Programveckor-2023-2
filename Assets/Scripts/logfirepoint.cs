using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class logfirepoint : MonoBehaviour
{
    boss boss;
    public Transform firepoint;
    public GameObject logprefab;
    public bool shoot;
    // Start is called before the first frame update
    void Start()
    {
        boss = FindObjectOfType<boss>();
        shoot = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (shoot==true)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(logprefab, firepoint.position, firepoint.rotation);
        shoot = false;
    }
    
}
