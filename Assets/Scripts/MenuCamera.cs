using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    public GameObject[] focusTargets;
    public float rotateSpeed = 5.0f;
    public float initialDistance = 100.0f;

    private GameObject focusTarget;
    private void Start()
    {
        int randomTarget = Random.Range(0, focusTargets.Length);
        focusTarget = focusTargets[randomTarget]; // Random map target to focus on

        if (randomTarget == 0)
        {
            Camera.main.transform.position =
                new Vector3(
                    focusTarget.transform.position.x,
                    Camera.main.transform.position.y - initialDistance,
                    focusTarget.transform.position.z - initialDistance
                );
        }
        else
        {
            Camera.main.transform.position =
                new Vector3(
                    focusTarget.transform.position.x,
                    Camera.main.transform.position.y - initialDistance * 4.5f,
                    focusTarget.transform.position.z - initialDistance * 1.5f
                );
        }
        
    }

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

    public float GetCameraSpeed()
    {
        return rotateSpeed;
    }
}
