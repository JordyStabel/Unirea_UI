using UnityEngine;
using UnityEngine.UI;
using Assets.Backend;

public class BuildingDetailsUI : MonoBehaviour {

    public GameObject UI;

    public Text level;
    public Text duration;
    public Text objectName;
    public Text woodCost;
    public Text ironCost;
    public Text oilText;

    public void ToggleUI(Image image)
    {
        // Flip the isActive state of the UI object
        UI.SetActive(!UI.activeSelf);
    }

    private void SetImage()
    {

    }

    private void SetImage(BuildingType buildingType)
    {
        switch (buildingType)
        {
            case BuildingType.OilRefinery:
                //
                break;
        }
    }
}