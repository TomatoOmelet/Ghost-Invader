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
        if (collision.gameObject.tag == "RightBound")
        {
            enemyManager.moveDown();
            enemyManager.moveLeft();
        }
        else if (collision.gameObject.tag == "LeftBound")
        {
            enemyManager.moveDown();
            enemyManager.moveRight();
        }
    }

    void gameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerBullet")
        {
            Destroy(col.gameObject);
            enemyManager.speedUp();
            getHurt();
        }
        else if(col.gameObject.tag == "LowerBound")
        {
            gameOver();
        }
        
    }

    void getHurt()
    {
        Destroy(gameObject);    
    }
}
