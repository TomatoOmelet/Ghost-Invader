using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text levelText;
    public GameObject[] heartUIList;
    // Start is called before the first frame update
    void Start()
    {
        //give levelmanager assess to itself
        LevelManager.instance.uiManager = this;
        //update level info
        levelText.text = "Level: " + LevelManager.instance.GetLevel();
        UpdateScore(LevelManager.instance.GetScore());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevelButton()
    {
        LevelManager.instance.GoToNewLevel();
    }

    public void UpdateScore(int value)
    {
        scoreText.text = value.ToString();
    }

    public void UpdateHealth(int value)
    {
        for(int x = 0; x< heartUIList.Length; ++x)
        {
            if(x < value)
                heartUIList[x].SetActive(true);
            else    
                heartUIList[x].SetActive(false);
        }
    }
}
