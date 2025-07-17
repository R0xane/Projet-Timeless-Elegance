using UnityEngine;
using System.Collections;
using TMPro;

public class DialogueButtons : MonoBehaviour
{
    public Animator vendeurAnimator;
    public static bool peutEssayerMontre = false;

    [Header("Audio du vendeur")]
    public AudioSource vendeurAudioSource;
    public AudioClip clipInfo;
    public AudioClip clipEssayer;
    public AudioClip clipQuitter;

    [Header("Zoom miroir")]

    public Transform xrRig;
    public Transform miroirFocusPoint;
    public float rotationSpeed = 3f;

    public void OnInfoPressed()
    {
        PlayVoice(clipInfo);
    }

    public void OnEssayerMontrePressed()
    {
        peutEssayerMontre = true;

        PlayVoice(clipEssayer);
        if (xrRig != null && miroirFocusPoint != null)
            StartCoroutine(RotateRigToward(miroirFocusPoint));
    }

    public void OnQuitterPressed()
    {
        if (vendeurAudioSource != null && clipQuitter != null)
        {
            PlayVoice(clipQuitter);
            StartCoroutine(QuitAfterClip(clipQuitter.length));
        }
        else
        {
            QuitApplication();
        }
    }

    private IEnumerator QuitAfterClip(float delay)
    {
        yield return new WaitForSeconds(delay);
        QuitApplication();
    }

    private void QuitApplication()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void PlayVoice(AudioClip clip)
    {
        if (vendeurAudioSource != null && clip != null)
        {
            vendeurAudioSource.Stop();
            vendeurAudioSource.clip = clip;
            vendeurAudioSource.Play();

            if (vendeurAnimator != null)
                vendeurAnimator.SetBool("IsTalking", true);

            StartCoroutine(StopTalkingAfterDelay(clip.length));
        }
    }

    private IEnumerator StopTalkingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (vendeurAnimator != null)
            vendeurAnimator.SetBool("IsTalking", false);
    }
    
    private IEnumerator RotateRigToward(Transform target)
    {
        Vector3 direction = target.position - xrRig.position;
        direction.y = 0; 

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        Quaternion initialRotation = xrRig.rotation;

        float elapsed = 0f;
        float duration = 0.8f;

        while (elapsed < duration)
        {
            xrRig.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsed / duration);
            elapsed += Time.deltaTime * rotationSpeed;
            yield return null;
        }

        xrRig.rotation = targetRotation;
    }

}
