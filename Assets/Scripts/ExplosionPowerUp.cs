using UnityEngine;
/// <summary>
/// 弾の威力（爆発範囲・吹き飛ばす力）を倍率に応じて強化するパワーアップ。
/// </summary>
public class ExplosionPowerUp : PowerUpItemBase
{
    [Header("強化する倍率")]
    [SerializeField]
    float _multiply;
    public override void PowerUp()
    {
        _shootMuzzle._explosionPower *= _multiply;
        _shootMuzzle._explosionRadius *= _multiply;
    }
    public override void RemovePowerUp()
    {
        _shootMuzzle._explosionPower /= _multiply;
        _shootMuzzle._explosionRadius /= _multiply;
    }
}
