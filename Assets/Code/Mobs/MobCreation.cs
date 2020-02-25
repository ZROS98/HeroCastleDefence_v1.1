using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobCreation : MonoBehaviour
{
    public GameObject mob;
    private Vector3 _position = Vector3.zero;
    public GameObject varMob;

    public void CreateMob()
    {
        Vector3 force = Vector3.forward;
        Vector3 torque = Vector3.forward;
        object[] instantiationData = { force, torque, true };
        varMob = PhotonNetwork.Instantiate(mob.name, _position, Quaternion.Euler(0.0f, 0.0f, 0.0f), 0, instantiationData);
    }
}
