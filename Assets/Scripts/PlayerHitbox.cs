using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    [Header("ダメージ食らった後の無敵時間（秒）")]
    [SerializeField]
    float _invincibleTime;
    float _timer;
    HealthControl _healthControl;
    SpriteRenderer _playerSr;
    private void Start()
    {
        _playerSr = GetComponent<SpriteRenderer>();
        _healthControl = FindObjectOfType<HealthControl>();
        _timer += _invincibleTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Block") && _timer >= _invincibleTime)
        {
            _timer = 0;
            StartCoroutine(Invincible());
        }
    }
    private IEnumerator Invincible()
    {
        var c = _playerSr.color;
        _healthControl.RemoveOneHealth();
        while (_timer < _invincibleTime)
        {
            _timer += 0.2f;
            c.a = 1 - c.a;
            _playerSr.color = c;
            yield return new WaitForSeconds(0.2f);
        }
        c.a = 1;
        _playerSr.color = c;
    }
}
