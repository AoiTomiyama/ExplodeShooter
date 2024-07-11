using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralizePowerUp : MonoBehaviour
{
    public float _itemSpeed;
    private LineRenderer _lr;
    [Header("Žæ“¾Žž‚ÌŒø‰Ê‰¹")]
    [SerializeField]
    AudioClip _clip;

    private void Start()
    {
        _lr = GetComponent<LineRenderer>();
        _lr.SetPosition(0, this.transform.position);
        transform.up = FindObjectOfType<PlayerHitbox>().transform.position - this.transform.position;
        _lr.SetPosition(1, transform.up * 50);

    }
    private void FixedUpdate()
    {
        transform.Translate(_itemSpeed * Time.deltaTime * Vector3.up);
        _itemSpeed += 0.2f;
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
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position);
            Destroy(this.gameObject);
        }
    }
    private void OnDestroy()
    {
        
    }
}
