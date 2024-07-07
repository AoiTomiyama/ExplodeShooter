using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    [Header("�����З�")]
    [SerializeField]
    float _explosionPower;
    [Header("�������a")]
    [SerializeField]
    float _explosionRadius;
    [Header("�N�[���_�E��")]
    [SerializeField]
    float _cooldownTime = 3;
    [SerializeField]
    GameObject _bullet;
    [SerializeField]
    Slider _cooldownSlider;

    float time;
    private void Update()
    {
        if (time < _cooldownTime)
        {
            time += Time.deltaTime;
            _cooldownSlider.value = time / _cooldownTime;
        }
        if (Input.GetButtonDown("Fire1") && time >= _cooldownTime)
        {
            var scr = Instantiate(_bullet, transform.position, Quaternion.identity).GetComponent<NormalBomb>();
            scr._power = this._explosionPower;
            scr._r = this._explosionRadius;
            time = 0;
        }
    }
    public void IncreaseExplodePower(float power)
    {
        _explosionPower *= power;
        _explosionRadius *= power;
    }
}
