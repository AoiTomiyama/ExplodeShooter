using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("à⁄ìÆë¨ìx")]
    [SerializeField]
    float _moveSpeed = 5f;
    /// <summary>è„â∫Ç∆ç∂âEÇÃì¸óÕ</summary>
    float _h, _v;
    private BoxCollider2D _collider;
    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        var playerDownLeft = (Vector2)this.transform.position - _collider.size / 2;
        var playerUpRight = (Vector2)this.transform.position + _collider.size / 2;
        var screenDownLeft = -Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        var screenUpRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        if (playerDownLeft.x < screenDownLeft.x && _h < 0) _h = 0;
        if (playerDownLeft.y < screenDownLeft.y && _v < 0) _v = 0;
        if (playerUpRight.x > screenUpRight.x && _h > 0) _h = 0;
        if (playerUpRight.y > screenUpRight.y && _v > 0) _v = 0;
        transform.Translate(_moveSpeed * Time.deltaTime * new Vector2(_h, _v).normalized);
    }
}
