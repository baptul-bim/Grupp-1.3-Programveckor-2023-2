using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionZone : MonoBehaviour
{
    //Kod av Louie W. Stormdal [SU22b]
    //bara en enkel script ifall en fiende skulle råka ramla igenom marken på något vis så ska den inte falla i all evighet utan förstörs när den rör en röd box.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            Destroy(collision.gameObject);
        }

    }
}
