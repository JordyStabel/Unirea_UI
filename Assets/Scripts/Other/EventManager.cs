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

        public delegate void MapUpdateEvent();
        public static event MapUpdateEvent mapUpdateEvent;

        public delegate void TownUpdateEvent();
        public static event TownUpdateEvent townUpdateEvent;

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

        public static void MapUpdate()
        {
            if (mapUpdateEvent != null)
                mapUpdateEvent();
        }
        public static void TownUpdate()
        {
            if (townUpdateEvent != null)
                townUpdateEvent();
        }
    }
}