using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class DisplayEnemyPicture : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;
    private Hashtable _hash = new Hashtable();
    private Image _imageForEnemyAvatar;
    public Image myAvatarForEnemyPlayer;
    private void Start()
    {
        _hash.Add("EnemyPictureProperties", myAvatarForEnemyPlayer);
    }

    public void SetMyAvatarPictures(Sprite sprite)
    {
        _imageForEnemyAvatar.sprite = sprite;
        SetForEnemyAvatarsPicture();
    }

    private void SetForEnemyAvatarsPicture()
    {
        _hash["EnemyPictureProperties"] = myAvatarForEnemyPlayer;
        PhotonNetwork.SetPlayerCustomProperties(_hash);
        _photonView.RPC("SetForEnemyAvatarsPictureRPC", RpcTarget.OthersBuffered);
    }

    [PunRPC]
    private void SetForEnemyAvatarsPictureRPC()
    {
        _imageForEnemyAvatar = (Image) PhotonNetwork.PlayerListOthers[0].CustomProperties["EnemyPictureProperties"];
    }
}
