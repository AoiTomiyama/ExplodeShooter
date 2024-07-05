using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("�ړ����x")]
    [SerializeField]
    float _moveSpeed = 5f;
    /// <summary>�㉺�ƍ��E�̓���</summary>
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
