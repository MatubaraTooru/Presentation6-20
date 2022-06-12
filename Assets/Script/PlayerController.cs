using UnityEngine;

public class PlayerController: MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f;
    Rigidbody2D _rb = default;
    [SerializeField] GameObject _shellPrefab = default;
    [SerializeField] Transform _muzzle = default;
    [SerializeField] float _interval;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _crosshair;
    float _h;
    float _v;
    float _timer;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");
        _timer += Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
            if (_timer > _interval)
            {
                Instantiate(_shellPrefab, _muzzle.position, this.transform.rotation);
                _timer = 0;
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(_bulletPrefab, _muzzle.position, transform.rotation);
        }
        Vector2 dir = _crosshair.position - transform.position;
        transform.up = dir;
    }

    private void FixedUpdate()
    {
        Vector3 Direction = new Vector3(_h, _v).normalized;
        _rb.velocity = Direction * _moveSpeed;
    }
}
