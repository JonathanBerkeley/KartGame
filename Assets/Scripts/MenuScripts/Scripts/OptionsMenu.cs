using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public static float FieldOfViewModifier = 0.5f;

    public Button[] mainTabs;
    public int defaultSelected = 0;
    public GameObject[] innerMenus;

    private int _currentlySelected;
    void Start()
    {
        if (defaultSelected >= mainTabs.Length)
        {
            defaultSelected = 0;
        }
        _currentlySelected = defaultSelected;
        
        if (innerMenus.Length < mainTabs.Length)
        {
            Debug.LogError("Options menu - mismatch of tabs to menus");
        }

        EnableSelected();
    }

    void Update()
    {
        mainTabs[_currentlySelected].Select();
    }

    public void SetSelected(int _select)
    {
        _currentlySelected = _select;
        EnableSelected();

        if (_currentlySelected == 1 && innerMenus[1] != null)
        {
            //Sets sliders visually to respective values
            Slider[] audioSliders = innerMenus[1].GetComponentsInChildren<Slider>(); //Obtains the references to sliders
            audioSliders[0].value = GlobalAudioReference.instance.GetMasterVolume(); //Master volume
            audioSliders[1].value = GlobalAudioReference.instance.GetEffectsVolume(); //Effects volume
        }
            
    }

    //Referenced dynamically by volume slider
    public void SetMasterVolume(float _volume)
    {
        if (GlobalAudioReference.instance != null)
            GlobalAudioReference.instance.SetMasterVolume(_volume);
    }

    public void SetEffectsVolume(float _volume)
    {
        if (GlobalAudioReference.instance != null)
            GlobalAudioReference.instance.SetEffectsVolume(_volume);
    }
    
    public void SetDesiredFOV(float _fov)
    {
        FieldOfViewModifier = _fov;
    }


    private void EnableSelected()
    {
        for (int i = 0; i < innerMenus.Length; ++i)
        {
            if (i != _currentlySelected)
            {
                innerMenus[i].SetActive(false);
            }
            else
            {
                innerMenus[i].SetActive(true);
            }
        }
    }
}
