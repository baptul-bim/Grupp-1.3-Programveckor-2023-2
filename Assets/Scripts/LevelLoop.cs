using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoop : MonoBehaviour
{
    //Kod av Louie W. Stormdal [SU22b]


    public GameObject[] room;

    public int bossRoom = 8;

    public int currentRoom;

    public Transform player1;

    public static float nextRoomPos;

    int enemyPointsSaver;

    public static int roomAmount;




    // Start is called before the first frame update
    void Start()
    {
        nextRoomPos = 0;
        roomAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.position.x >= nextRoomPos)
        {
            if (roomAmount >= 20)
            {
                //currentRoom = bossRoom;
            }
            else
            {
                //enemyPointsSaver = EnemySpawner.enemyPoints;
                int randRoom = Random.Range(0, 8);
                currentRoom = randRoom;
                nextRoomPos += 4.8f;
                Instantiate(room[currentRoom], new Vector3((nextRoomPos), 0, 0), transform.rotation);
                roomAmount += 1;
                player1.gameObject.GetComponent<EnemySpawner>().spawnEnemies();
                //EnemySpawner.enemyPoints += enemyPointsSaver + 1;
            }


        }
    }
}

