using UnityEngine;
using System.Collections;
public class TabletScreenController : MonoBehaviour
{
    public Renderer screenRenderer;
    public Material blackScreen;
    public Material logoScreen;

    private bool logoShown = false;

    public void ShowLogo()
    {
        if (!logoShown)
        {
            screenRenderer.material = logoScreen;
            logoShown = true;
        }
    }
}
