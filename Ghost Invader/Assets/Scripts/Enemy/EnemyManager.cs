using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    
    public bool canMoveRight = true;
    public int enemySpeed = 1;
    public int down = -1;

    public Enemy enemyPrefab;

    [Header("Enemy Array Info")]
    public int ColumnLength;
    public int RowHeight;
    public float colStart;
    public float rowStart;
    public float colSpace;
    public float rowSpace;
    public Enemy[,] enemyArray;



    void Awake()
    {
        enemyArray = new Enemy[ColumnLength, RowHeight];
        
        for (int i = 0; i < ColumnLength; ++i)
        {
            for (int j = 0; j < RowHeight; ++j)
            {
                enemyArray[i, j] = Instantiate(enemyPrefab, new Vector3(colStart + colSpace * i, rowStart + rowSpace * j, 0), Quaternion.identity);
                enemyArray[i, j].transform.SetParent(transform);
            }
        }
    }

    void Update()
    {
        move();
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

    public void switchDirection()
    {
        transform.position += new Vector3(0, down * Time.deltaTime, 0);
        canMoveRight = !canMoveRight;
    }
}
