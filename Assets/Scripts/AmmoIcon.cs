using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoIcon : MonoBehaviour
{
    //Kod av Louie W. Stormdal [SU22b]

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
        //ammo counter, baserat på hur många skott du har laddade, från 0 till 2. Kopplat till 'gun' script.
        bulletAmount = gun.bulletsLoaded;
        bullets.fillAmount = (bulletAmount / maxBullets);
        Debug.Log(bulletAmount / maxBullets);
    }
}
