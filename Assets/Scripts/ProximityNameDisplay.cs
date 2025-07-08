using UnityEngine;
using TMPro;

public class ProximityNameDisplay : MonoBehaviour
{
    public Transform player; // XR camera (head)
    public GameObject labelObject; // le TextMeshPro 3D à afficher
    public float activationDistance = 1.5f;

    private void Update()
    {
        if (player == null || labelObject == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        bool isClose = distance <= activationDistance;

        if (isClose)
        {
            labelObject.SetActive(isClose);
        }
        else
        {
            labelObject.SetActive(isClose);
        }
    }
}
