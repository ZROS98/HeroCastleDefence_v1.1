using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CurrentCharacter
{
    public static GameObject[] charactersArray = new GameObject[2];

    public static GameObject GetCurrentCharacter()
    {
        int characterID = (PhotonNetwork.IsMasterClient ? 0 : 1);
        return charactersArray[characterID];
    }

    public static void SetCurrentCharacter(GameObject currentCharacter)
    {
        int characterID = (PhotonNetwork.IsMasterClient ? 0 : 1);
        charactersArray[characterID] = currentCharacter;
    }
}
