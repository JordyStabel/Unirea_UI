using Assets.Backend.Rest;
using System.Collections;
using System.Collections.Generic;
using Assets.Backend;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Unirea.UI
{
    public class Barracks : MonoBehaviour
    {

        public Slider infantrySlider;
        public Slider cavalrySlider;
        public Slider armoredSlider;

        private ArmyRest armyRest = new ArmyRest();

        public void TrainTroops()
        {
            CreateTroops();
        }

        private async void CreateTroops()
        {
            if ((int)infantrySlider.value != 0)
            {
                bool infantrySucces = await armyRest.TrainArmy(PlayerInfo.currentPlayer.AuthenticationToken, ArmyType.Infantry, (int)infantrySlider.value, PlayerInfo.currrentTown.townId);
                Debug.Log("Infantry succes: " + infantrySucces);
            }
            if ((int)cavalrySlider.value != 0)
            {
                bool cavalrySucces = await armyRest.TrainArmy(PlayerInfo.currentPlayer.AuthenticationToken, ArmyType.Cavalry, (int)cavalrySlider.value, PlayerInfo.currrentTown.townId);
                Debug.Log("Cavalry succes: " + cavalrySucces);
            }
            if ((int)armoredSlider.value != 0)
            {
                bool armoredSucces = await armyRest.TrainArmy(PlayerInfo.currentPlayer.AuthenticationToken, ArmyType.Armored, (int)armoredSlider.value, PlayerInfo.currrentTown.townId);
                Debug.Log("Armored succes: " + armoredSucces);
            }
        }
    }
}