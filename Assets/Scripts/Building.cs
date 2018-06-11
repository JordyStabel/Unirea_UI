using UnityEngine;
using UnityEngine.UI;
using Assets.Backend.Models;

namespace Unirea.UI
{
    public class Building : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] allBuildingSprites;

        public RectTransform buildingCanvas;

        void Awake()
        {
            buildingCanvas.GetComponent<Image>().sprite = allBuildingSprites[1];
        }

        void Start()
        {

        }

        void Update()
        {

        }
    }
}