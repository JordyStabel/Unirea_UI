using UnityEngine;
using UnityEngine.UI;
using Assets.Backend;

public class BuildingDetailsUI : MonoBehaviour {

    public GameObject UI;

    public Image image;

    public Text level;
    public Text duration;
    public Text objectName;
    public Text woodCost;
    public Text ironCost;
    public Text oilText;

    public void ToggleUI(Image image)
    {
        // Flip the isActive state of the UI object
        SetImage(image);
        UI.SetActive(!UI.activeSelf);
    }

    private void SetImage(Image _image)
    {
        image.sprite = _image.sprite;
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