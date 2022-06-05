using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("��������}�b�v�̃v���n�u")] GameObject[] _maps;
    List<GameObject> _mapsList = new List<GameObject>();
    [SerializeField, Tooltip("�����ʒu�̊Ԋu")] float _width = 10f;

    [SerializeField, Tooltip("��������e�I�u�W�F�N�g")] GameObject _grid;

    [SerializeField, Tooltip("���O��\������p�̃t���O")] bool _isDebugLog;
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
            Debug.Log($"�j�����ꂽ : {_mapsList[0]}");

        Destroy(_mapsList[0]);
        _mapsList.RemoveAt(0);
    }
}
