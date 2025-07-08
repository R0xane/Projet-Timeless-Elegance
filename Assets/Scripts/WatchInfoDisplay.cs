using UnityEngine;
using TMPro;

public class WatchInfoDisplay : MonoBehaviour
{
    [Header("Infos de la montre")]
    public string nom;
    public string materiaux;
    public float prix;

    [Header("UI")]
    public GameObject infoPanelCanvasPrefab; // Doit contenir un Canvas World Space
    private GameObject currentPanel;

    public void OnSelectEntered()
    {
        if (infoPanelCanvasPrefab == null || Camera.main == null) return;

        currentPanel = Instantiate(infoPanelCanvasPrefab);

        // Positionne le panneau à gauche + devant la tête du joueur
        Transform cam = Camera.main.transform;
        Vector3 offset = cam.right * -0.4f + cam.up * 0.2f + cam.forward * 0.6f;
        currentPanel.transform.position = cam.position + offset;

        // Oriente le panneau pour faire face au joueur
        currentPanel.transform.LookAt(cam);
        currentPanel.transform.Rotate(0, 180, 0);

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
