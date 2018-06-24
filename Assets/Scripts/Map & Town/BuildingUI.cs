using UnityEngine;
using UnityEngine.UI;
using Assets.Backend;
using Assets.Backend.RestModels;

namespace Unirea.UI
{
    public class BuildingUI : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] allBuildingSprites;

        public BuildingType buildingType;

        public RectTransform buildingCanvas;

        private TownBuilding building;

        private void OnEnable()
        {
            EventManager.buildingImageUpdateEvent += UpdateImage;
        }

        private void OnDisable()
        {
            EventManager.buildingImageUpdateEvent -= UpdateImage;
        }

        private void UpdateImage()
        {
            building = PlayerInfo.currrentTown.townBuildings[(int)buildingType - 1];
            try
            {
                if (building.level > 1)
                {
                    buildingCanvas.GetComponent<Image>().sprite = allBuildingSprites[1];
                }
                buildingCanvas.GetComponent<Image>().sprite = allBuildingSprites[building.level];
                buildingCanvas.GetComponentInChildren<Text>().text = building.name + " " + building.level;
            }
            catch
            {
                // No image
                buildingCanvas.GetComponent<Image>().sprite = allBuildingSprites[0];
                buildingCanvas.GetComponentInChildren<Text>().text = building.name + " " + building.level;
                Debug.Log("Sprites aren't made yet.");
            }
        }
    }
}