using UnityEngine;
using UnityEngine.UI;
using Unirea_UI;
using Unirea_UI.Models;

public class Login : MonoBehaviour {

    public InputField userName;
    public InputField passWord;

    //public GameObject gameManager;

    private UserManagement userManagement = new UserManagement();

    public async void UserLogin()
    {
        Player player = new Player(0, userName.text, "test@test.com", passWord.text);

        await userManagement.Register(player);
    }
}