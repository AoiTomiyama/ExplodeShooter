using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("”š”­ˆÐ—Í")]
    [SerializeField]
    float _explosionPower;
    [Header("”š”­”¼Œa")]
    [SerializeField]
    float _explosionRadius;
    [SerializeField]
    GameObject _bullet;
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var scr = Instantiate(_bullet, transform.position, Quaternion.identity).GetComponent<NormalBomb>();
            scr._power = this._explosionPower;
            scr._r = this._explosionRadius;
        }
    }
    public void IncreaseExplodePower(float power)
    {
        _explosionPower *= power;
        _explosionRadius *= power;
    }
}
