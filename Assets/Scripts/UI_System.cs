using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Unirea.UI
{
    public class UI_System : MonoBehaviour
    {
        #region Variable & Properties

        [Header("Properties")]
        public UI_Screen startScreen;

        [Header("Events")]
        public UnityEvent onScreenSwitch = new UnityEvent();

        [Header("Fader Properties")]
        public Image screenFader;
        public float fadeInTime = 1f;
        public float fadeOutTime = 1f;

        [SerializeField]
        private Component[] screens = new Component[0];

        private UI_Screen currentScreen;
        public UI_Screen CurrentScreen { get { return currentScreen; } }

        private UI_Screen previousScreen;
        public UI_Screen PreviouScreen { get { return previousScreen; } }

        #endregion


        #region Methods

        // Use this for initialization
        private void Start()
        {
            // Fill the screens array with all components of type 'UI_Screen'
            // True --> finds all inactive screens too
            screens = GetComponentsInChildren<UI_Screen>(true);

            InitializeScreens();

            // Make sure the start with the startscreen
            if (startScreen)
            {
                SwitchToScreen(startScreen);
            }

            // Make sure if there is a screenfader it's active
            if (screenFader)
            {
                screenFader.gameObject.SetActive(true);
            }

            FadeIn();
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SwitchToScreen(previousScreen);
            }
        }

        public void FadeIn()
        {
            if (screenFader)
            {
                screenFader.CrossFadeAlpha(0f, fadeInTime, false);
            }
        }

        public void FadeOut()
        {
            if (screenFader)
            {
                screenFader.CrossFadeAlpha(1f, fadeOutTime, false);
            }
        }

        /// <summary>
        /// Switch to a different screen
        /// </summary>
        /// <param name="screen"></param>
        public void SwitchToScreen(UI_Screen screen)
        {
            if (screen)
            {
                if (currentScreen)
                {
                    currentScreen.CloseScreen();
                    previousScreen = currentScreen;
                }

                currentScreen = screen;
                currentScreen.gameObject.SetActive(true);
                currentScreen.StartScreen();

                // If there are listeners --> start event
                if (onScreenSwitch != null)
                {
                    onScreenSwitch.Invoke();
                }
            }
        }

        /// <summary>
        /// Switch to the previous screen
        /// </summary>
        public void SwitchToPreviousScreen()
        {
            if (previousScreen != null)
            {
                SwitchToScreen(previousScreen);
            }
        }

        public void LoadScene(int sceneIndex)
        {
            StartCoroutine(WaitForLoadScene(sceneIndex));
        }

        IEnumerator WaitForLoadScene(int sceneIndex)
        {
            yield return null;
        }

        // Set all screen to active
        private void InitializeScreens()
        {
            foreach (UI_Screen screen in screens)
            {
                screen.gameObject.SetActive(true);
            }
        }

        #endregion
    }
}