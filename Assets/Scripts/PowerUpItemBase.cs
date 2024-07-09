using System.Collections;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// �p���[�A�b�v�̌��ƂȂ钊�ۃN���X�B
/// �v���C���[�ɐڐG���ɍ쓮���A�p�����Ԃ��߂����̂��Ɍ��ʂ�ł������B
/// DurationComplete�֐����Ăяo���Γr���ŋ����I�Ɍ��ʂ��������Ƃ��ł���B
/// </summary>
[RequireComponent(typeof(Collider2D))]
public abstract class PowerUpItemBase : MonoBehaviour
{
    [Header("�p���[�A�b�v�p������")]
    [SerializeField]
    float _duration;
    [Header("�p�����Ԃ̃X���C�_�[")]
    [SerializeField]
    Slider _durationSlider;
    [Header("�Q�[�W�̐F")]
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
