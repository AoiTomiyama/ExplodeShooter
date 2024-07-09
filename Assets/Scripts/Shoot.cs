using System.Collections;
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
    public IEnumerator ReduceCooldown(float duratoin)
    {
        _cooldownTime /= 2;
        yield return new WaitForSeconds(duratoin);
        RemoveCooldownPower();
    }
    public void RemoveCooldownPower()
    {
        _cooldownTime *= 2;
    }
}
