using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    //[Header("背景の移動速度")]
    //[SerializeField]
    //float _speed;
    //[Header("ループする際のX座標")]
    //[SerializeField]
    //float _x;
    //void FixedUpdate()
    //{
    //    transform.position += Vector3.left * Time.deltaTime * _speed;
    //    if (transform.position.x < _x)
    //    {
    //        transform.position = Vector3.zero;
    //    }
    //}
    private const float k_maxLength = 1f;
    private const string k_propName = "_MainTex";

    [SerializeField]
    private Vector2 m_offsetSpeed;

    private Material m_material;

    private void Start()
    {
        if (GetComponent<SpriteRenderer>() is SpriteRenderer i)
        {
            m_material = i.material;
        }
    }

    private void Update()
    {
        if (m_material)
        {
            // xとyの値が0 ～ 1でリピートするようにする
            var x = Mathf.Repeat(Time.time * m_offsetSpeed.x, k_maxLength);
            var y = Mathf.Repeat(Time.time * m_offsetSpeed.y, k_maxLength);
            var offset = new Vector2(x, y);
            m_material.SetTextureOffset(k_propName, offset);
        }
    }

    private void OnDestroy()
    {
        // ゲームをやめた後にマテリアルのOffsetを戻しておく
        if (m_material)
        {
            m_material.SetTextureOffset(k_propName, Vector2.zero);
        }
    }
}
