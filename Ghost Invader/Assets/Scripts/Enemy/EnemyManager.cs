using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy enemyPrefab;

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
    public float maxWaitTime;
    public GameObject bullet;


    void Awake()
    {
        instantiateEnemyArray();
    }
    
    void instantiateEnemyArray()
    {
        enemyArray = new Enemy[ColumnLength, RowHeight];

        for (int i = 0; i < ColumnLength; ++i)
        {
            for (int j = 0; j < RowHeight; ++j)
            {
                enemyArray[i, j] = Instantiate(enemyPrefab, new Vector3(colStart + colSpace * i, rowStart + rowSpace * j, 0), Quaternion.identity);
                enemyArray[i, j].transform.SetParent(transform);
                assignEnemyValue(i, j);
            }
        }
        enemyCount = ColumnLength * RowHeight;
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

    void Update()
    {
        move();
        shoot();
    }

    void shoot()
    {
        if(Time.deltaTime > 0)
        {
            if (waitTime <= 0)
            {
                waitTime = Random.value * maxWaitTime;
                int randomCol = (int)(Random.value * (ColumnLength - 1));
                for (int i = 0; i < RowHeight; ++i)
                {
                    if (enemyArray[randomCol, i] != null)
                    {
                        Instantiate(bullet, enemyArray[randomCol, i].transform.position, Quaternion.identity);
                        break;
                    }
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

    public void moveRight()
    {
        if (!canMoveRight)
        {
            speedUp();
            canMoveRight = true;

        }
    }

    public void moveLeft()
    {
        if (canMoveRight)
        {
            speedUp();
            canMoveRight = false;
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
}
