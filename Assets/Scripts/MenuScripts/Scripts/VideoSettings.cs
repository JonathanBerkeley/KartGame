using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoSettings : MonoBehaviour
{
    public static VideoSettings instance;

    public Toggle fullScreen;
    public Toggle fog;
    public Dropdown resolution;

    private static bool fsInitial, fogInitial;
    private static int resInitial = 0;

    void Start()
    {
        //Make singleton
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already in existence, destroying self");
            Destroy(this);
        }

        fsInitial = Screen.fullScreen;

        resInitial = 1;
        
        fullScreen.onValueChanged.AddListener(
            delegate {
                MaintainSelections(0); 
            });

        resolution.onValueChanged.AddListener(
            delegate
            {
                MaintainSelections(2);
            });
    }

    private void Update()
    {
        fullScreen.isOn = fsInitial;
        resolution.value = resInitial;
    }

    private void MaintainSelections(int forObject)
    {
        switch (forObject)
        {
            case 0:
                //Fullscreen
                fsInitial = fullScreen.isOn;
                break;
            case 1:
                //Fog
                break;
            case 2:
                //Resolution
                resInitial = resolution.value;
                break;
            default:
                break;
        }
    }

    //Changed dynamically by checkbox
    public void ChangeFullscreen(bool status)
    {
        Screen.fullScreen = status;
    }

    //Changed dynamically by dropdown
    public void ChangeResolution(int res)
    {
        switch (res)
        {
            case 0:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                resInitial = 0;
                break;
            case 1:
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                resInitial = 1;
                break;
            case 2:
                Screen.SetResolution(800, 600, Screen.fullScreen);
                resInitial = 2;
                break;
            default:
                break;
        }
    }

    public int GetResolution()
    {
        return resInitial;
    }

    public int GetFullscreen()
    {
        return (fsInitial) ? 1 : 0;
    }
    
}
