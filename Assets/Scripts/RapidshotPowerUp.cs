/// <summary>
/// �e�̔��˃N�[���_�E���𔼌�����p���[�A�b�v�B
/// </summary>
public class RapidshotPowerUp : PowerUpItemBase
{
    public override void PowerUp()
    {
        _shootMuzzle._cooldownTime /= 2;
    }
    public override void RemovePowerUp()
    {
        _shootMuzzle._cooldownTime *= 2;
        Destroy(_currentSlider.gameObject);
        Destroy(gameObject);
    }
}
