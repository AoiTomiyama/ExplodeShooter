using UnityEngine;
using UnityEngine.SceneManagement;
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        _elapsedTime += Time.deltaTime * 10;
        _recordText.text = _elapsedTime.ToString("N0") + "m";
    }
}
