using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class DisplayEnemyPicture : MonoBehaviour
{
    [SerializeField] Sprite[] _avatarsPictureArray;
    [SerializeField] private PhotonView _photonView;
    private Hashtable _hash = new Hashtable();
    [SerializeField] private Image _imageForEnemyAvatar;
    public int myAvatarNumberForEnemyPlayer;

    private void Start()
    {
        _hash.Add("AvatarNumberForEnemyPictureProperties", myAvatarNumberForEnemyPlayer);
    }

    public void SetMyAvatarPicturesNumber(int avatarNumber)
    {
        myAvatarNumberForEnemyPlayer = avatarNumber;
        SetAvatarNumberForEnemyPictureProperties();
    }

    private void SetAvatarNumberForEnemyPictureProperties()
    {
        _hash["AvatarNumberForEnemyPictureProperties"] = myAvatarNumberForEnemyPlayer;
        PhotonNetwork.SetPlayerCustomProperties(_hash);
        _photonView.RPC("SetAvatarNumberForEnemyPicturePropertiesRPC", RpcTarget.Others);
    }

    [PunRPC]
    private void SetAvatarNumberForEnemyPicturePropertiesRPC()
    {
        int avatarNumber = (int) PhotonNetwork.PlayerListOthers[0].CustomProperties["AvatarNumberForEnemyPictureProperties"];
        _imageForEnemyAvatar.sprite = _avatarsPictureArray[avatarNumber];
    }
}
