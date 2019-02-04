using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyManager enemyManager;

    void Start()
    {
        enemyManager = this.transform.parent.GetComponent<EnemyManager>();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
        if (collision.gameObject.tag == "RightBound" || collision.gameObject.tag == "LeftBound")
        {
            enemyManager.switchDirection();
        }
        if (collision.gameObject.tag == "LowerBound")
        {
            gameOver();
        }
    }

    void gameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
}
