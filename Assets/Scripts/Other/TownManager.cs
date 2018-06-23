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
            town = await townRest.GetTown(4, player.AuthenticationToken);

            //List<PlayerTown> towns = await townRest.GetAllTownsFromPlayer(player.AuthenticationToken, player.Id);
            //town = towns[0];
            List<Building> buildings = new List<Building>();
            //foreach (Building building in town.townBuildings)
            Debug.Log(town.townBuildings);
        }
    }
}