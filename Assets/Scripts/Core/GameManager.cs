using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool playerAlive = true;
    public bool gamePaused = false;
    public GameObject inGameMenuScreen;
    public bool menuScreens;

    private void Start()
    {
        if (!menuScreens)
        {
            inGameMenuScreen.SetActive(false);
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        gamePaused = false;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
        gamePaused = false;
    }

    public void CharacterSelecButton()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

    public void ResumeButton()
    {
        PausePlay();
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !menuScreens)
        {
            PausePlay();
        }
    }

    public void PausePlay()
    {
        if (gamePaused)
        {
            gamePaused = false;
            Time.timeScale = 1;
            inGameMenuScreen.SetActive(false);
        }
        else
        {
            gamePaused = true;
            Time.timeScale = 0;
            inGameMenuScreen.SetActive(true);
        }
    }
}
