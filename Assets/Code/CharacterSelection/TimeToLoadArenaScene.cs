using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using TMPro;

public class TimeToLoadArenaScene : MonoBehaviour
{
    [SerializeField] private LoadArenaScene _loadArenaScene;
    [SerializeField] private TextMeshProUGUI _timerText;
    private float _secondsToLoad;

    void Start()
    {
        _secondsToLoad = _loadArenaScene.secondsToCreation;
    }

    public void StartTimer()
    {
        Timer timer = new Timer(_secondsToLoad);
        timer.Elapsed += (object sender, ElapsedEventArgs e) => _secondsToLoad--;
        _timerText.text = _secondsToLoad.ToString();
    }
}
