using UnityEngine;
using UnityEngine.UI;

public class BuildingDetailsUI : MonoBehaviour {

    public GameObject UI;

    public Text duration;
    public Text objectName;
    public Button cancel;

    private bool isActive = false;

    public void ToggleUI()
    {
        // Flip the isActive state of the UI object
        UI.SetActive(!UI.activeSelf);
    }
}