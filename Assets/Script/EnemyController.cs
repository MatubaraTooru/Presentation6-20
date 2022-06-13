using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Transform _target;
    [SerializeField] Transform _playerPositon;
    [SerializeField] float _destroyDistance = 0.05f;
    Rigidbody2D _rb;

    GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player==null)
        {
            Debug.Log("Žæ“¾‚Å‚«‚Ü‚¹‚ñ‚Å‚µ‚½");
        }
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = _player.transform.position - transform.position;
        float distance = Vector2.Distance(this.transform.position, _target.position);
        if (distance < _destroyDistance)
        {
            Destroy(gameObject);
        }
        Debug.DrawLine(_player.transform.position,gameObject.transform.position);
    }
    private void FixedUpdate()
    {
        Vector3 move = _target.position - transform.position;
        _rb.velocity = move.normalized * _speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
