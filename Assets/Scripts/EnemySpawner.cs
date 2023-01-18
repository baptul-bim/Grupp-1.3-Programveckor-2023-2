using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    int enemyPoints;


    [SerializeField]
    GameObject axePrefab;
    [SerializeField]
    GameObject chainsawPrefab;
    [SerializeField]
    GameObject flamethrowerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        enemyPoints = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
