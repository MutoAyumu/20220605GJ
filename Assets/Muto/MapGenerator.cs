using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("生成するマップのプレハブ")] GameObject[] _maps;
    List<GameObject> _mapsList = new List<GameObject>();
    [SerializeField, Tooltip("生成位置の間隔")] float _width = 10f;

    [SerializeField, Tooltip("生成する親オブジェクト")] GameObject _grid;

    [SerializeField, Tooltip("ログを表示する用のフラグ")] bool _isDebugLog;
    int _count = 2;

    private void Start()
    {
        _mapsList.Add(Instantiate(_maps[0], _grid.transform));
        _mapsList.Add(Instantiate(_maps[Random.Range(1,_maps.Length)], new Vector2(_width, 0), Quaternion.identity, _grid.transform));
        _mapsList.Add(Instantiate(_maps[Random.Range(1,_maps.Length)], new Vector2(_width * _count , 0),Quaternion.identity, _grid.transform));
    }
    public void GenerateStage()
    {
        _count++;
        _mapsList.Add(Instantiate(_maps[Random.Range(1, _maps.Length)], new Vector2(_width * _count, 0), Quaternion.identity, _grid.transform));
        DestroyStage();
    }
    void DestroyStage()
    {
        if (_isDebugLog)
            Debug.Log($"破棄された : {_mapsList[0]}");

        Destroy(_mapsList[0]);
        _mapsList.RemoveAt(0);
    }
}
