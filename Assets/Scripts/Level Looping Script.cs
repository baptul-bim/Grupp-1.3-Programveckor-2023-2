using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoopingScript : MonoBehaviour
{

    public GameObject[] room;
    public int currentRoom;

    public Transform player1;

    double nextRoomPos;

    // Start is called before the first frame update
    void Start()
    {
        nextRoomPos = 2.5;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.position.x >= nextRoomPos)
        {
            nextRoomPos += 5;
            Instantiate(room[currentRoom], new Vector3(5, 0, 0), transform.rotation);

        }
    }
}

