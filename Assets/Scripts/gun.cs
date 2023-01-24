using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Transform[] firepoint;
    public GameObject bulletprefab;
    public float cooldown=1;
    bool canshoot;


    public static float bulletsLoaded;

    public AudioSource sourceAud;
    public AudioClip shootAud;
    public AudioClip reloadAud;


    void Start()
    {
        bulletsLoaded = 2;

        //gun audio
        sourceAud = GetComponent<AudioSource>();

    }

    void Update()
    {
        //reload function
        cooldown += Time.deltaTime;
        if (cooldown < 1)
        {
            canshoot = false;
        }
        if (cooldown >= 1 && bulletsLoaded < 2) 
        {
            sourceAud.PlayOneShot(reloadAud);
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
                cooldown = 0;
            }
        }


        void Shoot()
        {
            sourceAud.PlayOneShot(shootAud);
            Instantiate(bulletprefab, firepoint[0].position, firepoint[0].rotation);
            Instantiate(bulletprefab, firepoint[1].position, firepoint[1].rotation);
            Instantiate(bulletprefab, firepoint[2].position, firepoint[2].rotation);
        }
    }
}
