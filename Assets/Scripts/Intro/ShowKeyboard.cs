using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Experimental.UI;

public class ShowKeyboard : MonoBehaviour
{
    private TMP_InputField inputField;

    [Header("Play Button")]
    public GameObject playButton;

    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.onSelect.AddListener(x => OpenKeyboard());

        if (playButton != null)
        {
            playButton.SetActive(false);
        }

        if (NonNativeKeyboard.Instance != null)
        {
            NonNativeKeyboard.Instance.OnTextSubmitted += OnKeyboardTextSubmitted;
        }
    }

    public void OpenKeyboard()
    {
        NonNativeKeyboard.Instance.InputField = inputField;
        NonNativeKeyboard.Instance.PresentKeyboard(inputField.text, NonNativeKeyboard.LayoutType.Email);
    }

    private void OnDestroy()
    {
        if (NonNativeKeyboard.Instance != null)
        {
            NonNativeKeyboard.Instance.OnTextSubmitted -= OnKeyboardTextSubmitted;
        }
    }

    private void OnKeyboardTextSubmitted(object sender, System.EventArgs e)
    {
        string submittedText = inputField.text;
        bool isValid = IsValidEmail(submittedText);

        if (playButton != null)
        {
            playButton.SetActive(isValid);
        }
    }

    private bool IsValidEmail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }
}

