using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyVal;
    public EnemyManager enemyManager;

    void Start()
    {
        enemyManager = this.transform.parent.GetComponent<EnemyManager>();
    }

    void Update()
    {
        
    }
    public void attachScore(int num)
    {
        enemyVal = num;
    }

    void gameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerBullet")
        {
            Debug.LogFormat("Enemy Value: {0}", enemyVal);
            Destroy(col.gameObject);
            //enemyManager.speedUp();
            getHurt();
        }
        else if(col.gameObject.tag == "LowerBound")
        {
            gameOver();
        }
        else if (col.gameObject.tag == "RightBound")
        {
            enemyManager.moveDown();
            enemyManager.moveLeft();
        }
        else if (col.gameObject.tag == "LeftBound")
        {
            enemyManager.moveDown();
            enemyManager.moveRight();
        }

    }

    void getHurt()
    {
        Destroy(gameObject);    
    }
}
