using System.Collections;
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
            Debug.Log(panel);
            if (panel.active)
            {
                _amountActivePanels += 1;            
            }
            else if (_amountActivePanels > 0)
            {
                _amountActivePanels -= 1;
            }
        }

        if (_amountActivePanels>0)
        {
            componentMovement.enabled = false;
            componentShootingMechanics.enabled = false;
            Debug.Log("MovOff");
        }
        else
        {
            componentMovement.enabled = true;
            componentShootingMechanics.enabled = true;
        }
    }
}
