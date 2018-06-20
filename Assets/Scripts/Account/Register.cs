using UnityEngine;
using UnityEngine.UI;
using Assets.Backend.Rest;
using Assets.Backend.Models;
using Unirea.UI;

public class Register : MonoBehaviour {

    public InputField userName;
    public InputField passWord;
    public InputField passWordRepeat;
    public InputField email;

    public UI_Screen screen;
    public PlayerInfo playerInfo;
    public GameObject UI_script;

    private AccountRest accountRest = new AccountRest();
    private TownRest townRest = new TownRest();

    public async void RegisterUser()
    {
        if (passWord.text == passWordRepeat.text)
        {
            Player player = new Player(userName.text, email.text, passWord.text);

            if (await accountRest.Register(player))
            {
                player = await accountRest.Login(player);
                playerInfo.UpdatePlayer(player);

                if (player.AuthenticationToken != "")
                {
                    await townRest.CreateTown(player.AuthenticationToken);
                    UI_script.GetComponent<UI_System>().SwitchToScreen(screen);
                }
            }
        }
        else { Debug.Log("Make sure both passwords are the same"); }
    }
}