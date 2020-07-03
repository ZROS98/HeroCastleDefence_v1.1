using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    private void Awake()
    {
        current = this;
    }

    #region CharacterEvents
    /// <summary>
    /// true = respawn, false = death
    /// </summary>
    public event Action<bool> LifeStatusChanged;
    public void OnLifeStatusDeath()
    {
        LifeStatusChanged?.Invoke(false);
    }

    public void OnLifeStatusRespawn()
    {
        LifeStatusChanged?.Invoke(true);
    }
    #endregion

    #region MobEvents
    /// <summary>
    /// true = turn On, false = turn Off
    /// </summary>
    public event Action<bool, int> MobHighlightingStatusChanged;

    public void OnMobHighlightingTurnOn(int mobEventID)
    {
        MobHighlightingStatusChanged?.Invoke(true, mobEventID);
    }

    public void OnMobHighlightingTurnOff(int mobEventID)
    {
        MobHighlightingStatusChanged?.Invoke(false, mobEventID);
    }
    #endregion

//    #region ShopEvents
//
//    public event Action<bool, int> ShopHighlightingStatusChanged;
//
//    public void OnShopHighlightingTurnOn(int shopEventID)
//    {
//        ShopHighlightingStatusChanged?.Invoke(true, shopEventID);
//    }
//    public void OnShopHighlightingTurnOff(int shopEventID)
//    {
//        ShopHighlightingStatusChanged?.Invoke(false, shopEventID);
//    }
//    
//
//    #endregion

    #region CharacterAimChanged 

    public event Action<Transform> CharacterAimChanged;

    public void OnCharacterAimChanged(Transform mob)
    {
        CharacterAimChanged?.Invoke(mob);
    }

    #endregion
}
