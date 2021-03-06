using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
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
        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player==null)
        {
            Debug.Log("取得できませんでした");
        }

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
        transform.up = _player.transform.position - transform.position;
        Debug.DrawLine(_player.transform.position,gameObject.transform.position);
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
