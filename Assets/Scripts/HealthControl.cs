using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthControl : MonoBehaviour
{
    [Header("HP�̗�(-1�ő̗́�)")]
    [SerializeField]
    private int _health = 5;

    [Header("�̗̓Q�[�W1�����̕�")]
    [SerializeField]
    private int _healthPadding = 5;

    [Header("�̗̓Q�[�W�̌�����")]
    [SerializeField]
    private GameObject _healthPrefab;
    /// <summary> ��ʏ�̗̑̓Q�[�W���Ǘ�����z�� </summary>
    private GameObject[] _healthBar;

    private void Start()
    {
        _healthBar = new GameObject[_health];
        for (int i = 0; i < _health; i++)
        {
            _healthBar[i] = Instantiate(_healthPrefab, transform);
            _healthBar[i].transform.position = new Vector2(this.transform.position.x + i * Screen.width / _healthPadding, this.transform.position.y);
        }
    }
    public void RemoveOneHealth()
    {
        RemoveHealth(1);
    }
    private void RemoveHealth(int damage)
    {
        if (_health - damage < 0)
        {
            Gameover();
            return;
        }
        else
        {
            for (int i = _health; i > _health - damage; i--)
            {
                _healthBar[i - 1].GetComponent<Image>().color = Color.red;
                Destroy(_healthBar[i - 1], 0.5f);
            }
            _health -= damage;
            Debug.Log($"Bullet Hit! Took {damage} damage! Remaining health is {_health} !");
        }
        if (_health == 0)
        {
            Gameover();
        }
    }
    void Gameover()
    {
        Debug.Log("Gameover");
        //SceneManager.LoadScene("Gameover");
    }
}
