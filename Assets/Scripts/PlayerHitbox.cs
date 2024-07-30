using System.Collections;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    [Header("ダメージ食らった後の無敵時間（秒）")]
    [SerializeField]
    private float _invincibleTime;
    [Header("ダメージ食らった後のエフェクト")]
    [SerializeField]
    private GameObject _damageEffect;
    [Header("ダメージ食らった時の効果音")]
    [SerializeField]
    private AudioClip _damageClip;

    private float _timer;
    private HealthControl _healthControl;
    private SpriteRenderer _playerSr;
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
            AudioSource.PlayClipAtPoint(_damageClip, Camera.main.transform.position);
            _timer = 0;
            StartCoroutine(Invincible());
        }
    }
    private IEnumerator Invincible()
    {
        var c = _playerSr.color;
        _healthControl.RemoveOneHealth();
        Instantiate(_damageEffect, this.transform.position, Quaternion.identity);
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
