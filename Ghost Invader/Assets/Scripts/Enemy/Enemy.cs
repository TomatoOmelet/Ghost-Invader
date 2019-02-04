using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemySpeed = 1;
    public int down = -1;
    public bool canMoveRight = true;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        if(canMoveRight)
        {
            Debug.Log("canMoveRight");
            rb.velocity = new Vector2(enemySpeed, 0);
        }
        else
        {
            Debug.Log("canMoveLeft");
            rb.velocity = new Vector2(-enemySpeed, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
        if (collision.gameObject.tag == "RightBound")
        {
            transform.position += new Vector3(0, down * Time.deltaTime, 0);
            canMoveRight = false;
        }
        else if (collision.gameObject.tag == "LeftBound")
        {
            //rb.velocity = new Vector2(0, down * 60 * Time.deltaTime);
            transform.position += new Vector3(0, down * Time.deltaTime, 0);
            canMoveRight = true;
        }
    }
}
