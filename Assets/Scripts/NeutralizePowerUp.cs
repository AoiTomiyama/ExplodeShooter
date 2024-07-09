using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralizePowerUp : MonoBehaviour
{
    public float _itemSpeed;
    private void FixedUpdate()
    {
        transform.Translate(_itemSpeed * Time.deltaTime * Vector3.left);
        if (transform.position.x < -30)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" )
        {
            if (FindObjectOfType<Shoot>()._powerUpList.Count != 0)
            {
                foreach (PowerUpItemBase item in FindObjectOfType<Shoot>()._powerUpList)
                {
                    item.RemovePowerUp();
                }
            }
            Destroy(this.gameObject);
        }
    }
}
