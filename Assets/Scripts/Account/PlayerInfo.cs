using UnityEngine;
using Unirea.UI;
using Assets.Backend.Models;
using Assets.Backend.RestModels;

public class PlayerInfo : MonoBehaviour {

    public static Player currentPlayer;
    public static PlayerTown currrentTown;

    public static bool isLoggedIn = false;

    private void OnEnable()
    {
        EventManager.playerUpdateEvent += EventNotifier;
    }

    private void OnDisable()
    {
        EventManager.playerUpdateEvent -= EventNotifier;
    }

    public void UpdatePlayer(Player player)
    {
        currentPlayer = player;
        isLoggedIn = true;
        EventManager.PlayerUpdate();
        EventNotifier();
    }

    public string GetAccesToken()
    {
        return currentPlayer.AuthenticationToken;
    }

    public Player GetPlayer()
    {
        return currentPlayer;
    }

    public void UpdateTown(PlayerTown town)
    {
        currrentTown = town;
    }

    private void EventNotifier() { }
}