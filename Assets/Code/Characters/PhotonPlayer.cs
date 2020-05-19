using Photon.Pun;
using UnityEngine;

public class PhotonPlayer : MonoBehaviourPunCallbacks
{
    public GameObject mainCamera;
    private PhotonView _PV;
    public GameObject SliderButton;

    
    public void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        _PV = gameObject.GetComponent<PhotonView>();
        //_PV.RPC("SpawnCharacter", RpcTarget.AllBuffered);
        SpawnCharacter();
    }

    //[PunRPC]
    private void SpawnCharacter() //do it once
    {
        /* GameObject currentCharacter = PhotonNetwork.Instantiate(SelectedCharacter.Prefab.name,
             new Vector3(25,1,85), Quaternion.identity);


         currentCharacter.GetComponent<Movement>().chrCamera = mainCamera;
         gameObject.GetComponent<TurnOffPlayerControl>().charactersArray.Add(currentCharacter);
         currentCharacter.GetComponent<CharacterInfo>().SliderButton = SliderButton;*/

        GameObject currentCharacter = PhotonNetwork.Instantiate(SelectedCharacter.Prefab.name,
            new Vector3(25, 1, 85), Quaternion.identity);


        currentCharacter.GetComponent<Movement>().chrCamera = mainCamera;
        gameObject.GetComponent<TurnOffPlayerControl>().charactersArray.Add(currentCharacter);
        currentCharacter.GetComponent<CharacterInfo>().SliderButton = SliderButton;

    }
    
}