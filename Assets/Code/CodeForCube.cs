using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeForCube : MonoBehaviour
{

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
            
            PhotonView _PV = GetComponent<PhotonView>();
            if (_PV.IsMine)
            {
                GameObject p = PhotonNetwork.Instantiate(myAvatar.name, _empty.transform.position, _empty.transform.rotation);
                p.transform.SetParent(_empty.transform);
            }
        }
    }
