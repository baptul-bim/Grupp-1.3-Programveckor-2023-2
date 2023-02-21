using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextSceneBoss : MonoBehaviour
{
    themometer temp;

    // Start is called before the first frame update
    void Start()
    {
        temp = FindObjectOfType<themometer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelLoop.roomAmount == 20) //Maja
        {
            SceneManager.LoadScene("BossRoom");
            temp.temptimer = 99999;
        }

    }
}
