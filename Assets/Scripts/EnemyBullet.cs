using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float m_initialSpeed = 5f;
    GameObject _p;
    Transform _plpos;
    float _cTimer;
    [SerializeField] float _i;
    // Start is called before the first frame update
    void Start()
    {
        _p = GameObject.FindGameObjectWithTag("Player");
        _plpos = _p.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _cTimer += Time.deltaTime;
        if (_cTimer == _i)
        {
            FindPlayerPosition();
            _cTimer = 0;
        }
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
    public void FindPlayerPosition ()
    {
        Vector2 dir = _plpos.position - transform.position;
        transform.up = dir;
    }
}
