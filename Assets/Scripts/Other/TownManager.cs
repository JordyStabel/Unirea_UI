using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
            Debug.Log(player.AuthenticationToken + " / " + player.Id);
            GetTown();
        }

        private async void GetTown()
        {
            List<Map> maps = await mapRest.GetAllTowns();
            foreach (Map map in maps)
            {
                town = await townRest.GetTown(map.id, player.AuthenticationToken);

                if (town.id == player.Id)
                    break;
            }
            Debug.Log(town.username);

            //town = await townRest.GetTown(4, player.AuthenticationToken);
            //Debug.Log(town.townId);
            //Debug.Log(town.townBuildings);
            ////List<Building> buildings = town.townBuildings;
            ////Building building = town.townBuildings[1];

            //List<PlayerTown> towns = await townRest.GetAllTownsFromPlayer(player.AuthenticationToken, player.Id);
            //town = towns[0];
            //List<BuildingUI> buildings = new List<BuildingUI>();
            //Debug.Log(town.townId);
            //Debug.Log(towns[1].townId);
            //Debug.Log(towns[2].townId);
        }
    }
}