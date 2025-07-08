using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;


public class AutoReturnToSocket : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    [Header("Retour automatique")]
    public float delay = 1.5f;
    public bool smoothReturn = true;
    public float returnSpeed = 2f;

    private bool returning = false;

    private void Awake()
    {
        grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void OnEnable()
    {
        grab.selectExited.AddListener(OnReleased);
        grab.selectEntered.AddListener(OnGrabbed);
    }

    private void OnDisable()
    {
        grab.selectExited.RemoveListener(OnReleased);
        grab.selectEntered.RemoveListener(OnGrabbed);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        // Si la montre revient et qu'on la reprend, on arrête tout
        returning = false;
        StopAllCoroutines();
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        if (!returning)
        {
            returning = true;
            StartCoroutine(ReturnToStartAfterDelay());
        }
    }

    private System.Collections.IEnumerator ReturnToStartAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true; // pour déplacer proprement
        }

        if (smoothReturn)
        {
            float elapsed = 0f;
            while (elapsed < 1f)
            {
                transform.position = Vector3.Lerp(transform.position, initialPosition, returnSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, returnSpeed * Time.deltaTime);
                elapsed += Time.deltaTime;
                yield return null;
            }
        }

        transform.position = initialPosition;
        transform.rotation = initialRotation;

        if (rb != null)
        {
            rb.isKinematic = false;
        }

        returning = false;

    }
}
