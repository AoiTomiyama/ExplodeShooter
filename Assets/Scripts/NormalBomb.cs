using System.Collections.Generic;
using UnityEngine;

public class NormalBomb : MonoBehaviour
{
    [Header("爆発エフェクト")]
    [SerializeField]
    GameObject _explosionEffect;
    [Header("爆発時の効果音")]
    [SerializeField]
    AudioClip _clip;
    private float _power;
    private float _r;
    List<GameObject> _victims = new();
    Rigidbody2D _rb;

    public float Power { set => _power = value; }
    public float R { set => _r = value; }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "Player" && collision.gameObject.name != this.gameObject.name)
        {
            var collider = gameObject.AddComponent<CircleCollider2D>();
            collider.radius = _r;
            collider.isTrigger = true;
            var effect = Instantiate(_explosionEffect, this.transform.position, Quaternion.identity);
            effect.transform.localScale = Vector3.one * _r;
            Invoke(nameof(Explosion), Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>() != null && collision.gameObject.name.Contains("Block"))
        {
            _victims.Add(collision.gameObject);
        }
    }
    private void Explosion()
    {
        if (_victims.Count > 0)
        {
            foreach (GameObject obj in _victims)
            {
                if (obj != null)
                {
                    Vector2 direction = (obj.transform.position - transform.position).normalized;
                    Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
                    if (rb.bodyType == RigidbodyType2D.Kinematic)
                    {
                        //Destroy(obj);
                        rb.velocity = direction * _power;
                    }
                    else if (rb.bodyType == RigidbodyType2D.Dynamic)
                    {
                        rb.AddForce(direction * _power, ForceMode2D.Impulse);
                    }
                }
            }
        }
        AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position);
        Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
