using UnityEngine;
using TMPro;
using Photon.Pun;

public class TimeToLoadArenaScene : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private LoadArenaScene _loadArenaScene;
    [SerializeField] private TextMeshProUGUI _timerText;
    private float _secondsToLoad;

    void Start()
    {
        _secondsToLoad = _loadArenaScene.secondsToCreation + 1;
    }

    public void StartTimer()
    {
        _photonView.RPC("StartTimerRPC", RpcTarget.AllBuffered);
    }

    [PunRPC]
    private void StartTimerRPC()
    {
        InvokeRepeating("Timer", 0, 1f);
    }

    private void Timer()
    {
        _secondsToLoad = _secondsToLoad - 1;
        _timerText.text = _secondsToLoad.ToString();
    }
}
