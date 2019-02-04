using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static bool hasManager = false;
    private int score = 0;
    public UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        if(hasManager == false)
        {
            DontDestroyOnLoad(gameObject);
            hasManager = true;
        }
        else
            Destroy(gameObject);
        uiManager = GameObject.FindObjectOfType<UIManager>();
        uiManager.UpdateScore(score);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        uiManager = GameObject.FindObjectOfType<UIManager>();
        uiManager.UpdateScore(score);
    }

}
