using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class cutscenemgr : MonoBehaviour
{
    //Clara g�r till level1
    private void OnEnable()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
}
