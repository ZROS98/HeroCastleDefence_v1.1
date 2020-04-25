using System;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeForCube : MonoBehaviour
{
    private PhotonView _PV;
    private void Start()
    {
        _PV = gameObject.GetComponent<PhotonView>();
    }

    public void CharacterOnCube(GameObject myAvatar)
    {
        GameObject _empty = gameObject;
        GameObject[] ArrayEmptyObjects = GameObject.FindGameObjectsWithTag("Empty");
        foreach (GameObject emptyObject in ArrayEmptyObjects)
        {
            if (emptyObject.GetComponent<PhotonView>().Owner != gameObject.GetComponent<PhotonView>().Owner)
            {
                _empty = emptyObject;
            }
            else continue;
        }

            GameObject p = PhotonNetwork.Instantiate(myAvatar.name, _empty.transform.position, _empty.transform.rotation);
            p.transform.SetParent(_empty.transform);
        
    }
}
