using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField, Tooltip("�|�C���g")] Transform[] _points = default;
    [SerializeField, Tooltip("�X�s�[�h")] float _moveSpeed = 1f;
    [SerializeField, Tooltip("�ړ����؂�ւ���Ƃ��̃|�C���g�Ƃ̋���")] float _stopDistance = 0.2f;
    [SerializeField, Tooltip("�N���p�̃t���O")] bool isLaunch;

    Vector3 _move;
    int _count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, _points[_count].position);

        if (distance > _stopDistance)
        {
            _move = (_points[_count].transform.position - this.transform.position);
            this.transform.Translate(_move.normalized * _moveSpeed * Time.deltaTime);
        }
        else
        {
            _count = (_count + 1) % _points.Length;
        }
    }
}
