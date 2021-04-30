using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For other scripts to identify the camera
public class CamID : MonoBehaviour
{
    public int id = 0;

    private void Start()
    {
        float _contrast = 25.0f * OptionsMenu.FieldOfViewModifier;
        gameObject.GetComponent<Camera>().fieldOfView += _contrast;
    }
}
