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

        async void UpdateTownView()
        {
            player = playerInfo.GetPlayer();

            town = await townRest.GetTown(townRest.GetAllTownsFromPlayer(player.AuthenticationToken, player.Id).Id, player.AuthenticationToken);
        }
    }
}