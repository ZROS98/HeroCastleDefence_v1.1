using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UpdateInterface : MonoBehaviour
{
    [SerializeField] private CharacterInfo _characterInfo;
    private Slider _hpSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        _hpSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
      //  _hpSlider.value = _characterInfo._healthPoint / 100;
    }
}
