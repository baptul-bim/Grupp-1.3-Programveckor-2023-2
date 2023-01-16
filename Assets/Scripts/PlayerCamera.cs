using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;
    Transform CamTransform;
    float followspeed;



    // Start is called before the first frame update
    void Start()
    {
        CamTransform = Camera.main.transform;

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
        //CamTransform.position = new Vector3(Player.position.x, CamTransform.position.y, CamTransform.position.z);

    }
}
