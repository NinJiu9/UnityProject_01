using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Rigidbody2D rbPlayer;
    private BoxCollider2D cld;
    public float speed = 4.0f;
    public float jumpForce = 300.0f;
    private bool isGround = false;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        cld = GetComponent<BoxCollider2D>();
        //设置受重力影响值为 3
        // rb_Player.gravityScale = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Raycast();
    }

    void Move()
    {
        float input_x = Input.GetAxisRaw("Horizontal");
        rbPlayer.velocity = new Vector2(input_x * speed, rbPlayer.velocity.y);
    }

    void Jump()
    {
        if (isGround & Input.GetKeyDown(KeyCode.Space))
        {
            rbPlayer.AddForce(Vector2.up * jumpForce);
        }
    }
    //判断是否在空中并将结果赋值给 isGround 
    void Raycast()
    {
        Vector3 origin = cld.bounds.center - new Vector3(0, cld.bounds.extents.y, 0);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, 0.3f, 1 << 6);
        isGround = hit.collider;
    }
}