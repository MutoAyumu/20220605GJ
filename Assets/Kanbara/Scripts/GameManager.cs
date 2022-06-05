using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GameManager
{
    /// <summary>
    /// GameOver����true�ɂȂ�v���p�e�B
    /// </summary>
    public static bool IsGameOver { get; private set; }

    /// <summary>
    /// �X�R�A�̃v���p�e�B
    /// </summary>
    public static int Score { get; private set; }

    /// <summary>
    /// �Q�[���I�[�o�[���ɌĂ΂��UnityEvent
    /// �Q�[���I�[�o�[���ɌĂт����֐���o�^���邱�Ƃ��ł���
    /// �g�����@GameManager.OnGameOver.AddListener(�o�^�������֐���);
    /// </summary>
    public static UnityEvent OnGameOver = new UnityEvent();

    /// <summary>
    /// �Q�[���J�n���ɌĂ΂��֐�
    /// </summary>
    public static void GameStart()
    {
        IsGameOver = false;
        Score = 0;
        OnGameOver?.RemoveAllListeners();
    }

    /// <summary>
    /// Player�����S�����Ƃ��ɌĂ΂��֐�
    /// </summary>
    public static void GameOver()
    {
        IsGameOver = true;
        OnGameOver?.Invoke();
    }

    /// <summary>
    /// �X�R�A�����Z����Ƃ��ɌĂ΂��֐�
    /// �����ɉ��Z���������l��n��
    /// </summary>
    /// <param name="score"></param>
    public static void AddScore(int score)
    {
        Score += score;
    }
}
