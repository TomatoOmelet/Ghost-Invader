using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;
    private int score = 0;
    private int level = 1;
    [System.NonSerialized]public int health = 3;

    public UIManager uiManager;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int value)
    {
        StartCoroutine(AddScoreRoutine(value));
    }

    public IEnumerator AddScoreRoutine(int value)
    {
        for(int x = 0; x < value; ++x)
        {
            ++score;
            uiManager.UpdateScore(score);
            yield return null;
        }
    }

    public void GoToNewLevel()
    {
        Time.timeScale = 1;
        ++level;
        ++health;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestartLevel()
    {
        score = 0;
        health = 3;
        level = 1;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetScore()
    {
        return score;
    }


}
