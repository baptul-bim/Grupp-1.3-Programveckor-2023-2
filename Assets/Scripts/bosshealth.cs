using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bosshealth : MonoBehaviour
{
    private Image health;
    public float currenttemp = 20f;
    public float maxtemp = 50f;

    void Start()
    {
        health = GetComponent<Image>();
    }
    private void Update()
    {
        health.fillAmount = currenttemp / maxtemp;
    }
}
