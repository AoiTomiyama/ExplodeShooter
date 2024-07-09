using System.Collections;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// パワーアップの元となる抽象クラス。
/// プレイヤーに接触時に作動し、継続時間が過ぎたのちに効果を打ち消す。
/// DurationComplete関数を呼び出せば途中で強制的に効果を消すこともできる。
/// </summary>
[RequireComponent(typeof(Collider2D))]
public abstract class PowerUpItemBase : MonoBehaviour
{
    [Header("パワーアップ継続時間")]
    [SerializeField]
    float _duration;
    [Header("継続時間のスライダー")]
    [SerializeField]
    Slider _durationSlider;
    [Header("ゲージの色")]
    [SerializeField]
    Color _color;
    float _elapsed;
    public float _itemSpeed = 1;
    public Shoot _shootMuzzle;
    public Slider _currentSlider;

    private void Start()
    {
        _shootMuzzle = FindObjectOfType<Shoot>().GetComponent<Shoot>();
    }
    public abstract void PowerUp();
    public abstract void RemovePowerUp();


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            _shootMuzzle._powerUpList.Add(this);
            PowerUp();
            StartCoroutine(DurationControl());
        }
    }
    private IEnumerator DurationControl()
    {
        transform.position += Vector3.up * 100;
        _currentSlider = Instantiate(_durationSlider, FindObjectOfType<VerticalLayoutGroup>().transform);
        _currentSlider.transform.Find("Background").transform.Find("Fill Area").transform.Find("Fill").GetComponent<Image>().color = _color;
        var go = new GameObject();
        go.transform.position = _currentSlider.transform.position;
        go.transform.parent = _currentSlider.transform;
        go.transform.localScale = Vector3.one * 0.15f;
        var image = go.AddComponent<Image>();
        image.sprite = this.GetComponent<SpriteRenderer>().sprite;
        image.color = this.GetComponent<SpriteRenderer>().color;
        while (_elapsed < _duration)
        {
            yield return null;
            _elapsed += Time.deltaTime;
            _currentSlider.value = 1 - _elapsed / _duration;
        }
        RemovePowerUp();
    }
    private void FixedUpdate()
    {
        if (_elapsed == 0)
        {
            transform.Translate(_itemSpeed * Time.deltaTime * Vector3.left);
            if (transform.position.x < -30)
            {
                Destroy(this.gameObject);
            }
        }
    }
    private void OnDestroy()
    {
        _shootMuzzle._powerUpList.Remove(this);
    }
}
