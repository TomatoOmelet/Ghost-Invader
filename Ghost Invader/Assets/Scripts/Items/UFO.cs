using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public float y;
    public float minX;
    public float maxX;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 50f);
        //go left
        if(Random.Range(0,2) == 0)
        {
            transform.position = new Vector3(maxX, y, transform.position.z);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
        }
        //go right
        else{
            transform.position = new Vector3(minX, y, transform.position.z);
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlayerBullet")
        {
            Destroy(other.gameObject);
            //get a random score from 100 to 300
            int rand = Random.Range(2, 7) * 50;
            //increase the score
            GameObject.FindObjectOfType<LevelManager>().AddScore(rand);
            Destroy(gameObject);
        }
    }

}
