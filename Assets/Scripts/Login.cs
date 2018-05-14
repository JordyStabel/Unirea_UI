using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour {

    public InputField userName;
    public InputField passWord;
	
    public void UserLogin()
    {
        Debug.Log(userName.text + " / " + passWord.text);
        // User login code here
    }
}