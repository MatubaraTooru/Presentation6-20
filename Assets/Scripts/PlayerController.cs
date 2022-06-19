using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
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
    [SerializeField] GameObject _raText;
    Animator _anim;
    public int _life;
    void Start()
    {
        _crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        _rb = GetComponent<Rigidbody2D>();
        _as = gameObject.GetComponents<AudioSource>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        //各入力の受付とそれに伴う処理
        _h = Input.GetAxisRaw("Horizontal");
        //_v = Input.GetAxisRaw("Vertical");

        _timer += Time.deltaTime;

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
        //Playerの向く方向
        Vector2 dir = _crosshair.transform.position - transform.position;
        transform.up = dir;
        //リロードの処理と効果音の再生
        if (Input.GetButton("Reload") && _ra != _ms)
        { 
            _as[3].Play();
            StartCoroutine(DelayMethod(0.6f, () =>
            {
                _as[4].Play();
            }));
            StartCoroutine(DelayMethod(1f, () =>
            {
                _ra = _ms;
            }));
        }
        if (_h != 0 || _v != 0)
        {
            _anim.SetBool("move", true);
        }
        else
        {
            _anim.SetBool("move", false);
        }
        //残弾の表示
        _raText.GetComponent<Text>().text = _ra.ToString() + "/30";

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
        else if (Input.GetButtonUp("Fire1") || _ra == 0)
        {
            _as[0].Stop();
        }
    }
    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);

        action();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && _life != 0)
        {
            _life -= 1;
        }
        if (collision.gameObject.CompareTag("Shell") && _life != 0)
        {
            _life -= 3;
        }
    }
}
