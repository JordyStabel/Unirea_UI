using UnityEngine;
using UnityEngine.UI; 
using Assets.Backend;
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

        private UserManagement userManagement = new UserManagement();
        
        public async void LoginUser()
        {
            Player input = new Player("0", "UserName", email.text, passWord.text);

            Player player = await userManagement.Login(input);

            if (player != null)
            {
                UI_script.GetComponent<UI_System>().SwitchToScreen(screen);
                playerInfo.UpdatePlayer(player);
            }
        }
    }
}