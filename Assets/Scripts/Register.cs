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

            if (await userManagement.Register(player))
            {
                player = await userManagement.Login(player);

                if (player.AuthenticationToken != null)
                {
                    Debug.Log(await userManagement.CreateTown(player.AuthenticationToken));
                }
            }

            //Debug.Log(await userManagement.Register(player));
        }
        else { Debug.Log("Make sure both passwords are the same"); }
    }
}