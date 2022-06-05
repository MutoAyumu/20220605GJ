
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    /*#region//インスペクターで設定する
    //[Header("移動速度")] [SerializeField] public float speed;//
    [Header("縦移動")] [SerializeField] public float gravity;//
    [Header("画面外でも行動する")] [SerializeField] public bool nonVisibleAct;//

    [SerializeField] Transform[] _points = default;
    #endregion


    #region//プライベート変数
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private bool rightTleftF = false;

    int y;
    [Header("配置")][SerializeField]float _stopDistance;
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
    [SerializeField, Tooltip("ポイント")] Transform[] _points = default;
    [SerializeField, Tooltip("スピード")] float _moveSpeed = 1f;
    [SerializeField, Tooltip("移動先を切り替えるときのポイントとの距離")] float _stopDistance = 0.2f;
    [SerializeField, Tooltip("起動用のフラグ")] bool isLaunch;

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
    
