using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class warning : MonoBehaviour
{
    jumpdmg jumpdmg;
    public SpriteRenderer sprender;
    float warningtimer = 0.5f;
    void Start()
    {
        jumpdmg = GetComponent<jumpdmg>();
        sprender = gameObject.GetComponent<SpriteRenderer>();
        sprender.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        warningtimer -= Time.deltaTime;
        if (warningtimer<=0)
        {
            sprender.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="enemy")
        {
            sprender.enabled = true;
            warningtimer = 0.5f;
        }
    }
}
