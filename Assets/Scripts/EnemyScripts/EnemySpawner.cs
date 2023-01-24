using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public static float enemyPoints;
    float enemyPointsIncrease;


    public GameObject[] enemyPrefab;

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
        //while (enemyPoints < 1)
        //{
            if (enemyPoints == 1)
            {
                enemyToSpawn = 0;
                enemyPoints -= (enemyToSpawn + 1);
                Instantiate(axePrefab, new Vector3(Random.Range(-2.4f, 2.4f) + LevelLoop.nextRoomPos, 2, 0), Quaternion.identity);
            }
            else if (enemyPoints == 2)
            {
                int randEnemy = Random.Range(0, 2);
                enemyToSpawn = randEnemy;
                if (randEnemy == 0)
                {
                    enemyToSpawn = 0;
                    enemyPoints -= (enemyToSpawn + 1);

                    Instantiate(axePrefab, new Vector3(Random.Range(-2.4f, 2.4f) + LevelLoop.nextRoomPos, 2, 0), Quaternion.identity);

                }
                if (randEnemy == 1)
                {
                    enemyToSpawn = 1;
                    enemyPoints -= (enemyToSpawn + 1);
                    Instantiate(chainsawPrefab, new Vector3(Random.Range(-2.4f, 2.4f) + LevelLoop.nextRoomPos, 2, 0), Quaternion.identity);
                }
            }
            else if (enemyPoints >= 3)
            {
                int randEnemy = Random.Range(0, 3);
                enemyToSpawn = randEnemy;
                if (randEnemy == 0)
                {
                    enemyToSpawn = 0;
                    enemyPoints -= (enemyToSpawn + 1);
                    Instantiate(axePrefab, new Vector3(Random.Range(-2.4f, 2.4f) + LevelLoop.nextRoomPos, 2, 0), Quaternion.identity);
                }
                if (randEnemy == 1)
                {
                    enemyToSpawn = 1;
                    enemyPoints -= (enemyToSpawn + 1);
                    Instantiate(chainsawPrefab, new Vector3(Random.Range(-2.4f, 2.4f) + LevelLoop.nextRoomPos, 2, 0), Quaternion.identity);
                }
                if (randEnemy == 2)
                {
                    enemyToSpawn = 2;
                    enemyPoints -= (enemyToSpawn + 1);
                    Instantiate(flamethrowerPrefab, new Vector3(Random.Range(-2.4f, 2.4f) + LevelLoop.nextRoomPos, 2, 0), Quaternion.identity);
                }
            }
        //}

    }

    public void spawnEnemies()
    {
        enemyPoints = enemyPointsIncrease + 0.5f;
        enemyPointsIncrease = enemyPoints;
        
        



    }


}
