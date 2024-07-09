using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private float _itemSpeed = 1;

    public float ItemSpeed { set => _itemSpeed = value; }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            transform.position += Vector3.up * 100;
            PowerUp(_duration);
            StartCoroutine(DurationControl());
        }
    }
    private IEnumerator DurationControl()
    {
        var slider = Instantiate(_durationSlider, FindObjectOfType<VerticalLayoutGroup>().transform);
        slider.transform.Find("Background").transform.Find("Fill Area").transform.Find("Fill").GetComponent<Image>().color = _color;
        var go = new GameObject();
        go.transform.position = slider.transform.position;
        go.transform.parent = slider.transform;
        go.transform.localScale = Vector3.one * 0.15f;
        var image = go.AddComponent<Image>();
        image.sprite = this.GetComponent<SpriteRenderer>().sprite;
        image.color = this.GetComponent<SpriteRenderer>().color;
        while (_elapsed < _duration)
        {
            yield return null;
            _elapsed += Time.deltaTime;
            slider.value = 1 - _elapsed / _duration;
        }
        Destroy(slider.gameObject);
        Destroy(this.gameObject);
    }
    public abstract void PowerUp(float duration);
    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _itemSpeed);
        if (transform.position.x < -100)
        {
            Destroy(this.gameObject);
        }
    }
}
