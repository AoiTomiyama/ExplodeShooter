using UnityEngine;

public class NeutralizePowerUp : MonoBehaviour
{
    public float _itemSpeed;
    private LineRenderer _lr;
    [Header("取得時の効果音")]
    [SerializeField]
    AudioClip _clip;

    private void Start()
    {
        _lr = GetComponent<LineRenderer>();
        var direction = GameObject.Find("Player").transform.position - this.transform.position;
        _lr.SetPosition(0, this.transform.position);
        _lr.SetPosition(1, direction * 10);
        transform.up = direction.normalized;

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
        if (collision.gameObject.name == "Player")
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
}
