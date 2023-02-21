using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backtomenu : MonoBehaviour
{
    //clara till clara
    private void OnEnable()
    {
        SceneManager.LoadScene("clara", LoadSceneMode.Single);
    }
}
