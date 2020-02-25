using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobInfo : MonoBehaviour
{
    public int _healthPoint = 100;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (_healthPoint<1)
        {
            //DestroyMob();
            PhotonView.Get(this).RPC("DestroyMob", RpcTarget.All);
        }
    }

    [PunRPC]
    private void DestroyMob()
    {
        PhotonNetwork.Destroy(gameObject);
    }

    private void TakedDamage(int damage)
    {
        _healthPoint -= damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            TakedDamage(collision.gameObject.GetComponent<WeaponInfo>().damage);
        }
    }


}
