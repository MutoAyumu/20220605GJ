
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    
    [SerializeField, Tooltip("�|�C���g")] Transform[] _points = default;
    [SerializeField, Tooltip("�X�s�[�h")] float _moveSpeed = 1f;
    [SerializeField, Tooltip("�ړ����؂�ւ���Ƃ��̃|�C���g�Ƃ̋���")] float _stopDistance = 0.2f;
    [SerializeField, Tooltip("�N���p�̃t���O")] bool isLaunch;
    //[SerializeField, Tooltip("�|���ꂽ���̃G�t�F�N�g")] GameObject e_effectPrefab = default;

    Vector3 _move;
    int _count;
           
    void Update()
    {
        if (_points.Length == 0)
        {
            return;
        }
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

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            if (e_effectPrefab)
            {
                Instantiate(e_effectPrefab, this.transform.position, this.transform.rotation);
            }

          
            Destroy(this.gameObject);
        }
    }*/
}
    
