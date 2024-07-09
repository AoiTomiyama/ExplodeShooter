using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ObjectDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
