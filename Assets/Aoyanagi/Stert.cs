using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    void Start()
    {
        Invoke("ChangeScene", 1.0f);
    }
    void Update()
    {

    }
    void ChangeScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}