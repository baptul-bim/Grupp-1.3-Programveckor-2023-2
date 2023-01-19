using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoop : MonoBehaviour
{

    public GameObject[] room;
    public int currentRoom;

    public Transform player1;

    float nextRoomPos;




    // Start is called before the first frame update
    void Start()
    {
        nextRoomPos = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (player1.position.x >= nextRoomPos)
        {
            int randRoom = Random.Range(0, 8);
            currentRoom = randRoom;
            nextRoomPos += 4.8f;
            Instantiate(room[currentRoom], new Vector3((nextRoomPos), 0, 0), transform.rotation);

        }
    }
}

