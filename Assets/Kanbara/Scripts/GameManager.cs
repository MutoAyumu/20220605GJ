using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GameManager
{
    /// <summary>
    /// GameOver時にtrueになるプロパティ
    /// </summary>
    public static bool IsGameOver { get; private set; }

    /// <summary>
    /// スコアのプロパティ
    /// </summary>
    public static int Score { get; private set; }

    private static bool _canGameStart = false;

    /// <summary>
    /// ゲーム開始時に呼ばれるUnityEvent
    /// ゲーム開始時に呼びたい関数を登録することができる
    /// 使い方　GameManager.OnStart.AddListner(登録したい関数名);
    /// </summary>
    public static UnityEvent OnStart = new UnityEvent();

    /// <summary>
    /// ゲームオーバー時に呼ばれるUnityEvent
    /// ゲームオーバー時に呼びたい関数を登録することができる
    /// 使い方　GameManager.OnGameOver.AddListener(登録したい関数名);
    /// </summary>
    public static UnityEvent OnGameOver = new UnityEvent();
    
    /// <summary>
    /// ゲーム開始可能にしたり不可能にしたりできる関数
    /// </summary>
    /// <param name="flag"></param>
    public static void CanGameStart(bool flag = true)
    {
        _canGameStart = flag;
    }

    /// <summary>
    /// ゲーム開始時に呼ばれる関数
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
    /// Playerが死亡したときに呼ばれる関数
    /// </summary>
    public static void GameOver()
    {
        IsGameOver = true;
        OnGameOver?.Invoke();
        OnStart?.RemoveAllListeners();
    }

    /// <summary>
    /// スコアを加算するときに呼ばれる関数
    /// 引数に加算したい数値を渡す
    /// </summary>
    /// <param name="score"></param>
    public static void AddScore(int score)
    {
        Score += score;
    }
}
