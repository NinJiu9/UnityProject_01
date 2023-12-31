using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private float input_x;
    private bool isGround = false;
    private Rigidbody2D rb;
    private BoxCollider2D cld;
    public float speed = 8.0f;
    public float jumpForce = 1000.0f;
    private Transform playerT;
    private SpriteRenderer playerSR;
    private float playerBlood;
    public Slider BloodSlider;
    //扣血最小值
    private float MinRreduceBlood = -0.05f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cld = GetComponent<BoxCollider2D>();
        playerT = GetComponent<Transform>();
        playerSR = GetComponent<SpriteRenderer>();
        PlayerSaveState();
    }

    private void Update()
    {
        Jump();
        Raycast();
        Move();
    }

    /*
     * 控制跳跃
     */
    void Jump()
    {
        if (isGround && Input.GetKeyDown(KeyCode.Space))

            rb.AddForce(Vector2.up * jumpForce);
    }

    /*
     * Ray射线检测
     */
    void Raycast()
    {
        //找到方块下面的点
        Vector3 origin = cld.bounds.center - new Vector3(0, cld.bounds.extents.y, 0);
        //设置射线
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, 0.3f, 1 << 6);
        // 显示射线
        // Debug.DrawLine(origin, origin + Vector3.down * 0.1f, Color.red, 0.3f);
        isGround = hit.collider;
    }

    /*
     * 控制移动
     */
    void Move()
    {
        input_x = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(input_x * speed, rb.velocity.y);
    }

    /*
     * 保存角色状态
     */
    void PlayerSaveState()
    {
        PlayerState playerState = new PlayerState();
        playerState.Playerposition = playerT.position;
        playerState.Playercolor = playerSR.color;
        playerState.PlayerBlood = playerBlood;

        string json = JsonUtility.ToJson(playerState, true); //加个True，会将数据以较为好看的格式存进去
        File.WriteAllText(Application.dataPath + "/playerState.txt", json);
    }

    /*
     * 加载角色状态
     */
    public void LoadState()
    {
        string json = File.ReadAllText(Application.dataPath + "/playerState.txt");
        PlayerState playerState = JsonUtility.FromJson<PlayerState>(json);
        playerT.position = playerState.Playerposition;
        playerSR.color = playerState.Playercolor;
        playerBlood = playerState.PlayerBlood;
    }

    /*
     * 更新角色血量
     */
    public void UpdateBlood(float value)
    {
        playerBlood += value;
        BloodSlider.value += value;
    }

    /*
     * 碰撞三角形扣血
     */
    public void ReduceBlood()
    {
        UpdateBlood(2*MinRreduceBlood);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Tip"))
        {
            Tip tip = other.GetComponent<Tip>();
            if (tip.TipAnimator != null)
            {
                tip.TipAnimator.SetBool("TipAppear",true);
            }
        }
        if(other.CompareTag("Stick"))
        {
            ReduceBlood();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Tip"))
        {
            Tip tip = other.GetComponent<Tip>();
            if (tip.TipAnimator != null)
            {
                tip.TipAnimator.SetBool("TipAppear",false);
            }
        }
    }
}

public class PlayerState
{
    public Vector3 Playerposition;
    public Color Playercolor;
    public float PlayerBlood;
}