using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionZone : MonoBehaviour
{
    //Kod av Louie W. Stormdal [SU22b]
    //bara en enkel script ifall en fiende skulle r�ka ramla igenom marken p� n�got vis s� ska den inte falla i all evighet utan f�rst�rs n�r den r�r en r�d box.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            Destroy(collision.gameObject);
        }

    }
}
