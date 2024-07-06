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
                var pos = new Vector2(this.transform.position.x + j * block.transform.localScale.x * 1.05f, this.transform.position.y + i * block.transform.localScale.y);
                var go = Instantiate(block, pos, Quaternion.identity, transform);
                go.name = block.name + "_" + (sizeX * i + j);
                //go.GetComponent<Rigidbody2D>().mass = sizeX * sizeY - (sizeX * i + j);
            }
        }
    }
}
