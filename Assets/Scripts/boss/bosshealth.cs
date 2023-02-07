using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bosshealth : MonoBehaviour
{
    public Animator animator;
    public Image health;
    public float currenthealth;
    public float maxhealth = 90f;
    bool bossdeath = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<Image>();
        currenthealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        health.fillAmount = currenthealth / maxhealth;
    }
}