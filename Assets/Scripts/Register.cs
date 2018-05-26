using UnityEngine;
using UnityEngine.UI;
using Assets.Backend;
using Assets.Backend.Models;

public class Register : MonoBehaviour {

    public InputField userName;
    public InputField passWord;
    public InputField passWordRepeat;
    public InputField email;

    private UserManagement userManagement = new UserManagement();

    public async void RegisterUser()
    {
        if (passWord.text == passWordRepeat.text)
        {
            Player player = new Player("", userName.text, email.text, passWord.text);
            bool test;

            test = await userManagement.Register(player);
            Debug.Log(test);
        }
        else { Debug.Log("Make sure both passwords are the same"); }
    }
}