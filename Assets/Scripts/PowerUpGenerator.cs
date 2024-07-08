using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGenerator : MonoBehaviour
{
    [Header("パワーアップを入れる")]
    [SerializeField]
    GameObject[] _items;
    [Header("何秒おきに生成するか")]
    [SerializeField]
    private float _timeOfGenerate;
    private float _speed = 1;
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
            var go = Instantiate(_items[Random.Range(0, _items.Length)], transform.position, Quaternion.identity);
            go.GetComponent<PowerUpItemBase>().ItemSpeed = _speed;
            _time = 0;
            _speed += 0.1f;
            _timeOfGenerate += 0.1f;
            this.transform.position = new Vector2(transform.position.x, Random.Range(-4.5f, 4.5f));
        }
    }
}
