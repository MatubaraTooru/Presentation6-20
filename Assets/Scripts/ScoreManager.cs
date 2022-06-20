using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    [Header("�X�R�A")] static int _score;

    [SerializeField]
    [Header("�X�R�AUI")] Text _scoreText;
    [SerializeField]
    [Header("�ŏI�X�R�AUI")] Text[] _fainalScoreText;

    [SerializeField]
    [Header("�n�C�X�R�A")] static int _highScore;

    [SerializeField]
    [Header("�n�C�X�R�AUI")] Text _highScoreText;
    [SerializeField]
    [Header("�ŏI�n�C�X�R�AUI")] Text[] _fainalHighScoreText;

    [SerializeField]
    [Header("�J���X�g�X�R�A")] int _maxScore = 99999;

    private void Start()
    {
        _score = 0;
        _highScoreText.text = "�n�C�X�R�A" + _highScore.ToString();
    }
    private void Update()
    {
        if (_score > _maxScore)
        {
            _score = _maxScore;
        }
        if (TimeController.Instance._isGameOver)
        {
            HighScore();
        }
        _scoreText.text = "�X�R�A" + _score.ToString();
        int l = Random.Range(0, _fainalScoreText.Length);
        _fainalScoreText[l].text ="�ŏI�X�R�A" + _score.ToString();
        int r = Random.Range(0, _fainalHighScoreText.Length);
        _fainalHighScoreText[r].text ="�n�C�X�R�A" + _highScore.ToString();
    }
    void HighScore()
    {
        if (_highScore < _score)
        {
            _highScore = _score;
            _highScoreText.text = "�n�C�X�R�A" + _highScore.ToString();
        }
    }
    public int GetScore(int getScore)
    {
        _score += getScore;
        return _score;
    }
}