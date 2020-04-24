/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffPlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject[] _panels;
    public GameObject character;//character witch owner the current gamer. Need to appoint from instantiate 
    private int _amountActivePanels;
    private Movement componentMovement;
    private ShootingMechanics componentShootingMechanics;

    void Start()
    {
        componentMovement = character.GetComponent<Movement>();
        componentShootingMechanics = character.GetComponentInChildren<ShootingMechanics>();
    }

    void Update()
    {
        foreach (GameObject panel in _panels)
        {
            if (panel.active)
            {
                componentMovement.enabled = false;
                componentShootingMechanics.enabled = false;
            }
            else
            {
                componentMovement.enabled = true;
                componentShootingMechanics.enabled = true;
            }
        }
    }
}*/