using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//clara
public class MenuManager : MonoBehaviour
{
    //till n�sta sen i listan av scener 
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }
   
    //st�nger spel i build 
    public void Quit()
    {
        Application.Quit();
        Debug.Log("player gone hihihaha");
    }
}
