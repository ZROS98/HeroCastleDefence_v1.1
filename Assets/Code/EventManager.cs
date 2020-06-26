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
    public event Action<bool> MobHighlightingStatusChanged;

    public void OnMobHighlightingTurnOn()
    {
        MobHighlightingStatusChanged?.Invoke(true);
    }

    public void OnMobHighlightingTurnOff()
    {
        MobHighlightingStatusChanged?.Invoke(false);
    }
    #endregion
}
