using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _muzzle;
    [SerializeField] float _interval;
    float _timer;
    AudioSource _s;
    // Start is called before the first frame update
    void Start()
    {
        _s = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _interval)
        {
            _s.Play();
            Instantiate(_bulletPrefab, _muzzle.position, this.transform.rotation);
            _timer = 0;
        }
    }
}
