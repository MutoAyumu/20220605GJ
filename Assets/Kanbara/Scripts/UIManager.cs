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
    [Header("���U���g��ʂ̃p�l��")]
    private GameObject _panel;

    [SerializeField]
    [Header("���Ԃ�\������e�L�X�g")]
    private Text _timeText;

    [SerializeField]
    [Header("�X�R�A��\������e�L�X�g")]
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
    /// ���Ԃ�\�����邽�߂̊֐�
    /// </summary>
    private void TimeTextUpdate()
    {
        int time = (int)_time;
        _timeText.text = time.ToString();
    }

    /// <summary>
    /// �X�R�A��\�����邽�߂̊֐�
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
