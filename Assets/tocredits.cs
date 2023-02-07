using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tocredits : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }
}
