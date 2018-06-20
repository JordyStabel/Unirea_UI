using UnityEngine;
using UnityEngine.UI;
using Assets.Backend.Rest;
using Assets.Backend.Models;

namespace Unirea.UI
{
    public class Login : MonoBehaviour
    {
        public InputField email;
        public InputField passWord;

        public GameObject UI_script;
        public UI_Screen screen;

        public PlayerInfo playerInfo;

        private AccountRest accountRest = new AccountRest();
        
        public async void LoginUser()
        {
            Player input = new Player("UserName", email.text, passWord.text);

            Player player = await accountRest.Login(input);

            if (player != null)
            {
                Player tmp = await accountRest.GetAccount(player.AuthenticationToken);
                UI_script.GetComponent<UI_System>().SwitchToScreen(screen);
                playerInfo.UpdatePlayer(player);
            }
        }
    }
}