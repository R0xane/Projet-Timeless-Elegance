using UnityEngine;

public class ShowDialogue : MonoBehaviour
{
    public GameObject dialogueCanvas;
    public Transform player; 
    public float activationDistance = 2f;

    private void Update()
    {
        if (player == null || dialogueCanvas == null)
            return;

        float distance = Vector3.Distance(transform.position, player.position);

        // Show if player is near, hide if far
        dialogueCanvas.SetActive(distance <= activationDistance);
    }
}
