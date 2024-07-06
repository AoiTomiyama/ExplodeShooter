using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpItemBase : MonoBehaviour
{
    [Header("パワーアップ継続時間")]
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
