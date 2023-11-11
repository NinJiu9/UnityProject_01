using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

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
        //显示射线
        Debug.DrawLine(origin, origin + Vector3.down * 0.1f, Color.red, 0.3f);
        isGround = hit.collider;
    }

    void Move()
    {
        input_x = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(input_x * speed, rb.velocity.y);
    }

    void PlayerSaveState()
    {
        PlayerState playerState = new PlayerState();
        playerState.playerposition = playerT.position;
        playerState.playercolor = playerSR.color;

        string json = JsonUtility.ToJson(playerState, true); //加个True，会将数据以较为好看的格式存进去
        File.WriteAllText(Application.dataPath + "/playerState.txt", json);
    }

    public void LoadState()
    {
        string json = File.ReadAllText(Application.dataPath + "/playerState.txt");
        PlayerState playerState = JsonUtility.FromJson<PlayerState>(json);
        playerT.position = playerState.playerposition;
        playerSR.color = playerState.playercolor;
    }
}

public class PlayerState
{
    public Vector3 playerposition;
    public Color playercolor;
}