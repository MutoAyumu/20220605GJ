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

    /// <summary>
    /// ゲームオーバー時に呼ばれるUnityEvent
    /// ゲームオーバー時に呼びたい関数を登録することができる
    /// 使い方　GameManager.OnGameOver.AddListener(登録したい関数名);
    /// </summary>
    public static UnityEvent OnGameOver = new UnityEvent();

    /// <summary>
    /// ゲーム開始時に呼ばれる関数
    /// </summary>
    public static void GameStart()
    {
        IsGameOver = false;
        Score = 0;
        OnGameOver?.RemoveAllListeners();
    }

    /// <summary>
    /// Playerが死亡したときに呼ばれる関数
    /// </summary>
    public static void GameOver()
    {
        IsGameOver = true;
        OnGameOver?.Invoke();
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
