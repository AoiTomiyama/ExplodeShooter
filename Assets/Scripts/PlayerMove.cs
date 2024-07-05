using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("à⁄ìÆë¨ìx")]
    [SerializeField]
    float _moveSpeed = 5f;
    /// <summary>è„â∫Ç∆ç∂âEÇÃì¸óÕ</summary>
    float _h, _v;
    void Start()
    {
        
    }

    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (_h != 0 || _v != 0)
        {
            float lineLengthVertical = 0.5f;
            float lineLengthHorizontal = 1f;
            var hitLeft = Physics2D.Linecast(transform.position, transform.position + Vector3.left * lineLengthHorizontal);
            var hitRight = Physics2D.Linecast(transform.position, transform.position + Vector3.right * lineLengthHorizontal);
            var hitUp = Physics2D.Linecast(transform.position, transform.position + Vector3.up * lineLengthVertical);
            var hitDown = Physics2D.Linecast(transform.position, transform.position + Vector3.down * lineLengthVertical);
            Debug.DrawLine(this.transform.position + Vector3.left * lineLengthHorizontal, this.transform.position + Vector3.right * lineLengthHorizontal);
            Debug.DrawLine(this.transform.position + Vector3.up * lineLengthVertical, this.transform.position + Vector3.down * lineLengthVertical);
            if (hitLeft && _h < 0) _h = 0;
            if (hitRight && _h > 0) _h = 0;
            if (hitDown && _v < 0) _v = 0;
            if (hitUp && _v > 0) _v = 0;
            transform.Translate(new Vector2(_h, _v) * _moveSpeed * Time.deltaTime);
        }
    }
}
