using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    public GameObject fireball_1_1;
    public int speed = 25;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * this.speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
