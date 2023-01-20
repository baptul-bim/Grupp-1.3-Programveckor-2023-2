using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class pratbubbla : MonoBehaviour
{
    boss boss;
    healthPlayer phealth;
    public SpriteRenderer sprender;
    // Start is called before the first frame update
    void Start()
    {
        sprender.enabled = true;
        sprender = gameObject.GetComponent<SpriteRenderer>();
        boss = FindObjectOfType<boss>();
        phealth = FindObjectOfType<healthPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.linetimer > 0)
        {
            sprender.enabled = true;
        }
        else
        {
            sprender.enabled = false;
        }
        if (phealth.health <= 0)
        {
            sprender.enabled = true;
        }
        if (boss.bubbla == true)
        {
            sprender.enabled = true;
        }
    }
    
}
