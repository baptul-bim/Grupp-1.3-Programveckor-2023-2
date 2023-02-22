using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoop : MonoBehaviour
{
    //Kod av Louie W. Stormdal [SU22b]
    //Spawnar nya "rum" n�r du g�r tillr�ckligt n�ra kanten av nuvarande "rum"

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
            //spawnar ett speciellt "bossrum" som kommer innan du byter scen till bossen
            if (roomAmount >= 20)
            {
                currentRoom = bossRoom;
            }
            // vanlig rum-randomization
            else
            {
                int randRoom = Random.Range(0, 8);
                currentRoom = randRoom;
            }

            nextRoomPos += 4.8f;
            Instantiate(room[currentRoom], new Vector3((nextRoomPos), 0, 0), transform.rotation);
            roomAmount += 1;
            player1.gameObject.GetComponent<EnemySpawner>().spawnEnemies();

        }
    }
}

