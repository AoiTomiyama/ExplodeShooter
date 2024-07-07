using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnGenerator : MonoBehaviour
{
    [Header("ブロックパターン、またはブロック生成機を入れる")]
    [SerializeField]
    GameObject _column;
    [Header("何秒おきに生成するか")]
    [SerializeField]
    private float _timeOfGenerate;
    [Header("柱の移動速度")]
    [SerializeField]
    private float _wallSpeed;
    private float _timeOfGeneration;
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
            _timeOfGeneration -= 0.1f;
        }
    }
}
