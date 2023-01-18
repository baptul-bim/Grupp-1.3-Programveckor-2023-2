using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletprefab;
    public float cooldown=1;
    bool canshoot;


    public int bulletsLoaded;


    void Start()
    {
        bulletsLoaded = 2;
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown>0)
        {
            canshoot = false;
        }
        if (cooldown<0)
        {
            bulletsLoaded = 2;
        }
        if (bulletsLoaded > 0)
        {
            canshoot = true;
        }


        if (canshoot == true && bulletsLoaded > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                bulletsLoaded -= 1;
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
