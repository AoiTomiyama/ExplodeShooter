using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject block;
    [SerializeField]
    int sizeY = 5;
    [SerializeField]
    int sizeX = 5;
    private void Start()
    {
        SetBlock();
    }
    void SetBlock()
    {
        for (int i = 0; i < sizeY; i++)
        {
            for (int j = 0; j < sizeX; j++)
            {
                var pos = this.transform.position + Vector3.up * i * block.transform.localScale.y + Vector3.right * j * block.transform.localScale.x;
                Instantiate(block, pos, Quaternion.identity);
            }
        }
    }
}
