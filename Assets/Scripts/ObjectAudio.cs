using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enforces the global effect audio for specific audio emitting objects
public class ObjectAudio : MonoBehaviour
{
    void Start()
    {
        foreach (AudioSource asGo in gameObject.GetComponents<AudioSource>())
        {
            asGo.volume = GlobalAudioReference.effectsVolume;
        }
    }
}
