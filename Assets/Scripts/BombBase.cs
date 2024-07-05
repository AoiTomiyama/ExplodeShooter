using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BombBase : MonoBehaviour
{
    [Header("”š”­ˆÐ—Í")]
    [SerializeField]
    float _explosionPower;
    [Header("”š”­”¼Œa")]
    [SerializeField]
    float _explosionRadius;
    List<GameObject> _victims = new List<GameObject>();
    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(Vector2.right * 5, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collider = gameObject.AddComponent<CircleCollider2D>();
        collider.radius = _explosionRadius;
        collider.isTrigger = true;
        Invoke(nameof(Explode), 0.1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _victims.Add(collision.gameObject);
    }
    void Explode()
    {
        if (_victims.Count > 0)
        {
            foreach (GameObject obj in _victims)
            {
                Vector2 facing = (obj.transform.position - transform.position).normalized;
                if (obj.GetComponent<Rigidbody2D>() != null)
                {
                    Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
                    rb.velocity = facing * _explosionPower;
                    Debug.Log(facing * _explosionPower);
                }
            }
        }
        Destroy(gameObject);
    }
}
