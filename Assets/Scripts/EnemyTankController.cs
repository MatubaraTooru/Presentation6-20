using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankController : MonoBehaviour
{
    [SerializeField] float _speed;
    GameObject[] _targets;
    Rigidbody2D _rb;
    Transform _tgpos;
    GameObject _player;
    Vector3 _move;
    float _timer;
    [SerializeField] float _destroyTime;
    [SerializeField] int _life;
    [SerializeField] int _score;
    ScoreManager _scMa;
    // Start is called before the first frame update
    void Start()
    {
        _targets = GameObject.FindGameObjectsWithTag("Target");

        _rb = gameObject.GetComponent<Rigidbody2D>();

        int i = Random.Range(0, _targets.Length);
        _tgpos = _targets[i].gameObject.GetComponent<Transform>();

        _move = _tgpos.position - transform.position;

        _scMa = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _destroyTime)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {

        _rb.velocity = _move.normalized * _speed;
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
            Destroy(gameObject);
        }
    }
}