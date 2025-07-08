using UnityEngine;
using TMPro;
 // ← requis pour XRGrabInteractable

public class ProximityNameDisplay : MonoBehaviour
{
    public Transform player;
    public GameObject labelObject;
    public float activationDistance = 1.5f;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab;

    private void Awake()
    {
        grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
    }

    private void Update()
    {
        if (player == null || labelObject == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        bool isGrabbed = grab != null && grab.isSelected;

        bool shouldShow = distance <= activationDistance && !isGrabbed;

        labelObject.SetActive(shouldShow);
    }
}