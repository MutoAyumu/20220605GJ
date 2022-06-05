
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    /*#region//�C���X�y�N�^�[�Őݒ肷��
    //[Header("�ړ����x")] [SerializeField] public float speed;//
    [Header("�c�ړ�")] [SerializeField] public float gravity;//
    [Header("��ʊO�ł��s������")] [SerializeField] public bool nonVisibleAct;//

    [SerializeField] Transform[] _points = default;
    #endregion


    #region//�v���C�x�[�g�ϐ�
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private bool rightTleftF = false;

    int y;
    [Header("�z�u")][SerializeField]float _stopDistance;
    #endregion
    //private SpriteRenderer sr = null;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    void FixedUpdate()
    {

        float distance = Vector2.Distance(this.transform.position, _points[y].position);
        int xVector = -1;

        if(distance > _stopDistance)
        {
            
            }
        else
        {

        }
            if (rightTleftF)
            {
                xVector = 1;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
           // rb.velocity = new Vector2(xVector * speed, -gravity);
        }
       
    */
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
    
