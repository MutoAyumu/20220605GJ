using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoder : MonoBehaviour
{
    /// <summary>
    /// �V�[����J�ڂ���Ƃ��ɌĂяo���֐�
    /// �����ɑJ�ڂ������V�[������n��
    /// </summary>
    /// <param name="name"></param>
    public void LoadScene(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }
}
