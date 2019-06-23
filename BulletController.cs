using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private GameObject player;
    private int speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Furry");
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(speed * player.transform.localScale.x, rigidbody2D.velocity.y-1);
        Vector2 temp = transform.localScale;
        temp.x = player.transform.localScale.x;
        transform.localScale = temp;
        Destroy(gameObject, 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
