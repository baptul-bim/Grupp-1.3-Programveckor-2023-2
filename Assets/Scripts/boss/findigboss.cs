using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findigboss : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x-5 > player.transform.position.x)
        {
            transform.position += transform.right * 2 * Time.deltaTime;
        }
    }

}
