using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RapidshotPowerUp : PowerUpItemBase
{
    public override void PowerUp(float duration)
    {
        StartCoroutine(FindObjectOfType<Shoot>().GetComponent<Shoot>().ReduceCooldown(duration));
    }
}
