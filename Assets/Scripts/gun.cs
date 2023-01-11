using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletprefab;
    public float cooldown=3;
    bool canshoot;

    
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown>0)
        {
            canshoot = false;
        }
        if (cooldown<0)
        {
            canshoot = true;
        }
        if (canshoot==true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                cooldown = 1;
            }
        }

        void Shoot()
        {
            Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        }
    }
}
