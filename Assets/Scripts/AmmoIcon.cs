using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoIcon : MonoBehaviour
{

    public Image bullets;

    float maxBullets = 2;

    float bulletAmount;

    // Start is called before the first frame update
    void Start()
    {
        bulletAmount = gun.bulletsLoaded;
        bullets = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletAmount = gun.bulletsLoaded;
        bullets.fillAmount = (bulletAmount / maxBullets);
        Debug.Log(bulletAmount / maxBullets);
    }
}
