using Assets.Backend.Rest;
using System.Collections;
using System.Collections.Generic;
using Assets.Backend;
using UnityEngine;
using UnityEngine.UI;

public class Barracks : MonoBehaviour {

    public Slider infantrySlider;
    public Slider cavalrySlider;
    public Slider armoredSlider;

    private ArmyRest armyRest = new ArmyRest();

	public void TrainTroops()
    {
        CreateTroops();
    }

    private async CreateTroops()
    {
        bool responds = await armyRest.TrainArmy(PlayerInfo.currentPlayer.AuthenticationToken, ArmyType.Infantry, infantrySlider.value, PlayerInfo.currrentTown.townId);
    }
}