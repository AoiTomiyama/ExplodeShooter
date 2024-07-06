using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpItemBase : MonoBehaviour
{
    [Header("�p���[�A�b�v�p������")]
    [SerializeField]
    float _duration;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.name == "Player")
        {
            PowerUp();
            Destroy(this.gameObject);
        }
    }
    public abstract void PowerUp();
}
