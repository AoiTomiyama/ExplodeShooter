using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PowerUpItemBase : MonoBehaviour
{
    [Header("パワーアップ継続時間")]
    [SerializeField]
    float _duration;
    [Header("継続時間のスライダー")]
    [SerializeField]
    Slider _durationSlider;
    float _elapsed;
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
        var go = new GameObject();
        go.transform.position = slider.transform.position;
        go.transform.parent = slider.transform;
        go.transform.localScale = Vector3.one * 0.25f;
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
}
