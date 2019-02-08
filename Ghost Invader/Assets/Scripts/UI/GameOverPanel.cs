using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public void RetryButton()
    {
        GameObject.FindObjectOfType<LevelManager>().RestartLevel();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

}
