using UnityEngine;
using Unirea.UI;
using Assets.Backend.Models;

public class PlayerInfo : MonoBehaviour {

    public static Player currentPlayer;

    public static bool isLoggedIn = false;

    private void OnEnable()
    {
        EventManager.playerUpdateEvent += Notify;
    }

    private void OnDisable()
    {
        EventManager.playerUpdateEvent -= Notify;
    }

    public void UpdatePlayer(Player player)
    {
        currentPlayer = player;
        isLoggedIn = true;
        EventManager.PlayerUpdate();
        Notify();
    }

    private void Notify() { }
}