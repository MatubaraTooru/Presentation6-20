using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // —N‚­“G
    [SerializeField] GameObject[] _enemies;
    // “G‚ª—N‚­üŠú
    [SerializeField] float _minDistance;
    [SerializeField] float _maxDistance;

    IEnumerator _spawn;

    void Start()
    {
        _spawn = Spawn();
        StartSpawn();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) EndSpawn();
    }

    // “G‚ÌƒXƒ|[ƒ“ŠJn
    public void StartSpawn() => StartCoroutine(_spawn);
    // “G‚ÌƒXƒ|[ƒ“I—¹
    public void EndSpawn() => StopCoroutine(_spawn);

    // “G‚ğƒXƒ|[ƒ“‚³‚¹‚é
    IEnumerator Spawn()
    {
        while (true)
        {
            float distance = Random.Range(_minDistance, _maxDistance + 1);
            yield return new WaitForSecondsRealtime(distance);
            int r = Random.Range(0, _enemies.Length);
            Instantiate(_enemies[r], transform.position, Quaternion.identity);
        }
    }
}
