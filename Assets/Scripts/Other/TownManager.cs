using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Backend;
using Assets.Backend.Rest;
using Assets.Backend.RestModels;
using Assets.Backend.Models;
using Assets.Backend.Models.Buildings;

namespace Unirea.UI
{
    public class TownManager : MonoBehaviour
    {
        [SerializeField]
        private PlayerInfo playerInfo;

        private TownRest townRest = new TownRest();
        private MapRest mapRest = new MapRest();
        private PlayerTown town;
        private Player player;

        void OnEnable()
        {
            EventManager.townUpdateEvent += UpdateTownView;
        }

        private void OnDisable()
        {
            EventManager.townUpdateEvent -= UpdateTownView;
        }

        private void UpdateTownView()
        {
            player = playerInfo.GetPlayer();
            GetTown();
        }

        private async void GetTown()
        {
            List<Map> maps = await mapRest.GetAllTowns();
            foreach (Map map in maps)
            {
                town = await townRest.GetTown(map.id, player.AuthenticationToken);
                if (town.username == player.Username)
                {
                    playerInfo.UpdateTown(town);
                    EventManager.BuildingImageUpdate();
                    break;
                }
            }
        }
    }
}