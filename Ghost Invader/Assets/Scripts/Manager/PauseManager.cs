using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    bool isPaused = false;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused == false && gameOverPanel.activeSelf == false && winPanel.activeSelf == false)
            {
                pause();
            }
            else if(isPaused == true)
            {
                resume();
            }
        }
    }

    public void pause()
    {
        Time.timeScale = 0.0f;
        isPaused = true;
        pausePanel.SetActive(true);
    }

    public void resume()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        pausePanel.SetActive(false);
    }

    public void quit()
    {
        Application.Quit();
    }


}
