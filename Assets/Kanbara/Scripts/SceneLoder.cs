using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoder : MonoBehaviour
{
    /// <summary>
    /// シーンを遷移するときに呼び出す関数
    /// 引数に遷移したいシーン名を渡す
    /// </summary>
    /// <param name="name"></param>
    public void LoadScene(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }
}
