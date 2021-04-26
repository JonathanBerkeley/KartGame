using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpin : MonoBehaviour
{
    [Header("Speed to spin individual sub cube")]
    public float spinSpeed = 200.0f; //Speed that this cube will spin

    public bool forwardSpin = true;

    void Update()
    {
        //Spinning animation
        if (forwardSpin)
            transform.Rotate(0, 0, spinSpeed * Time.deltaTime, Space.Self);
        else
            transform.Rotate(0, 0, -spinSpeed * Time.deltaTime, Space.Self);
    }
}
