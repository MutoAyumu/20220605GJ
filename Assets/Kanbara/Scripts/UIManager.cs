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

    private void Start()
    {
        _panel.SetActive(false);
        GameManager.GameStart();
        GameManager.OnGameOver.AddListener(GameOver);
    }

    private void Update()
    {
        _time += Time.deltaTime;
        TimeTextUpdate();
        ScoreTextUpdate();
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
        _panel.SetActive(true);
    }
}
