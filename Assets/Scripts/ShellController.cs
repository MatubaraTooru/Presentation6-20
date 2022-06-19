using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    [SerializeField] float m_initialSpeed = 5f;
    Transform _crosshair;
    float _cTimer;
    [SerializeField] float _i;
    // Start is called before the first frame update
    void Start()
    {
        _crosshair = GameObject.FindGameObjectWithTag("Crosshair").GetComponent<Transform>();

        Vector2 dir = _crosshair.position - transform.position;
        transform.up = dir;
    }
    private void Update()
    {

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
}
