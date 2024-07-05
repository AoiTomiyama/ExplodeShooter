using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("移動速度")]
    [SerializeField]
    float _moveSpeed = 5f;
    /// <summary>上下と左右の入力</summary>
    float _h, _v;
    void Start()
    {
        
    }

    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(_h, _v) * _moveSpeed * Time.deltaTime);
    }
}
