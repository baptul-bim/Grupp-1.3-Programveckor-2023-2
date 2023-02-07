using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class cutscenemgr : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
}
