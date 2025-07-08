using UnityEngine;

public class SimpleSlideshow : MonoBehaviour
{
    public GameObject[] panels; // Mets ici EcranAccueil, Photo1, Photo2, etc.
    private int currentIndex = 0;
    public GameObject HomeScreen; // Assure-toi que cet objet est assigné dans l'inspecteur
    public GameObject swap; // Assure-toi que cet objet est assigné dans l'inspecteur
    public GameObject IpadSelection; // Assure-toi que cet objet est assigné dans l'inspecteur
    public GameObject IpadTOselect; // Assure-toi que cet objet est assign

    void Start()
    {
        ShowPanel(0); // Affiche le premier écran au début
    }

    public void Next()
    {
        if (currentIndex < panels.Length - 1)
        {
            ShowPanel(currentIndex + 1);
        }
    }

    public void Previous()
    {
        if (currentIndex > 0)
        {
            ShowPanel(currentIndex - 1);
        }
    }

    void ShowPanel(int index)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(i == index);
        }
        currentIndex = index;
    }

    public void clicOnQuit(){
        HomeScreen.SetActive(false); // Désactive l'écran d'accueil
        swap.SetActive(false); // Désactive l'objet swap
        IpadSelection.SetActive(false); // Désactive l'objet IpadSelection
        IpadTOselect.SetActive(true); // Réactive l'objet IpadTOselect

    }
}
