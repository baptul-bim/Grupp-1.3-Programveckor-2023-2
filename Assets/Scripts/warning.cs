using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class warning : MonoBehaviour
{
    jumpdmg jumpdmg;
    public SpriteRenderer sprender;
    void Start()
    {
        jumpdmg = GetComponent<jumpdmg>();
        sprender = gameObject.GetComponent<SpriteRenderer>();
        sprender.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="enemy")
        {
            sprender.enabled = true;
            print("warniing");
        }
    }
}
