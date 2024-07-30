using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameoverManager : MonoBehaviour
{
    [Header("���s���̌��ʉ�")]
    [SerializeField]
    AudioClip _clip;
    Text _resultDisplay;
    private void Start()
    {
        AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position);
        _resultDisplay = GameObject.Find("Result").GetComponent<Text>();
        _resultDisplay.text = "Record: " + PlayerPrefs.GetInt("RECORD").ToString("N0") + "m";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Main");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
