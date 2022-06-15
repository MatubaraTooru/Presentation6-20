using UnityEngine;
using UnityEngine.UI;

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
    AudioSource[] _as;
    int _ra = 30;
    [SerializeField] int _ms;
    GameObject _raText;
    void Start()
    {
        _crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        _rb = GetComponent<Rigidbody2D>();
        _as = gameObject.GetComponents<AudioSource>();
        _raText = GameObject.Find("RAText");
    }

    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");
        _timer += Time.deltaTime;
        _raText.GetComponent<Text>().text = _ra.ToString();

        if (Input.GetButton("Fire1") && _ra > 0 && _timer > _interval)
        {
            _ra -= 1;
            Instantiate(_bulletPrefab, _muzzle.position, this.transform.rotation);
            _timer = 0;
            
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(_grenadePrefab, _muzzle.position, transform.rotation);
        }
        Vector2 dir = _crosshair.transform.position - transform.position;
        transform.up = dir;
        if (Input.GetButton("Reload"))
        {
            _ra = _ms;
            _as[3].Play();
        }

        PlayAudio();
    }

    private void FixedUpdate()
    {
        Vector3 Direction = new Vector3(_h, _v).normalized;
        _rb.velocity = Direction * _moveSpeed;
    }
    void PlayAudio()
    {
        if (Input.GetButtonDown("Fire1") && _ra != 0)
        {
            _as[0].Play();
        }
        else if (Input.GetButtonDown("Fire1") && _ra == 0)
        {
            _as[1].Play();
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            _as[0].Stop();
        }
    }
}
