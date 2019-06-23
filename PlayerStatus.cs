using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    GameObject Enemy1;
    GameObject Furry;

    private int Max_Player_Hp = 100;
    int player_hp;
    private int damege = 3;
    float dis;
    // Start is called before the first frame update
    void Start()
    {
        player_hp = Max_Player_Hp;
        Enemy1 = GameObject.Find("Enemy1");
        Furry = GameObject.Find("Furry");
    }

    // Update is called once per frame
    void Update()
    {
        distance();
    }

    //あたり判定〇
    void distance()
    {
        Vector3 FurryPos = Furry.transform.position;
        Vector3 Enemy1Pos = Enemy1.transform.position;
        dis = Vector3.Distance(FurryPos, Enemy1Pos);
        if (dis < 2 && player_hp > 0)
        {
            player_hp -= damege;
            Debug.Log("ダメージを受けました");
            Debug.Log("プレイヤー：" + player_hp);
        }
        else if (player_hp < 0)
        {
            Debug.Log("Dead End");
        }
    }
}
