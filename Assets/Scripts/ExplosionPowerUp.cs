using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPowerUp : PowerUpItemBase
{
    [Header("��������{��")]
    [SerializeField]
    float _multiply;
    public override void PowerUp()
    {
        FindObjectOfType<Shoot>().GetComponent<Shoot>().IncreaseExplodePower(_multiply);
    }
}
