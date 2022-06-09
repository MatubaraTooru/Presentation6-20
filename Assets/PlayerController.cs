using UnityEngine;

public class PlayerController: MonoBehaviour
{
    //���E�ړ������
    [SerializeField] float _moveSpeed = 5f;
    Rigidbody2D _rb = default;
    //�e�ۂ̃v���n�u
    [SerializeField] GameObject _shellPrefab = default;
    //�e���̈ʒu��ݒ肷��I�u�W�F�N�g
    [SerializeField] Transform _muzzle = default;
    //���������̓��͒l
    float _h;
    float _scaleX;
    float _v;
    //�ŏ��ɏo���������W
    Vector3 _initialPosition;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        // �����ʒu���o���Ă���
        _initialPosition = this.transform.position;
    }

    void Update()
    {
        
        // ���͂��󂯎��
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        // �e����͂��󂯎��

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("�����ɒe�𔭎˂��鏈���������B");
            GameObject go = Instantiate(_shellPrefab);
            go.transform.position = _muzzle.position;
        }
    }

    private void FixedUpdate()
    {
        Vector3 Direction = new Vector3(_h, _v).normalized;
        _rb.velocity = Direction * _moveSpeed;
    }
}
