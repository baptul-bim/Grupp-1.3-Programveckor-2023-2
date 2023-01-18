using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bosshealth : MonoBehaviour
{
    private Image health;
    public float currenthealth = 20f;
    public float maxhealth = 50f;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        health.fillAmount = currenthealth / maxhealth;
    }
}
