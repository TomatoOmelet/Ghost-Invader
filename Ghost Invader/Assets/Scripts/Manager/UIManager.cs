using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text levelText;
    private List<GameObject> heartUIList = new List<GameObject>();
    public GameObject heartUI;
    public Transform heartTransform;
    // Start is called before the first frame update
    void Start()
    {
        //give levelmanager assess to itself
        LevelManager.instance.uiManager = this;
        //update UI
        levelText.text = "Level: " + LevelManager.instance.GetLevel();
        UpdateScore(LevelManager.instance.GetScore());
        UpdateHealth(LevelManager.instance.health);
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
        int diff = value - heartUIList.Count;
        if(diff > 0)
        {
            for(int x = 0; x< diff; ++x)
            {
                GameObject heart = Instantiate(heartUI, heartTransform);
                heartUIList.Add(heart);
            }
        }
        else if (diff < 0)
        {
            for(int x = 0; x< -diff; ++x)
            {
                Destroy(heartUIList[heartUIList.Count - 1]);
                heartUIList.RemoveAt(heartUIList.Count - 1);
            }
        }
    }
}
