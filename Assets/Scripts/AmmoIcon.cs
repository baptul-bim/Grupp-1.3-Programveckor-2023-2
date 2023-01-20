using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoIcon : MonoBehaviour
{

    public Image bullets;

    float maxBullets;

    // Start is called before the first frame update
    void Start()
    {
        bullets = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        bullets.fillAmount = gun.bulletsLoaded / maxBullets;
    }
}
