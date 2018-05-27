using UnityEngine;
using Assets.Backend.Models;

public class PlayerInfo : MonoBehaviour {

    public static Player currentPlayer;

    public static bool isLoggedIn = false;

    public void UpdatePlayer(Player player)
    {
        currentPlayer = player;
        isLoggedIn = true;
    }
}