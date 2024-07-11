using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    GameObject _howToPanel, _mainPanel;
    private void Start()
    {
        _mainPanel = GameObject.Find("MainPanel");
        _howToPanel = GameObject.Find("HowToPanel");
        _howToPanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Main");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            _mainPanel.SetActive(!_mainPanel.activeSelf);
            _howToPanel.SetActive(!_howToPanel.activeSelf);
        }
    }
}
