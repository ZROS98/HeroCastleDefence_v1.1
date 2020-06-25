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

    /// <summary>
    /// true = respawn. False = death
    /// </summary>
    public event Action<bool> LifeStatusChanged;
    private void OnLifeStatusDeath()
    {
        LifeStatusChanged?.Invoke(false);
    }

    private void OnLifeStatusRespawn()
    {
        LifeStatusChanged?.Invoke(true);
    }
}
