using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public float jumpForce = 300.0f;
    public float walkForce = 100.0f;
    public float maxWalkSpeed = 2.0f;
    Animator animator;

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 跳躍
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid2D.AddForce(transform.up * this.jumpForce);
            animator.SetTrigger("Jump");

            //rigid2D.AddForce(new Vector(0, 1, 0) * this.jumpForce);
        }

        // 左右移動
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        // 遊戲角色的速度
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // 速度限制
        if (speedx < this.maxWalkSpeed)
        {
            rigid2D.AddForce(transform.right * key * walkForce);
        }

        // (追加)依照行進方向翻轉
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        // 依遊戲角色的速度改變動畫的速度
        if (rigid2D.velocity.y == 0)
        {
            animator.speed = speedx / 2.0f;
        }
        else
        {
            animator.speed = 1.0f;
        }

    }
}
