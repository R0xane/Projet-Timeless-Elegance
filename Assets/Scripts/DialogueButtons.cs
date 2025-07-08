using UnityEngine;
using System.Collections;
using TMPro;

public class DialogueButtons : MonoBehaviour
{
    public GameObject infoCanvas;
    public float displayDuration = 5f;
    public static bool peutEssayerMontre = false;

    [Header("Notification intégrée")]
    public GameObject notificationPanel; // Peut être un Text ou un Panel contenant du texte
    public TMP_Text notificationText;
    public float notifDuration = 5f;

    public void OnInfoPressed()
    {
        if (infoCanvas != null)
        {
            infoCanvas.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(HideInfoAfterDelay());
        }
    }

    public void OnEssayerMontrePressed()
    {
        peutEssayerMontre = true;
        ShowNotification("Vous pouvez maintenant essayer les montres");
    }

    public void OnQuitterPressed()
    {

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    private IEnumerator HideInfoAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        infoCanvas.SetActive(false);
    }

    private void ShowNotification(string message)
    {
        if (notificationPanel == null || notificationText == null) return;

        notificationText.text = message;
        notificationPanel.SetActive(true);

        StopAllCoroutines(); // pour éviter que plusieurs timers se chevauchent
        StartCoroutine(HideNotificationAfterDelay());
    }

    private IEnumerator HideNotificationAfterDelay()
    {
        yield return new WaitForSeconds(notifDuration);
        notificationPanel.SetActive(false);
    }
}
