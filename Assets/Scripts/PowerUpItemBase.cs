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
            transform.position += Vector3.forward * -1000f; 
            PowerUp(_duration);
            StartCoroutine(DurationControl());
        }
    }
    private IEnumerator DurationControl()
    {
        var slider = Instantiate(_durationSlider, FindObjectOfType<VerticalLayoutGroup>().transform);
        while (_elapsed < _duration)
        {
            yield return null;
            _elapsed += Time.deltaTime;
            slider.value = _elapsed / _duration;
        }
        Destroy(slider.gameObject);
        Destroy(this.gameObject);
    }
    public abstract void PowerUp(float duration);
}
