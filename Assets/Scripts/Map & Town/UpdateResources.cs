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

        //void OnEnable()
        //{
        //    EventManager.resourceUpdateEvent += UpdateText;
        //}

        //private void OnDisable()
        //{
        //    EventManager.resourceUpdateEvent -= UpdateText;
        //}

        public void UpdateText()
        {
            woodAmount.text = "15";
            ironAmount.text = "25";
            oilAmount.text = "35";

            // TODO: Get actual town name
            if (PlayerInfo.isLoggedIn) cityName.text = PlayerInfo.currentPlayer.Username + "'s City";
        }
    }
}