using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAwakening : MonoBehaviour
{
    //Louie W. Stormdal [SU22b]

    public Transform playerPos;

    bool cameraMoved;

    // Start is called before the first frame update
    void Start()
    {
        cameraMoved = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x - 5 < playerPos.transform.position.x)
        {


            GameObject playerObj = GameObject.FindWithTag("Player");
            playerObj.GetComponent<testmov>().enabled = false;

            


            GameObject[] currentEnemies = GameObject.FindGameObjectsWithTag("enemy");

            StartCoroutine(Wait());

            foreach (GameObject enemies in currentEnemies)
            {
                EnemyDeath killAll = GameObject.FindWithTag("enemy").GetComponent<EnemyDeath>();
                killAll.enemyHealth -= 99;
            }
        }
    }



    IEnumerator Wait()
    {
        if (cameraMoved == false)
        {
            yield return new WaitForSecondsRealtime(1);

            float cameraSpeed = 1 * Time.deltaTime;

            GameObject playerCamera = GameObject.FindWithTag("MainCamera");
            playerCamera.GetComponent<PlayerCamera>().enabled = false;
            playerCamera.transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), cameraSpeed);

            cameraMoved = true;
        }

    }
}
