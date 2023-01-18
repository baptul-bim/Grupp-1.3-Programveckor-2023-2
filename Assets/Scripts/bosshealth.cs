using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bosshealth : MonoBehaviour
{
    private Image health;
    public float currenthealth;
    public float maxhealth = 20f;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Image>();
        currenthealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        health.fillAmount = currenthealth / maxhealth;
    }
}
