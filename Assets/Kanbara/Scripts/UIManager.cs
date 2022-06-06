using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public float Timer
    {
        get
        {
            return _time; 
        }
    }

    [SerializeField]
    [Header("リザルト画面のパネル")]
    private GameObject _panel;

    [SerializeField]
    [Header("時間を表示するテキスト")]
    private Text _timeText;

    [SerializeField]
    [Header("スコアを表示するテキスト")]
    private Text _scoreText;

    private float _time = 0f;
    private bool _isStopCount = false;

    private void Awake()
    {
        _panel.SetActive(false);
        GameManager.OnStart.AddListener(GameStart);
    }

    private void Update()
    {
        if(_isStopCount)
        {
            _time += Time.deltaTime;
        }
        TimeTextUpdate();
        ScoreTextUpdate();
        if(Input.GetMouseButton(0))
        {
            GameManager.GameStart();
        }
    }

    private void GameStart()
    {
        _isStopCount = true;
        GameManager.OnGameOver.AddListener(GameOver);
    }

    /// <summary>
    /// 時間を表示するための関数
    /// </summary>
    private void TimeTextUpdate()
    {
        int time = (int)_time;
        _timeText.text = time.ToString();
    }

    /// <summary>
    /// スコアを表示するための関数
    /// </summary>
    private void ScoreTextUpdate()
    {
        _scoreText.text = "Score : " + GameManager.Score.ToString();
    }

    private void GameOver()
    {
        _isStopCount = false;
        _panel.SetActive(true);
    }
}
