using UnityEngine;
using UnityEngine.UI;
using Assets.Backend.Rest;
using Assets.Backend.RestModels;
using System;

namespace Unirea.UI
{
    public class MapInfo_UI : MonoBehaviour
    {
        private TownRest townRest = new TownRest();
        public PlayerInfo playerInfo;

        public GameObject UI;
        public Text townName;

        private Tile tile;
        private PlayerTown town;

        public async void Show(Tile _tile)
        {
            tile = _tile;
            town = await townRest.GetTown(_tile.town_id, playerInfo.GetAccesToken());
            townName.text = town.name + "\n" + town.username;

            UI.SetActive(true);
        }

        public void Hide()
        {
            UI.SetActive(false);
        }
    }
}