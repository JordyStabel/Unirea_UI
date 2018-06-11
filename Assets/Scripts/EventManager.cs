using UnityEngine;
using Assets.Backend.Models;

namespace Unirea.UI
{
    public class EventManager : MonoBehaviour
    {
        public delegate void PlayerUpdateEvent();
        public static event PlayerUpdateEvent playerUpdateEvent;

        public delegate void ScreenUpdateEvent();
        public static event ScreenUpdateEvent screenUpdateEvent;

        public static void PlayerUpdate()
        {
            if (playerUpdateEvent != null)
                playerUpdateEvent();
        }

        public static void ScreenUpdate()
        {
            if (screenUpdateEvent != null)
                screenUpdateEvent();
        }
    }
}