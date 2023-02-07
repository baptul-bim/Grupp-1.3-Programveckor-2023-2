using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backtomenu : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("clara", LoadSceneMode.Single);
    }
}
