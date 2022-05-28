using UnityEngine;

public class PlayerController: MonoBehaviour
{
    /// <summary>���E�ړ������</summary>
    [SerializeField] float m_movePower = 5f;
    /// <summary>�W�����v�����</summary>
    [SerializeField] float m_jumpPower = 15f;
    Rigidbody2D m_rb = default;
    /// <summary>���������̓��͒l</summary>
    float m_h;
    float m_scaleX;
    /// <summary>�ŏ��ɏo���������W</summary>
    Vector3 m_initialPosition;
    public GroundCheck ground;
    private string groundTag = "Ground";
    private bool canJump = true;
    int m_jumpCount = 0;

    private bool isGround = false;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        // �����ʒu���o���Ă���
        m_initialPosition = this.transform.position;
    }

    void Update()
    {
        isGround = ground.IsGround();
        // ���͂��󂯎��
        m_h = Input.GetAxisRaw("Horizontal");


        // �e����͂��󂯎��
        if (m_jumpCount < 1 && Input.GetButtonDown("Jump"))
        {
            //Debug.Log("�����ɃW�����v���鏈���������B");
            m_rb.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Force);
            m_jumpCount++;
        }
        // ���ɍs���������珉���ʒu�ɖ߂�
        if (this.transform.position.y < -10f)
        {
            this.transform.position = m_initialPosition;
        }
    }

    private void FixedUpdate()
    {
        // �͂�������̂� FixedUpdate �ōs��
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
