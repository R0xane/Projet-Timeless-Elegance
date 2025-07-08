using UnityEngine;
using TMPro;

public class WatchInfoDisplay : MonoBehaviour
{
    [Header("Infos de la montre")]
    public string nom;
    
    public string materiaux;
    public float prix;

    [Header("UI")]
    public GameObject infoPanelCanvasPrefab; 
    private GameObject currentPanel;

    public void OnSelectEntered()
    {
        if (infoPanelCanvasPrefab == null) return;

        currentPanel = Instantiate(infoPanelCanvasPrefab);

        // Positionne le panneau juste au-dessus de la montre
        Vector3 offset = Vector3.up * 0.2f;
        currentPanel.transform.position = transform.position + offset;

        // Oriente le panneau vers la tête du joueur
        Transform cameraTransform = Camera.main.transform;
        currentPanel.transform.LookAt(cameraTransform);
        currentPanel.transform.Rotate(0, 180, 0); // pour le tourner vers le joueur

        TMP_Text[] texts = currentPanel.GetComponentsInChildren<TMP_Text>();
        foreach (TMP_Text t in texts)
        {
            if (t.name.Contains("Nom")) t.text = "Modèle : " + nom;
            else if (t.name.Contains("Matériaux")) t.text = "Matériaux : " + materiaux;
            else if (t.name.Contains("Prix")) t.text = "Prix : " + prix + " €";
        }
    }

    public void OnSelectExited()
    {
        if (currentPanel != null)
        {
            Destroy(currentPanel);
            currentPanel = null;
        }
    }
}
