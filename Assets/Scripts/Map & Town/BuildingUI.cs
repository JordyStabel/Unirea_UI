using UnityEngine;
using UnityEngine.UI;
using Assets.Backend.Models;
using Assets.Backend;

namespace Unirea.UI
{
    public class BuildingUI : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] allBuildingSprites;

        [SerializeField]
        private BuildingType buildingType;

        public RectTransform buildingCanvas;

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

        private void UpdateImage(BuildingType _buildingType, int level)
        {
            if (level != 0 && this.buildingType == _buildingType)
            {
                buildingCanvas.GetComponent<Image>().sprite = allBuildingSprites[level];
            }
            else
            {
                buildingCanvas.GetComponent<Image>().sprite = null;
                buildingCanvas.GetComponent<Button>().enabled = false;
            }
        }
    }
}