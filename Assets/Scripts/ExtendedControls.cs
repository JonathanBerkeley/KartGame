using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedControls : MonoBehaviour
{
    public GameObject thirdPersonCam;
    public GameObject firstPersonCam;

    private bool currentCam; // False = thirdperson

    private void Start()
    {
        // Initial configuration
        currentCam = false;
        thirdPersonCam.SetActive(true);
        firstPersonCam.SetActive(false);
    }

    void Update()
    {
        // Look for button press
        if (Input.GetButtonDown("ChangeCamera"))
        {
            if (currentCam)
            {
                firstPersonCam.SetActive(false);
                thirdPersonCam.SetActive(true);
            }
            else
            {
                firstPersonCam.SetActive(true);
                thirdPersonCam.SetActive(false);
            }
            currentCam = !currentCam;
        }
    }

    public void SetCameraFOV(float _change, float _resetTime)
    {
        int _id = Camera.main.gameObject.GetComponent<CamID>().id;

        switch (_id)
        {
            case 0:
                // Thirdperson cam
                thirdPersonCam.GetComponent<Camera>().fieldOfView += _change;
                StartCoroutine(ResetCam(_id, _change, _resetTime));
                break;
            case 1:
                // Firstperson cam
                firstPersonCam.GetComponent<Camera>().fieldOfView += _change;
                StartCoroutine(ResetCam(_id, _change, _resetTime));
                break;
            default:
                break;
        }
    }

    // Reset camera FOV after some time
    IEnumerator ResetCam(int _id, float _change, float _time)
    {
        yield return new WaitForSeconds(_time);
        switch (_id)
        {
            case 0:
                // Thirdperson cam
                thirdPersonCam.GetComponent<Camera>().fieldOfView -= _change;
                break;
            case 1:
                // Firstperson cam
                firstPersonCam.GetComponent<Camera>().fieldOfView -= _change;
                break;
            default:
                break;
        }
    }
}
