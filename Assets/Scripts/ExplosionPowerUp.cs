using UnityEngine;
/// <summary>
/// �e�̈З́i�����͈́E������΂��́j��{���ɉ����ċ�������p���[�A�b�v�B
/// </summary>
public class ExplosionPowerUp : PowerUpItemBase
{
    [Header("��������{��")]
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
