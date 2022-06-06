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

    private static bool _canGameStart = false;

    /// <summary>
    /// �Q�[���J�n���ɌĂ΂��UnityEvent
    /// �Q�[���J�n���ɌĂт����֐���o�^���邱�Ƃ��ł���
    /// �g�����@GameManager.OnStart.AddListner(�o�^�������֐���);
    /// </summary>
    public static UnityEvent OnStart = new UnityEvent();

    /// <summary>
    /// �Q�[���I�[�o�[���ɌĂ΂��UnityEvent
    /// �Q�[���I�[�o�[���ɌĂт����֐���o�^���邱�Ƃ��ł���
    /// �g�����@GameManager.OnGameOver.AddListener(�o�^�������֐���);
    /// </summary>
    public static UnityEvent OnGameOver = new UnityEvent();
    
    /// <summary>
    /// �Q�[���J�n�\�ɂ�����s�\�ɂ�����ł���֐�
    /// </summary>
    /// <param name="flag"></param>
    public static void CanGameStart(bool flag = true)
    {
        _canGameStart = flag;
    }

    /// <summary>
    /// �Q�[���J�n���ɌĂ΂��֐�
    /// </summary>
    public static void GameStart()
    {
        if (!_canGameStart) return;
        IsGameOver = false;
        Score = 0;
        OnGameOver?.RemoveAllListeners();
        OnStart?.Invoke();
        _canGameStart = false;
    }

    /// <summary>
    /// Player�����S�����Ƃ��ɌĂ΂��֐�
    /// </summary>
    public static void GameOver()
    {
        IsGameOver = true;
        OnGameOver?.Invoke();
        OnStart?.RemoveAllListeners();
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
