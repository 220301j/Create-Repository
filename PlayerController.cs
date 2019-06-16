using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;  //<- 追加
    //FireBallプレハブ
    //public GamaObiect PlayerFireball;

    float walkForce = 400.0f; //移動
    float maxWalkSpeed = 3.0f;//最高速度
    float flap = 1000f;       //ジャンプ高さ
    bool isJump = false;        //ジャンプできるか
    int jumpCounter = 0;
    private const int MAX_JUMP_COUNT = 2;
    private bool isAttack = false;  //攻撃

    // Use this for initialization
    /*void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }*/
    IEnumerator Start()
    {
        while (true)
        {
            Instantiate(fireball_1_1, transform.position, transform.rotation);
        }
    }


    // Update is called once per frame
    void Update()
    {

        //移動
        MoveComand();
        //ジャンプ
        JumpComand();
        //攻撃
        AttackCommand();
    }

    //****************ジャンプ***********************
    void JumpComand()
    {
        if (jumpCounter < MAX_JUMP_COUNT && Input.GetKeyDown("space"))
        {
            isJump = true;
            this.animator.SetTrigger("JumpTrigger");
        }
        else
        {
            this.animator.SetTrigger("WalkTigger");　
        }                                           
        if (isJump)
        {
            rigid2D.AddForce(Vector2.up * flap);
            jumpCounter++;
            isJump = false;
        }
        else
        {
            this.animator.SetTrigger("WalkTrigger");
        }
    }
    //ジャンプ回数のリセット
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Ground")
        {
            jumpCounter = 0;
        }
    }
    //***********************************************


    //*************移動******************************

    void MoveComand()
    {
        int key = 0;
        if (Input.GetKey(KeyCode.D)) key = 1;
        if (Input.GetKey(KeyCode.A)) key = -1;

        // プレイヤの速度
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // スピード制限
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        // 動く方向に応じて反転（追加）
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
    }
    //*************************************************


    //**************攻撃*****************
    void AttackCommand()
    {
        if (Input.GetMouseButton(0))
        {
            print("左ボタンが押されている");
        }
        if (Input.GetMouseButton(1))
        {
            print("右のボタンが押されている");
        }
    }
}
