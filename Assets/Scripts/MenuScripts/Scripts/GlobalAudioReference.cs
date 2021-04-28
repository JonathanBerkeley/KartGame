using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * The purpose of this class is to always maintain an easily accessible reference to the current audio listener, so that
 * other scripts can affect the current audio listener that the player is using, without needing to reobtain a reference
 */
public class GlobalAudioReference : MonoBehaviour
{
    public static float masterVolume = 0.5f;
    public static float effectsVolume = 0.5f;

    private AudioListener currentAudioListener;
    public static GlobalAudioReference instance;

    private void Awake()
    {
        //Make singleton
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    void Start()
    {
        currentAudioListener = GetComponent<AudioListener>();
        AudioListener.volume = masterVolume;
    }

    public void SetMasterVolume(float _vol)
    {
        masterVolume = _vol;
        AudioListener.volume = _vol;
    }

    public void SetEffectsVolume(float _vol)
    {
        effectsVolume = _vol;
    }

    public float GetMasterVolume()
    {
        return masterVolume;
    }

    public float GetEffectsVolume()
    {
        return effectsVolume;
    }

    
}
