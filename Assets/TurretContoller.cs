using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretContoller : MonoBehaviour
{
    [SerializeField] Transform _crosshair;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = _crosshair.position - transform.position;
        transform.up = dir;
    }
}
