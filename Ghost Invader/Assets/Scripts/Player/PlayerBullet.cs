using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Vector2 velocity;
    public float halfHeight; 
    private Camera ourCamera;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
        ourCamera = GameObject.FindObjectOfType<Camera>();
    }

    void Update()
    {
        CheckBound();
    }


    public void CheckBound()
    {
        if(ourCamera.WorldToScreenPoint(transform.position - new Vector3(0, halfHeight, 0)).y > Screen.height)
        {
            Destroy(gameObject);
        }
    }

    public void OnDestroy()
    {
        Player player = GameObject.FindObjectOfType<Player>();
        if(player!= null)
            player.ResetBullet();
    }

}
