using UnityEngine;

public class MoveInFrontOfCameraOnSelect : MonoBehaviour
{
    public float distance = 0.5f; // Distance devant la caméra
    public Vector3 offset = Vector3.zero; // Offset optionnel

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool isSelected = false;

    public Vector3 faceCorrection = new Vector3(0, 90, 0); // <-- Juste Y

    public GameObject HomeScreen;
    public GameObject swap;
    public GameObject IpadSelection;
    public GameObject IpadTOselect;

    private void Start()
    {
        HomeScreen.SetActive(false); // Assure que l'écran d'accueil est désactivé au début
        swap.SetActive(false); // Assure que l'objet swap est désactivé au début
        IpadSelection.SetActive(false); // Assure que l'objet IpadSelection est désactivé au début

    }

    public void OnSelectEntered()
    {

        HomeScreen.SetActive(true); // Active l'écran d'accueil lorsque l'objet est sélectionné
        swap.SetActive(true); // Active l'objet swap lorsque l'objet est sélectionné
        IpadSelection.SetActive(true); // Active l'objet IpadSelection lorsque l'objet est sélectionné
        IpadTOselect.SetActive(false); // Désactive l'objet IpadTOselect lorsque l'objet est sélectionné
    }
    


}
