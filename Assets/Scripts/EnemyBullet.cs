using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float m_initialSpeed = 5f;
    GameObject _p;
    Transform _plpos;
    // Start is called before the first frame update
    void Start()
    {
        _p = GameObject.FindGameObjectWithTag("Player");
        _plpos = _p.GetComponent<Transform>(); Vector2 dir = _plpos.position - transform.position;
        transform.up = dir;
    }
    private void FixedUpdate()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = this.transform.up * m_initialSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
