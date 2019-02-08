using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    private int health = 4;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlayerBullet" || other.tag == "EnemyBullet")
        {
            //destroy bullet
            Destroy(other.gameObject);
            --health;
            //change color
            Color newColor = spriteRenderer.color;
            newColor.a -= 0.3f;
            spriteRenderer.color = newColor;
            //broken
            if(health<= 0)
            {
                Destroy(gameObject);
            }
        }else if(other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
