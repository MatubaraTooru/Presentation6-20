using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETankTurretController : MonoBehaviour
{
    GameObject _go;
    Transform _plPos;
    // Start is called before the first frame update
    void Start()
    {
        _go = GameObject.FindGameObjectWithTag("Player");
       _plPos = _go.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = _plPos.position - transform.position;
        transform.right = dir;
    }
}
