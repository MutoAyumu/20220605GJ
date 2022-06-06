
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    
    [SerializeField, Tooltip("ポイント")] Transform[] _points = default;
    [SerializeField, Tooltip("スピード")] float _moveSpeed = 1f;
    [SerializeField, Tooltip("移動先を切り替えるときのポイントとの距離")] float _stopDistance = 0.2f;
    [SerializeField, Tooltip("起動用のフラグ")] bool isLaunch;
    //[SerializeField, Tooltip("倒された時のエフェクト")] GameObject e_effectPrefab = default;

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
    
