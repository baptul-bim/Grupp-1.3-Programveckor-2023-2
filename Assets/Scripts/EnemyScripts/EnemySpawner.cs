using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public static float enemyPoints;
    float enemyPointsIncrease;


    public GameObject[] enemyPrefab;

    Vector3 spawnPlace;
    public Vector2 direction;
    Vector3 fromGround;

    [SerializeField]
    GameObject axePrefab;
    [SerializeField]
    GameObject chainsawPrefab;
    [SerializeField]
    GameObject flamethrowerPrefab;




    int enemyToSpawn;



    // Start is called before the first frame update
    void Start()
    {
        enemyPoints = 0;
        enemyPointsIncrease = enemyPoints;
    }

    // Update is called once per frame
    void Update()
    {

        if (enemyPoints == 1)
        {
            spawnRand();
            enemyToSpawn = 0;
            enemyPoints -= (enemyToSpawn + 1);

            Instantiate(axePrefab, spawnPlace, Quaternion.identity);
        }
        else if (enemyPoints == 2)
        {
            int randEnemy = Random.Range(0, 2);
            enemyToSpawn = randEnemy;
            if (randEnemy == 0)
            {
                spawnRand();
                enemyToSpawn = 0;
                enemyPoints -= (enemyToSpawn + 1);

                Instantiate(axePrefab, spawnPlace, Quaternion.identity);

            }
            if (randEnemy == 1)
            {
                spawnRand();
                enemyToSpawn = 1;
                enemyPoints -= (enemyToSpawn + 1);

                Instantiate(chainsawPrefab, spawnPlace, Quaternion.identity);
            }
        }
        else if (enemyPoints >= 3)
        {
            int randEnemy = Random.Range(0, 3);
            enemyToSpawn = randEnemy;
            if (randEnemy == 0)
            {
                spawnRand();
                enemyToSpawn = 0;
                enemyPoints -= (enemyToSpawn + 1);

                Instantiate(axePrefab, spawnPlace, Quaternion.identity);
            }
            if (randEnemy == 1)
            {
                spawnRand();
                enemyToSpawn = 1;
                enemyPoints -= (enemyToSpawn + 1);

                Instantiate(chainsawPrefab, spawnPlace, Quaternion.identity);
            }
            if (randEnemy == 2)
            {
                spawnRand();
                enemyToSpawn = 2;
                enemyPoints -= (enemyToSpawn + 1);

                Instantiate(flamethrowerPrefab, spawnPlace, Quaternion.identity);
            }
        }


    }

    public void spawnEnemies()
    {
        enemyPoints = enemyPointsIncrease + 0.5f;
        enemyPointsIncrease = enemyPoints;





    }

    public void spawnRand()
    {
        spawnPlace = new Vector3(Random.Range(-2.4f, 2.4f) + LevelLoop.nextRoomPos, 2, 0);
        RaycastHit2D groundRay = Physics2D.Raycast(spawnPlace, direction);
        Debug.DrawRay(spawnPlace, direction);



        if (groundRay.collider != null && groundRay.transform.tag == ("Ground"))
        {
            fromGround = new Vector3(0f, groundRay.distance, 0f);
            spawnPlace.y -= groundRay.distance;
        }
        Debug.Log(spawnPlace);
    }

}
