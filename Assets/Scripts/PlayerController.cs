using UnityEngine;

public class PlayerController: MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f;
    Rigidbody2D _rb;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _muzzle;
    [SerializeField] float _interval;
    [SerializeField] GameObject _grenadePrefab;
    GameObject _crosshair;
    float _h;
    float _v;
    float _timer;
    AudioSource _gunshot;

    void Start()
    {
        _crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        _rb = GetComponent<Rigidbody2D>();
        _gunshot = GetComponent<AudioSource>();
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
                Instantiate(_bulletPrefab, _muzzle.position, this.transform.rotation);
                _timer = 0;
                
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(_grenadePrefab, _muzzle.position, transform.rotation);
        }
        Vector2 dir = _crosshair.transform.position - transform.position;
        transform.up = dir;
    }

    private void FixedUpdate()
    {
        Vector3 Direction = new Vector3(_h, _v).normalized;
        _rb.velocity = Direction * _moveSpeed;
    }
}
