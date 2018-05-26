using UnityEngine;
using UnityEngine.UI;
using Assets.Backend;
using Assets.Backend.Models;

public class Login : MonoBehaviour {

    public InputField userName;
    public InputField passWord;

    private UserManagement userManagement = new UserManagement();

    public async void LoginUser()
    {
        Player player = new Player(0, "UserName", userName.text, passWord.text);
        string test;

        test = await userManagement.Login(player);
        Debug.Log(test);
    }
}