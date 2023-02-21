using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tillbakabossen : MonoBehaviour
{
    //tillbaka till bossen, Clara
    private void OnEnable()
    {
        SceneManager.LoadScene("BossRoom", LoadSceneMode.Single);
    }
}
