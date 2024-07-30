using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    [Header("�����З�")]
    public float _explosionPower;
    [Header("�������a")]
    public float _explosionRadius;
    [Header("�N�[���_�E��")]
    public float _cooldownTime = 3;
    [SerializeField]
    GameObject _bullet;
    [SerializeField]
    Slider _cooldownSlider;

    float time;
    public List<PowerUpItemBase> _powerUpList = new();
    private void Update()
    {
        if (time < _cooldownTime)
        {
            time += Time.deltaTime;
            _cooldownSlider.value = time / _cooldownTime;
        }
        if (time >= _cooldownTime)
        {
            var scr = Instantiate(_bullet, transform.position, Quaternion.identity).GetComponent<NormalBomb>();
            scr.Power = _explosionPower;
            scr.R = _explosionRadius;
            time = 0;
        }
    }
}
