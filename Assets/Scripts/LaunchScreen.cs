using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LaunchScreen : MonoBehaviour
{
    public TMP_Text welcomeText;
    public TMP_Text sessionIdText;
    public GameObject launchPanel;

    private void Start()
    {
        string sessionId = GenerateRandomSessionId();
        sessionIdText.text = "Session ID : " + sessionId;
        welcomeText.text = "Bienvenue dans la collection Eternal Horizons";
    }

    public void ClickedButton()
    {
        launchPanel.SetActive(false);
        SceneManager.LoadScene("Real Scene");
    }

    private string GenerateRandomSessionId()
    {
        int number = Random.Range(1000, 9999);
        return "#" + number.ToString();
    }
}
