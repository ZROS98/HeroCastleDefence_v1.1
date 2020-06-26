using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHighlightingOnAim : MonoBehaviour
{
    [SerializeField] private Material _materialWithHighlight;
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Renderer _renderer;

    [SerializeField] private GameObject _circle;

    //On Mob Destroy we also need to destroy Materials
    private void Start()
    {
        _circle.SetActive(false);
    }

    private void OnEnable()
    {
        EventManager.current.MobHighlightingStatusChanged += HighlightingChange;
    }

    private void OnDisable()
    {
        EventManager.current.MobHighlightingStatusChanged -= HighlightingChange;
    }


    private void HighlightingChange(bool highlightingStatus)
    {
        Debug.Log(highlightingStatus + " = HS");
        if (highlightingStatus) 
        {
            _circle.SetActive(true);
            _renderer.material = _materialWithHighlight;
        }
        else
        {
            _circle.SetActive(false);
            _renderer.material = _defaultMaterial;
        }
    }

}
