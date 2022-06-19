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
    [SerializeField] GameObject _lifeText;
    EnemyTankController _tankscript;
    [SerializeField] GameObject _gameClearPanel;
    [SerializeField] float _t;
    public static TimeController Instance { get; private set; } = default;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        _playerscript = p.GetComponent<PlayerController>();
    }

    void Update()
    {
        _lifeText.GetComponent<Text>().text = _playerscript._life.ToString();

        if (_isGameOver != true)
        {
            _countTime += Time.deltaTime;

            _timeText.text = "Time" + _countTime.ToString("f1");
        }

        if (_countTime > _t)
        {
            var t = GameObject.FindGameObjectWithTag("Tank");
            _tankscript = t.GetComponent<EnemyTankController>();

            _gameObjectList[0].SetActive(false);
        }

        if (_playerscript._life == 0)
        {
            _isGameOver = true;
            _gameObjectList.ForEach(e => e.SetActive(false));
            _gameOverPanel.SetActive(true);
            Cursor.visible = true;
            var go = GameObject.FindGameObjectsWithTag("Enemy");
            if (go.Length != 0)
            {
                int i = Random.Range(0, go.Length);
                go[i].SetActive(false);
            }
        }

        if (_tankscript._life == 0)
        {
            _isGameOver = true;
            _gameObjectList.ForEach(e => e.SetActive(false));
            _gameClearPanel.SetActive(true);
            Cursor.visible = true;
            var go = GameObject.FindGameObjectsWithTag("Enemy");
            if (go.Length != 0)
            {
                int i = Random.Range(0, go.Length);
                go[i].SetActive(false);
            }
        }
    }
}
