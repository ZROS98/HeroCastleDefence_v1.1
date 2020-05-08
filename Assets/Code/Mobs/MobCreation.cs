using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobCreation : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    private GameObject _varMob;
    

    public void CreateMob(GameObject selectedMob)
    {
        Vector3 force = Vector3.forward;
        Vector3 torque = Vector3.forward;
        object[] instantiationData = { force, torque, true };
        _varMob = PhotonNetwork.Instantiate(selectedMob.name, spawnPoint.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f), 0, instantiationData);
    }
}
