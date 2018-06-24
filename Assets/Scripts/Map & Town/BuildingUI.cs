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

        void Awake()
        {
            buildingCanvas.GetComponent<Image>().sprite = allBuildingSprites[0];
        }

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
                buildingCanvas.GetComponent<Image>().sprite = allBuildingSprites[building.level];
            }
            catch
            {
                // No image
                buildingCanvas.GetComponent<Image>().sprite = allBuildingSprites[0];
                Debug.Log("Sprites aren't made yet.");
            }
        }
    }
}