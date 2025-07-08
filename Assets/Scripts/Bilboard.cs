using UnityEngine;

public class BillboardToCamera : MonoBehaviour
{
    void LateUpdate()
    {
        if (Camera.main == null) return;
        // Oriente le panneau vers la caméra du joueur
        transform.LookAt(Camera.main.transform.position, Vector3.up);
        transform.Rotate(0, 0, 0); // Ajuste selon l'orientation de ton UI
    }
}
