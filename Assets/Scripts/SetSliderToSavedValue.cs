using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSliderToSavedValue : MonoBehaviour
{
    private Slider fovSlider;
    void Start()
    {
        fovSlider = gameObject.GetComponent<Slider>();
        
    }

    private void Update()
    {
        fovSlider.value = OptionsMenu.FieldOfViewModifier;
    }

}
