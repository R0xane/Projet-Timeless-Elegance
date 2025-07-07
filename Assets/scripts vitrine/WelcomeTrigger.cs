using UnityEngine;
using TMPro;
using System.Collections;

public class WelcomeTrigger : MonoBehaviour
{
    public TextMeshProUGUI welcomeText;
    public AudioSource welcomeAudio;
    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;

            // Activer le texte
            welcomeText.gameObject.SetActive(true);

            // Jouer l'audio
            welcomeAudio.Play();

            // Lancer la coroutine pour désactiver après 5 secondes
            StartCoroutine(HideTextAfterDelay(5f));
        }
    }

    IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        welcomeText.gameObject.SetActive(false);
    }
}
