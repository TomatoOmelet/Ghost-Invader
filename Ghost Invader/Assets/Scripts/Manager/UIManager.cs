using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject[] heartUIList;
    // Start is called before the first frame update
    void Start()
    {
        //give levelmanager assess to itself
        GameObject.FindObjectOfType<LevelManager>().uiManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
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
