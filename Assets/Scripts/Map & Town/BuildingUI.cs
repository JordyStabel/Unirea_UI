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

        private Assets.Backend.Models.Buildings.Building building;

        public RectTransform buildingCanvas;

        void Awake()
        {
            buildingCanvas.GetComponent<Image>().sprite = allBuildingSprites[0];
            //building = get this from the town
        }

        void Start()
        {

        }

        void Update()
        {

        }
    }
}