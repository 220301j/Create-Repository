using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    GameObject Furry;
    GameObject Enemy1;
    GameObject Bullet;
    Animator animator;
    int Speed = 3;
    float dis, dis_2;
    public string key_isAttack = "Attack";
    public string key_isWalk = "Walk";

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        Furry = GameObject.Find("Furry");
        Enemy1 = GameObject.FindWithTag("Enemy1");
    }

    // Update is called once per frame
    void Update()
    {
        distance();
        walk();
    }

    void walk()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(Furry.transform.position.x+2, Furry.transform.position.y), Speed * Time.deltaTime);
    }

    //EnemyとFurryの距離
    void distance()
    {
        Vector3 FurryPos = Furry.transform.position;
        Vector3 Enemy1Pos = Enemy1.transform.position;
        dis = Vector3.Distance(FurryPos, Enemy1Pos);
        if (dis < 3)
        {
            this.animator.SetBool(key_isAttack, true);
            this.animator.SetBool(key_isWalk, false);
        }
        else
        {
            this.animator.SetBool(key_isWalk, true);
            this.animator.SetBool(key_isAttack, false);
        }
    }

    //EnemyとBulletの距離
    /*
    void distance_2()
    {
        Vector3 Enemy2Pos = Enemy1.transform.position;
        Vector3 BulletPos = Bullet.transform.position;
        dis_2 = Vector3.Distance(Enemy2Pos, BulletPos);
        if(dis_2 < 1)
        {
            enemy_hp -= damege;
            Debug.Log("エネミーのHP: " + enemy_hp);
        }
    }*/
    /*
    void OntriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");
        Destroy(gameObject);
    }*/
}
