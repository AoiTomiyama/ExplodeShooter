using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float _elapsedTime;
    private Text _recordText;
    private void Start()
    {
        _recordText = GameObject.Find("Record").GetComponent<Text>();
    }
    void Update()
    {
        _elapsedTime += Time.deltaTime * 5;
        _recordText.text = _elapsedTime.ToString("N0") + "m";
    }
    private void OnDisable()
    {
        PlayerPrefs.SetInt("RECORD", Mathf.CeilToInt(_elapsedTime));
    }
}
