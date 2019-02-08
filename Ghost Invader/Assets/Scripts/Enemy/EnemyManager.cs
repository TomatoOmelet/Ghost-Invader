using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy enemyPrefab;
    public GameOverPanel gameOverPanel;
    public GameObject winPanel;

    [Header("Speed Info")]
    public bool canMoveRight = true;
    public float enemySpeed = 1.0f;
    public int down = -1;
    public float speedUpAmount;

    [Header("Enemy Array Info")]
    public int ColumnLength;
    public int RowHeight;
    public float colStart;
    public float rowStart;
    public float colSpace;
    public float rowSpace;
    public Enemy[,] enemyArray;
    public int enemyCount;

    [Header("Shoot Info")]
    public float waitTime;
    public float minWaitTime = 20;
    public float maxWaitTime;
    public float shootSpeedUp;
    public GameObject bullet;
    public List<int> posColList;
    public int posCol;



    void Awake()
    {
        instantiateEnemyArray();
    }
    
    void instantiateEnemyArray()
    {
        enemyArray = new Enemy[ColumnLength, RowHeight];
        posColList = new List<int>();
        posCol = ColumnLength;
        for (int i = 0; i < ColumnLength; ++i)
        {
            for (int j = 0; j < RowHeight; ++j)
            {
                enemyArray[i, j] = Instantiate(enemyPrefab, new Vector3(colStart + colSpace * i, rowStart + rowSpace * j, 0), Quaternion.identity);
                enemyArray[i, j].transform.SetParent(transform);
                assignEnemyValue(i, j);
            }
            posColList.Add(i);
        }
        enemyCount = ColumnLength * RowHeight;
        //move down depends on the level
        transform.position = transform.position - new Vector3(0, LevelManager.instance.GetLevel() - 1,0);
    }

    void assignEnemyValue(int height, int row)
    {
        Enemy enemy = enemyArray[height, row].transform.GetComponent<Enemy>();
        if (row == 0 || row == 1)
        {
            enemy.enemyVal = 10;
        }
        else if (row == 2 || row == 3)
        {
            enemy.enemyVal = 20;
        }
        else if (row == 4)
        {
            enemy.enemyVal = 40;
        }
    }

    public void gameOver()
    {
        gameOverPanel.GameOver();
    }

    public void winLevel()
    {
        if(enemyCount == 0)
        //if(enemyCount < 50)
        {
            Time.timeScale = 0;
            winPanel.SetActive(true);    
        }
    }

    void Update()
    {
        move();
        shoot();
    }

    public void killEnemy()
    {
        --enemyCount;
    }

    void shoot()
    {
        if(Time.deltaTime > 0)
        {
            if (waitTime <= 0)
            {
                bool shoot = false;
                waitTime = Random.value * maxWaitTime;
                //int randomCol = posColList.ElementAt((int)(Random.value * (posCol - 1)));
                int randomCol = posColList[(int)(Random.value * (posCol - 1))];
                for (int i = 0; i < RowHeight; ++i)
                {
                    if (enemyArray[randomCol, i] != null)
                    {
                        Instantiate(bullet, enemyArray[randomCol, i].transform.position, Quaternion.identity);
                        shoot = true;
                        break;
                    }
                }
                if(shoot == false)
                {
                    posColList.Remove(randomCol);
                    waitTime = 0;
                    --posCol;
                }
            }
            else
            {
                --waitTime;
            }
        }
            

    }

    void move()
    {
        if (canMoveRight)
        {
            transform.position += new Vector3(enemySpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position += new Vector3(-enemySpeed * Time.deltaTime, 0, 0);
        }
    }

    void levelDifficultyIncrease()
    {
        speedUp();
        shootMore();

    }
    public void moveRight()
    {
        if (!canMoveRight)
        {
            levelDifficultyIncrease();
            canMoveRight = true;
            moveDown();

        }
    }

    public void moveLeft()
    {
        if (canMoveRight)
        {
            levelDifficultyIncrease();
            canMoveRight = false;
            moveDown();
        }   
    }

    public void moveDown()
    {
        transform.position += new Vector3(0, down * Time.deltaTime, 0);
    }

    public void speedUp()
    {
        enemySpeed += speedUpAmount;
    }

    public void shootMore()
    {
        maxWaitTime = maxWaitTime - shootSpeedUp;
        if(maxWaitTime < minWaitTime)
        {
            maxWaitTime = minWaitTime;
        }
    }
}
