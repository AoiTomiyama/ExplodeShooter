using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject _block;
    [SerializeField]
    int _sizeY = 5;
    [SerializeField]
    int _sizeX = 5;
    private void Start()
    {
        SetBlock();
    }
    void SetBlock()
    {
        for (int i = 0; i < _sizeY; i++)
        {
            for (int j = 0; j < _sizeX; j++)
            {
                var pos = new Vector2(this.transform.position.x + j * _block.transform.localScale.x, this.transform.position.y + i * _block.transform.localScale.y);
                var go = Instantiate(_block, pos, Quaternion.identity, transform);
                go.name = _block.name + "_" + (_sizeX * i + j);
            }
        }
    }
}
