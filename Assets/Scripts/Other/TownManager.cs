using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Backend.Rest;
using Assets.Backend.RestModels;
using Assets.Backend.Models;

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
            List<PlayerTown> towns = await townRest.GetAllTownsFromPlayer(player.AuthenticationToken, player.Id);
            town = towns[0];
            Debug.Log(town.townBuildings);
        }
    }
}