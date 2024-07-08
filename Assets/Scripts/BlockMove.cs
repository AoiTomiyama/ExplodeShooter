using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    private float _wallSpeed = 1;
    public float WallSpeed { set => _wallSpeed = value; }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _wallSpeed);
        if (transform.position.x < -25)
        {
            Destroy(this.gameObject);
        }
    }
}
