using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerInGame : MonoBehaviour
{
    public GameObject inGameScreen,pauseScreen;
    // Start is called before the first frame update
    public void PlayButton()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);

        inGameScreen.SetActive(true);
    }
    public void PauseButton()
    {
        Time.timeScale = 0;
        inGameScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }

    // Update is called once per frame
    public void RePlayButton()
    {  
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void HomeButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
