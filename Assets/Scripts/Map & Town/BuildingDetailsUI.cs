using UnityEngine;
using UnityEngine.UI;
using Assets.Backend;
using Assets.Backend.Rest;

public class BuildingDetailsUI : MonoBehaviour {

    public GameObject UI;
    public PlayerInfo playerInfo;

    public Image image;

    public Text level;
    public Text duration;
    public Text objectName;
    public Text woodCost;
    public Text ironCost;
    public Text oilText;

    private BuildingRest buildingRest = new BuildingRest();

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

    public void Something()
    {
        // Can't call async method directly from Unity
        IncreaseBuildingLevel(BuildingType.Foundry);
    }

    public async void IncreaseBuildingLevel(BuildingType buildingType)
    {
        // TODO: Implement with the correct values
        bool responds = await buildingRest.LevelUpBuilding(playerInfo.GetAccesToken(), 4, BuildingType.OilRefinery);
        Debug.Log(responds);
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