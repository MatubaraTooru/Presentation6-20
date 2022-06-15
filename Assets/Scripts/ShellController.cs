using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    [SerializeField] float m_initialSpeed = 5f;
    [SerializeField] Transform _crosshair;
    float _cTimer;
    [SerializeField] float _i;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        _cTimer += Time.deltaTime;
        if (_cTimer == _i)
        {
            findCrosshairPotision();
            _cTimer = 0;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = this.transform.up * m_initialSpeed;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    void findCrosshairPotision()
    {
        Vector2 dir = _crosshair.position - transform.position;
        transform.up = dir;
    }
}
