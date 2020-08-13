
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CurrentCharacter
{
    public static GameObject currentCharacter;
  /*  {
        get
        {
            return currentCharacter;
        }
        set
        {
            currentCharacter = value;
        }
    }*/

 /*   public static GameObject GetCurrentCharacter()
    {
        int characterID = (PhotonNetwork.IsMasterClient ? 0 : 1);
        return charactersArray[1];
    }

    public static void SetCurrentCharacter(GameObject currentCharacter)
    {
        int characterID = (PhotonNetwork.IsMasterClient ? 0 : 1);
        charactersArray[1] = currentCharacter;
    }*/
}
