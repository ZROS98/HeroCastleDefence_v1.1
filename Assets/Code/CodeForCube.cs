using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeForCube : MonoBehaviour
{

    public void CharacterOnCube(GameObject myAvatar)
    {
        {
            GameObject _empty = gameObject;
            PhotonView _PV = GetComponent<PhotonView>();
            //int spawnPicker = Random.Range(0, GameSetup.GS.spawnPoints.Length);
            if (_PV.IsMine)
            {
                //_photonAvatar = PhotonNetwork.Instantiate(myAvatar.name,
                //    GameSetup.GS.spawnPoints[spawnPicker].position, GameSetup.GS.spawnPoints[spawnPicker].rotation, 0);

                GameObject p = PhotonNetwork.Instantiate(myAvatar.name, _empty.transform.position, _empty.transform.rotation);
                p.transform.SetParent(_empty.transform);

            }
            // _photonAvatar.GetComponent<Movement>().chrCamera = mainCamera;
            //  gameObject.GetComponent<TurnOffPlayerControl>().character = _photonAvatar;
        }
    }
}