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

        // Instantie le panneau comme enfant de l'objet sélectionné
        currentPanel = Instantiate(infoPanelCanvasPrefab, transform);

        // Place à (0,0,0) en local
        currentPanel.transform.localPosition = Vector3.zero;
        currentPanel.transform.localRotation = Quaternion.identity;

        // Remplit les infos du texte
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
