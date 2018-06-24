using UnityEngine;
using Assets.Backend.Models;
using Assets.Backend;
using System;
using System.Collections;
using System.Collections.Generic;

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

        public delegate void BuildingImageUpdateEvent();
        public static event BuildingImageUpdateEvent buildingImageUpdateEvent;

        public delegate void ResourceUpdateEvent(ResourceType resourceType, int amount);
        public static event ResourceUpdateEvent resourceUpdateEvent;

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

        public static void BuildingImageUpdate()
        {
            if (buildingImageUpdateEvent != null)
                buildingImageUpdateEvent();
        }
    }
}