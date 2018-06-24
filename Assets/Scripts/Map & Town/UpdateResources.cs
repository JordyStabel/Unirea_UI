using Assets.Backend.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Unirea.UI
{
    public class UpdateResources : MonoBehaviour
    {
        public Text cityName;
        public Text woodAmount;
        public Text ironAmount;
        public Text oilAmount;

        void OnEnable()
        {
            EventManager.resourceUpdateEvent += UpdateText;
        }

        private void OnDisable()
        {
            EventManager.resourceUpdateEvent -= UpdateText;
        }

        public void UpdateText()
        {
            woodAmount.text = PlayerInfo.currrentTown.townResources[(int)ResourceType.Wood - 1].amount.ToString();
            ironAmount.text = PlayerInfo.currrentTown.townResources[(int)ResourceType.Iron - 1].amount.ToString();
            oilAmount.text = PlayerInfo.currrentTown.townResources[(int)ResourceType.Oil - 1].amount.ToString();
            cityName.text = PlayerInfo.currrentTown.name;
        }
    }
}