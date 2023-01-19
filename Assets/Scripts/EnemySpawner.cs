using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    int enemyPoints;

    public GameObject[] room;

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
        enemyPoints = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyPoints == 1)
        {
            enemyToSpawn = 0;
            enemyPoints -= (enemyToSpawn + 1);
            Instantiate(axePrefab);
        }
        else if (enemyPoints == 2)
        {
            int randEnemy = Random.Range(0, 3);
            enemyToSpawn = randEnemy;
            if (randEnemy == 0)
            {
                enemyToSpawn = 0;
                enemyPoints -= (enemyToSpawn + 1);
                Instantiate(axePrefab);
            }
            if (randEnemy == 1)
            {
                enemyToSpawn = 1;
                enemyPoints -= (enemyToSpawn + 1);
                Instantiate(axePrefab);
            }
        }

    }


}
