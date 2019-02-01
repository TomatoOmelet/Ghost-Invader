using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    public float speed;
    public float halfWidth;
    private int health;
    private bool canShoot = true;
    public GameObject bullet;
    public GameOverPanel gameOverPanel;
    public Camera ourCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckFire();
    }

    public void Move()
    {
        //move ment
        GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed * 60 * Time.deltaTime ,0);
        //boundary
        //check left
        if(ourCamera.WorldToScreenPoint(transform.position - new Vector3(halfWidth, 0, 0)).x < 0)
        {
            transform.position = new Vector3(ourCamera.ScreenToWorldPoint(new Vector3(0,0,0)).x + halfWidth, transform.position.y, transform.position.z);
        }
        //check right
        else if(ourCamera.WorldToScreenPoint(transform.position + new Vector3(halfWidth, 0, 0)).x > Screen.width)
        {
            transform.position = new Vector3(ourCamera.ScreenToWorldPoint(new Vector3(Screen.width,0,0)).x - halfWidth, transform.position.y, transform.position.z);
        }
    }

    public void CheckFire()
    {
        if(Input.GetButtonDown("Fire1") && canShoot)
        {
            canShoot = false;
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    public void ResetBullet()
    {
        canShoot = true;
    }

    public void GetHurt()
    {
        --health;
        //update UI

        //die
        if(health <= 0)
        {
            gameOverPanel.GameOver();
        }
    }
}
