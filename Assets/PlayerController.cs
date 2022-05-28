using UnityEngine;

public class PlayerController: MonoBehaviour
{
    /// <summary>左右移動する力</summary>
    [SerializeField] float m_movePower = 5f;
    /// <summary>ジャンプする力</summary>
    [SerializeField] float m_jumpPower = 15f;
    Rigidbody2D m_rb = default;
    /// <summary>水平方向の入力値</summary>
    float m_h;
    float m_scaleX;
    /// <summary>最初に出現した座標</summary>
    Vector3 m_initialPosition;
    public GroundCheck ground;
    private string groundTag = "Ground";
    private bool canJump = true;
    int m_jumpCount = 0;

    private bool isGround = false;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        // 初期位置を覚えておく
        m_initialPosition = this.transform.position;
    }

    void Update()
    {
        isGround = ground.IsGround();
        // 入力を受け取る
        m_h = Input.GetAxisRaw("Horizontal");


        // 各種入力を受け取る
        if (m_jumpCount < 1 && Input.GetButtonDown("Jump"))
        {
            //Debug.Log("ここにジャンプする処理を書く。");
            m_rb.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Force);
            m_jumpCount++;
        }
        // 下に行きすぎたら初期位置に戻す
        if (this.transform.position.y < -10f)
        {
            this.transform.position = m_initialPosition;
        }
    }

    private void FixedUpdate()
    {
        // 力を加えるのは FixedUpdate で行う
        m_rb.AddForce(Vector2.right * m_h * m_movePower, ForceMode2D.Force);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            canJump = true;
        }
        m_jumpCount = 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canJump = false;
    }
}
