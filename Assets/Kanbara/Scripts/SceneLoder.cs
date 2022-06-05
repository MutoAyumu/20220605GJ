using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class SceneLoder : MonoBehaviour
{
    [SerializeField]
    RectTransform _unmaskImage;
    private void Start()
    {
        _unmaskImage.localScale = Vector3.zero;
        _unmaskImage.DORotate(new Vector3(0f, 0f, 360f), 1f, RotateMode.FastBeyond360).SetEase(Ease.InQuad);

        var sequence = DOTween.Sequence();
        sequence.Append(_unmaskImage.DOScale(new Vector3(3f, 3f, 0f), 1f).SetEase(Ease.Linear));
        sequence.AppendInterval(0.5f);
        sequence.Append(_unmaskImage.DOScale(new Vector3(10f ,10f ,0f) , 1f).SetEase(Ease.Linear));
    }

    /// <summary>
    /// �V�[����J�ڂ���Ƃ��ɌĂяo���֐�
    /// �����ɑJ�ڂ������V�[������n��
    /// </summary>
    /// <param name="name"></param>
    public void LoadScene(string name)
    {
        _unmaskImage.DORotate(new Vector3(0f, 0f, 360f), 1f, RotateMode.FastBeyond360).SetEase(Ease.InQuad);

        var sequence = DOTween.Sequence();
        sequence.Append(_unmaskImage.DOScale(new Vector3(3f, 3f, 0f), 1f).SetEase(Ease.Linear));
        sequence.AppendInterval(0.5f);
        sequence.Append(_unmaskImage.DOScale(Vector3.zero, 1f).SetEase(Ease.Linear))
            .OnComplete(() =>
            {
                SceneManager.LoadSceneAsync(name);
            });
    }
}
