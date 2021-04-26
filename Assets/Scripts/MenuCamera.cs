using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    public GameObject focusTarget;
    public float rotateSpeed = 5.0f;

    void Update()
    {
        transform.RotateAround(focusTarget.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
    }

    //For other scripts to change, returns previous speed
    public float SetRotateSpeed(float speed)
    {
        float _previous = this.rotateSpeed;
        this.rotateSpeed = speed;
        return _previous;
    }
}
