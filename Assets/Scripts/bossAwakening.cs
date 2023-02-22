using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAwakening : MonoBehaviour
{
    //Louie W. Stormdal [SU22b]

    public Transform playerPos;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPos.position.x >= 100.8f)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            playerObj.GetComponent<testmov>().enabled = false;
            GameObject[] currentEnemies;
            currentEnemies = GameObject.FindGameObjectsWithTag("enemy");

            foreach (GameObject enemies in currentEnemies)
            {
                EnemyDeath killAll = GameObject.FindWithTag("enemy").GetComponent<EnemyDeath>();
                killAll.enemyHealth -= 99;
            }
        }
    }
}
