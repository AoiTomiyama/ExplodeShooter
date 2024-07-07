using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnGenerator : MonoBehaviour
{
    [Header("�u���b�N�p�^�[���A�܂��̓u���b�N�����@������")]
    [SerializeField]
    GameObject _column;
    [Header("���b�����ɐ������邩")]
    [SerializeField]
    private float _timeOfGenerate;
    [Header("���̈ړ����x")]
    [SerializeField]
    private float _wallSpeed;
    private float _time;
    private void Start()
    {
        _time = _timeOfGenerate;
    }
    void Update()
    {
        if (_time < _timeOfGenerate)
        {
            _time += Time.deltaTime;
        }
        if (_time >= _timeOfGenerate)
        {
            var go = Instantiate(_column, transform.position, Quaternion.identity);
            go.GetComponent<BlockGenerator>().WallSpeed = _wallSpeed;
            _time = 0;
            _wallSpeed += 0.1f;
            if (_timeOfGenerate > 1f) _timeOfGenerate -= 0.05f;
        }
    }
}
