using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    [SerializeField] float m_initialSpeed = 5f;
    [SerializeField] Transform _crosshair;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 dir = _crosshair.position - transform.position;
        transform.up = dir;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = this.transform.up * m_initialSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
