using UnityEngine;
using UnityEngine.UI;
using Assets.Backend;
using Assets.Backend.Rest;
using Assets.Backend.RestModels;
using Assets.Backend.Models;

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

    private TownBuilding building;

    private BuildingRest buildingRest = new BuildingRest();

    public void ToggleUI(Image image)
    {
        // Flip the isActive state of the UI object
        SetImage(image);
        UI.SetActive(!UI.activeSelf);
    }

    public void GetBuildingType(int buidlingID)
    {
        building = PlayerInfo.currrentTown.townBuildings[(buidlingID - 1)];
        UpdateAllText();
    }

    private void SetImage(Image _image)
    {
        image.sprite = _image.sprite;
    }

    private void UpdateAllText()
    {
        objectName.text = building.name;
        level.text = building.level.ToString();
        woodCost.text = (building.upgradeCost[(int)ResourceType.Wood - 1].amount).ToString();
        ironCost.text = (building.upgradeCost[(int)ResourceType.Iron - 1].amount).ToString();
        oilText.text = (building.upgradeCost[(int)ResourceType.Oil - 1].amount).ToString();
    }

    public void LevelUpBuilding()
    {
        // Can't call async method directly from Unity
        IncreaseBuildingLevel(building.id);
    }

    public async void IncreaseBuildingLevel(BuildingType buildingType)
    {
        bool responds = await buildingRest.LevelUpBuilding(playerInfo.GetAccesToken(), PlayerInfo.currrentTown.townId, buildingType);
        Debug.Log("Upgrading building: " + responds);
    }
}