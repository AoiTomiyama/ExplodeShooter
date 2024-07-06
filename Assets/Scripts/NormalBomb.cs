using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBomb : MonoBehaviour
{
    [Header("爆発威力")]
    [SerializeField]
    float _explosionPower;
    [Header("爆発半径")]
    [SerializeField]
    float _explosionRadius;
    [Header("爆発エフェクト")]
    [SerializeField]
    GameObject _explosionEffect;
    List<GameObject> _victims = new List<GameObject>();
    Rigidbody2D _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(Vector2.right, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collider = gameObject.AddComponent<CircleCollider2D>();
        collider.radius = _explosionRadius;
        collider.isTrigger = true;
        Invoke(nameof(Explosion), Time.deltaTime);
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
                Vector2 facing = (obj.transform.position - transform.position).normalized;
                Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
                rb.velocity = facing * _explosionPower;
            }
            Instantiate(_explosionEffect, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
