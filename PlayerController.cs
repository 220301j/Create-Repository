﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rigid2D;
    float walkForce = 450.0f; //移動
    float maxWalkSpeed = 3.0f;//最高速度
    float flap = 1000f;       //ジャンプ高さ
    bool  isJump = false;        //ジャンプできるか
    int jumpCounter = 0;
    private const int MAX_JUMP_COUNT = 2;

	// Use this for initialization
	void Start () {
        this.rigid2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        //移動
        MoveComand();
        //ジャンプ
        JumpComand();
        }

    //****************ジャンプ***********************
    void JumpComand()
    {
        if (jumpCounter < MAX_JUMP_COUNT && Input.GetKeyDown("space")){
            isJump = true;
        }
        if (isJump)
        {
            //rigid2D.velocity = Vector2.zero;//(一回目のジャンプと同じ高さで二回目のジャンプ)
            rigid2D.AddForce(Vector2.up * flap);
            jumpCounter++;
            isJump = false;
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
    
}