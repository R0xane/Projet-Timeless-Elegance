using UnityEngine;

public class AddToSelectionAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip confirmationClip;

    public void PlayConfirmation()
    {
        if (audioSource != null && confirmationClip != null)
        {
            audioSource.Stop();
            audioSource.clip = confirmationClip;
            audioSource.Play();
        }
    }
}
