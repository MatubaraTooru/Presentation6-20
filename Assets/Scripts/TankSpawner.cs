using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] float _spawntime;
    [SerializeField] GameObject _sObject;
    float _time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _time += Time.deltaTime;

        if (_time >= _spawntime && _time < _spawntime + 0.02)
        {
            Instantiate(_sObject, transform.position, Quaternion.identity);
        }
    }
}
