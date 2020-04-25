using System;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeForCube : MonoBehaviour
{
    private GameObject _selectedPrefab;


    private void Start()
    {
        _selectedPrefab = SelectedCharacter.Prefab;
        CharacterOnCube();
    }
    public void CharacterOnCube()
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

            GameObject p = PhotonNetwork.Instantiate(_selectedPrefab.name, _empty.transform.position, _empty.transform.rotation);
            p.transform.SetParent(_empty.transform);
    }
}
