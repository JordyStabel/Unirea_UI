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

        // Use this for initialization
        void Start()
        {
            InvokeRepeating("UpdateText", 1, 1);
        }

        void UpdateText()
        {
            woodAmount.text = "15";
            ironAmount.text = "25";
            oilAmount.text = "35";

            if (PlayerInfo.isLoggedIn) cityName.text = PlayerInfo.currentPlayer.Email + "'s City";
        }
    }
}