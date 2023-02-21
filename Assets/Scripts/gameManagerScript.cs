using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void gameOver() //Maja, game over screen kommer upp på skärm
    {
        gameOverUI.SetActive(true);
    }

    public void restart() //Maja, scenen restartar
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        pauseMenu.GameIsPaused = false;
    }
    
    public void mainMenu() //Maja, går tillbaka till mainmenu scenen
    {
        SceneManager.LoadScene("clara");
    }
}
