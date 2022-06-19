using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    [Header("Œo‰ßŽžŠÔ"), SerializeField] float _countTime;
    [SerializeField] Text _timeText;
    [SerializeField] List<GameObject> _gameObjectList;
    [SerializeField] GameObject _gameOverPanel;
    public bool _isGameOver;
    public bool _isLast;
    PlayerController _playerscript;
    public static TimeController Instance { get; private set; } = default;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        var p = GameObject.Find("Player");
        _playerscript = p.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (_isGameOver != true)
        {
            _countTime += Time.deltaTime;

            _timeText.text = "Time" + _countTime.ToString("f1");
        }

        if (_playerscript._life == 0)
        {
            _isGameOver = true;
            _gameObjectList.ForEach(e => e.SetActive(false));
        }
    }
}
