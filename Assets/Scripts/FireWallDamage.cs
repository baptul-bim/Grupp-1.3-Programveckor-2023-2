using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireWallDamage : MonoBehaviour
{
    //Kod av Louie W. Stormdal [SU22b]
    //script som skadar spelaren n�r den r�r en viss area inom eldv�ggen.

    int health;
    float decimalHealth;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<healthPlayer>().Damaged();

        }
    }


}