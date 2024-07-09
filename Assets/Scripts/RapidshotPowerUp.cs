/// <summary>
/// 弾の発射クールダウンを半減するパワーアップ。
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
