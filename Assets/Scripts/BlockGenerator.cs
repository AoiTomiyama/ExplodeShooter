using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BlockGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] _blocks;
    [SerializeField]
    int _sizeY = 5;
    [SerializeField]
    int _sizeX = 5;
    [SerializeField]
    int _secondBlockHeight = 1;
    [SerializeField]
    int _secondBlockStartY = 3;

    private void Start()
    {
        _secondBlockStartY += Random.Range(0, 10);
        SetBlock();
    }
    void SetBlock()
    {
        for (int i = 0; i < _sizeY; i++)
        {
            for (int j = 0; j < _sizeX; j++)
            {
                GameObject block = null;
                if (i >= _secondBlockStartY - 1 && i < _secondBlockStartY + _secondBlockHeight - 1)
                {
                    block = _blocks[1];
                }
                else
                {
                    block = _blocks[0];
                }
                var pos = new Vector2(this.transform.position.x + j * block.transform.localScale.x, this.transform.position.y + i * block.transform.localScale.y);
                var go = Instantiate(block, pos, Quaternion.identity, transform);
                go.name = block.name + "_" + (_sizeX * i + j);
            }
        }
    }
}
