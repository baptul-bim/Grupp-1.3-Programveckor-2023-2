using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walloffire : MonoBehaviour
{
    themometer temp;
    healthPlayer health;
    //public float currenttemp = 20f;
    public float maxtemp = 50f;
    public float temptimer = 2;
    // Start is called before the first frame update
    void Start()
    {
        temp = FindObjectOfType<themometer>();
        health = GetComponent<healthPlayer>();
        //speed = temp.currenttemp;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * (themometer.currenttemp * 0.07f) * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<healthPlayer>().health = 0;
        }
        
    }
}
