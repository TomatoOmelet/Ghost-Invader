using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Vector2 velocity;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        //Let Player Handle Getting Hit
        ////Debug.Log("On Trigger Enter");
        //if (col.gameObject.tag == "Player")
        //{
        //    Debug.Log("Player Gets Hit");
        //    col.GetComponent<Player>().GetHurt();
        //    Destroy(gameObject);
        //    //transform.position += new Vector3(enemySpeed * Time.deltaTime, 0, 0);
        //}
        if (col.gameObject.tag == "LowerBound")
        {
            Destroy(gameObject);
        }

    }
}
