using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColumnGenerator : MonoBehaviour
{
    [Header("�u���b�N�p�^�[���A�܂��̓u���b�N�����@������")]
    [SerializeField]
    GameObject[] _columns;
    [Header("���b�����ɐ������邩")]
    [SerializeField]
    private float _timeOfGenerate;
    [Header("���̈ړ����x")]
    [SerializeField]
    private float _wallSpeed;
    private float _time;
    private float _elapsedTime;
    private Text _recordText;
    private void Start()
    {
        _time = _timeOfGenerate;
        _recordText = GameObject.Find("Record").GetComponent<Text>();
    }
    void Update()
    {
        if (_time < _timeOfGenerate)
        {
            _time += Time.deltaTime;
        }
        if (_time >= _timeOfGenerate)
        {
            var go = Instantiate(_columns[Random.Range(0, _columns.Length)], transform.position, Quaternion.identity);
            go.GetComponent<BlockMove>().WallSpeed = _wallSpeed;
            _time = 0;
            _wallSpeed += 0.1f;
            if (_timeOfGenerate > 1f) _timeOfGenerate -= 0.05f;
        }
    }
    private void FixedUpdate()
    {
        _elapsedTime += (_wallSpeed + _timeOfGenerate) / 200;
        _recordText.text = _elapsedTime.ToString("F2") + "m";
    }
}
