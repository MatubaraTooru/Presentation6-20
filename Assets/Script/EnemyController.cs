using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Transform[] _targets;
    [SerializeField] Transform _playerPositon;
    [SerializeField] float _stoppingDistance = 0.05f;
    int _currentTargetIndex = 0;
    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = _playerPositon.position - transform.position;
    }
    private void FixedUpdate()
    {
        float distans = Vector2.Distance(transform.position, _targets[_currentTargetIndex].position);
        if (distans > _stoppingDistance)
        {
            Vector3 move = _targets.position - transform.position;
            _rb.velocity = move.normalized * _speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
