using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Albin
public class walloffire : MonoBehaviour
{
    themometer temp;
    healthPlayer health;
    public float maxtemp = 50f;
    public float temptimer = 2;
    // Start is called before the first frame update
    void Start()
    {
        temp = FindObjectOfType<themometer>();
        health = FindObjectOfType<healthPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.health>0) //åk bara om man lever
        {
            transform.position += transform.right * (themometer.currenttemp * 0.05f) * Time.deltaTime; //åk åt höger i samma hastighet som temperaturen gånger 0,05
        }  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health.health = 0; //om spelaren nuddar elden dör spelaren
        }
        
    }
}
