using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankController : MonoBehaviour
{
    public int _life;
    [SerializeField] int _score;
    ScoreManager _scMa;
    [SerializeField] GameObject _shellPrefab;
    [SerializeField] Transform _muzzle;
    [SerializeField] float _tInterval;
    float _tTimer;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _mgMuzzle;
    [SerializeField] float _mgInterval;
    float _mgTimer;
    AudioSource[] _s;
    // Start is called before the first frame update
    void Start()
    {
        _scMa = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        _s = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _tTimer += Time.deltaTime;
        if (_tTimer > _tInterval)
        {
            _s[0].Play();
            Instantiate(_shellPrefab, _muzzle.position, this.transform.rotation);
            _tTimer = 0;
        }

        _mgTimer += Time.deltaTime;
        if (_mgTimer > _mgInterval)
        {
            Instantiate(_bulletPrefab, _mgMuzzle.position, transform.rotation);
            _mgTimer = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _life -= 1;
        }
        if (_life == 0)
        {
            _scMa.GetScore(_score);
            Destroy(gameObject, 0.01f);
        }
    }
}