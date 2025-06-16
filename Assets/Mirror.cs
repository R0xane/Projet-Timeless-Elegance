using UnityEngine;

public class MirrorCameraRotation : MonoBehaviour
{
    public Transform player;             // Le joueur (ou la caméra principale)
    public Transform mirrorPlane;        // Le plan du miroir (normal = mirrorPlane.forward)
    public Camera mirrorCamera;          // La caméra fixe du miroir
    public float yOffset = .1f;
    private Vector3 newT;

    private void Start()
    {

    }
    void LateUpdate()
    {
        newT = mirrorCamera.transform.position;
        newT.y = player.position.y-yOffset;
        mirrorCamera.transform.position = newT;

        if (player == null || mirrorPlane == null || mirrorCamera == null)
            return;

        // Direction du regard du joueur

        Vector3 viewDirection = mirrorPlane.position - player.position;

        // Normale du miroir (assume que le miroir regarde dans son forward)
        Vector3 mirrorNormal = mirrorPlane.forward;

        // Réfléchir la direction de regard du joueur autour de la normale du miroir
        Vector3 reflectedDirection = Vector3.Reflect(viewDirection, mirrorNormal);

        // Appliquer uniquement la rotation à la caméra du miroir
        mirrorCamera.transform.rotation = Quaternion.LookRotation(reflectedDirection, Vector3.up);
    }
}
