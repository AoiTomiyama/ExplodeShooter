using UnityEngine;

public class PowerUpGenerator : MonoBehaviour
{
    [Header("パワーアップを入れる")]
    [SerializeField]
    GameObject[] _items;
    [Header("何秒おきに生成するか")]
    [SerializeField]
    private float _timeOfGenerate;
    private float _speed = 3;
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
            if (go.TryGetComponent<PowerUpItemBase>(out var scr))
            {
                scr._itemSpeed = _speed;
            }
            else
            {
                go.GetComponent<NeutralizePowerUp>()._itemSpeed = _speed;
            }
            _time = 0;
            _speed += 0.1f;
            this.transform.position = new Vector2(transform.position.x, Random.Range(-4.5f, 4.5f));
        }
    }
}
