using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int score = 0;
    public UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        uiManager = GameObject.FindObjectOfType<UIManager>();
        uiManager.UpdateScore(score);
        AddScore(500);
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

}
