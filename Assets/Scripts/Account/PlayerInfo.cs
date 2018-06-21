using UnityEngine;
using Unirea.UI;
using Assets.Backend.Models;

public class PlayerInfo : MonoBehaviour {

    public static Player currentPlayer;

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

    private void EventNotifier() { }
}