using UnityEngine;
using UnityEngine.UI;
using Assets.Backend;
using Assets.Backend.Models;
using Unirea.UI;

public class Register : MonoBehaviour {

    public InputField userName;
    public InputField passWord;
    public InputField passWordRepeat;
    public InputField email;

    public UI_Screen screen;

    public GameObject UI_script;

    private UserManagement userManagement = new UserManagement();

    public async void RegisterUser()
    {
        if (passWord.text == passWordRepeat.text)
        {
            Player player = new Player("", userName.text, email.text, passWord.text);

            if (await userManagement.Register(player))
            {
                player = await userManagement.Login(player);

                if (player.AuthenticationToken != "")
                {
                    //foreach (var town in await userManagement.GetAllTowns(player.AuthenticationToken))
                    //{
                    //    Debug.Log(town.Player);
                    //}

                    await userManagement.GetAllTowns(player.AuthenticationToken);
                    UI_script.GetComponent<UI_System>().SwitchToScreen(screen);
                }
            }
        }
        else { Debug.Log("Make sure both passwords are the same"); }
    }
}