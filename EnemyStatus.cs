using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    GameObject Enemy1;
    GameObject Bullet;

    private int Max_Enemy_Hp = 30;
    private int enemy_hp;
    private int damege = 2;
    float dis_2;
    // Start is called before the first frame update
    void Start()
    {
        enemy_hp = Max_Enemy_Hp;
        Enemy1 = GameObject.Find("Enemy1");
        Bullet = GameObject.Find("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        distance_2();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            Debug.Log("hit enemy");
            enemy_hp -= damege;
        }
        if(enemy_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void distance_2()
    {
        Vector3 Enemy2Pos = Enemy1.transform.position;
        Vector3 BulletPos = Bullet.transform.position;
        dis_2 = Vector3.Distance(Enemy2Pos, BulletPos);
        if(dis_2 < 2 && enemy_hp > 0)
        {
            enemy_hp -= damege;
            Debug.Log("ダメージを与えました");
            Debug.Log("Enemy : " + enemy_hp);
        }
    }
}
