using UnityEngine;

public class TabletSwipeHandler : MonoBehaviour
{
    public Material[] watchMaterials;
    public Renderer screenRenderer;

    private int currentIndex = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeftHand")) 
        {
            NextMaterial();
        }
    }

    void NextMaterial()
    {
        if (watchMaterials.Length == 0 || screenRenderer == null) return;

        currentIndex = (currentIndex + 1) % watchMaterials.Length;
        screenRenderer.material = watchMaterials[currentIndex];
    }
}
