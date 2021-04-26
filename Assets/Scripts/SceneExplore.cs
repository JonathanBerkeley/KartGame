using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This is just for exploring the game in game mode, similar to the way you can
//in scene mode
public class SceneExplore : MonoBehaviour
{
    Vector2 pubRotation = Vector2.zero;
    [Range(0.5f, 10.0f)]
    public float cameraSpeed = 2f;
    [Range(0.5f, 100.0f)]
    public float moveSpeed = 2f;

    private bool noLook = false;
    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        //ForceCollide();
        MouseLook();
        EventKeys();
    }

    void EventKeys()
    {
        if (Input.GetKeyDown(KeyCode.W))
            StartCoroutine(nameof(Forward));

        if (Input.GetKeyDown(KeyCode.S))
            StartCoroutine(nameof(Back));

        if (Input.GetKeyDown(KeyCode.A))
            StartCoroutine(nameof(Left));

        if (Input.GetKeyDown(KeyCode.D))
            StartCoroutine(nameof(Right));

        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(nameof(Space));

        if (Input.GetKeyDown(KeyCode.LeftControl))
            StartCoroutine(nameof(Ctrl));

        if (Input.GetKeyDown(KeyCode.LeftShift))
            LShift();

        if (Input.GetKeyUp(KeyCode.LeftShift))
            moveSpeed /= 2;
    }

    IEnumerator Forward()
    {
        for (; ; )
        {
            if (Input.GetKeyUp(KeyCode.W))
                break;
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator Back()
    {
        for (; ; )
        {
            if (Input.GetKeyUp(KeyCode.S))
                break;
            transform.position -= transform.forward * moveSpeed * Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator Left()
    {
        for (; ; )
        {
            if (Input.GetKeyUp(KeyCode.A))
                break;
            Vector3 forward = new Vector3(transform.forward.x, transform.forward.y, transform.forward.z);
            Vector3 up = new Vector3(0.0f, 1.0f, 0.0f);
            Vector3 left = Vector3.Cross(forward.normalized, up.normalized);
            transform.position += left * moveSpeed * Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator Right()
    {
        for (; ; )
        {
            if (Input.GetKeyUp(KeyCode.D))
                break;
            Vector3 forward = new Vector3(transform.forward.x, transform.forward.y, transform.forward.z);
            Vector3 up = new Vector3(0.0f, 1.0f, 0.0f);
            Vector3 right = Vector3.Cross(forward.normalized, up.normalized);
            transform.position -= right * moveSpeed * Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator Space()
    {
        for (; ; )
        {
            if (Input.GetKeyUp(KeyCode.Space))
                break;
            transform.position = new Vector3(transform.position.x, transform.position.y + (moveSpeed / 100), transform.position.z);
            yield return null;
        }
    }
    IEnumerator Ctrl()
    {
        for (; ; )
        {
            if (Input.GetKeyUp(KeyCode.LeftControl))
                break;
            transform.position = new Vector3(transform.position.x, transform.position.y - (moveSpeed / 100), transform.position.z);
            yield return null;
        }
    }

    void LShift()
    {
        moveSpeed *= 3;
    }

    void MouseLook()
    {
        //Pause mouselook key
        if (Input.GetKeyDown(KeyCode.P))
            noLook = !noLook;

        if (!noLook)
        {
            Cursor.lockState = CursorLockMode.Locked;
            pubRotation.y += Input.GetAxis("Mouse X");
            pubRotation.x += Input.GetAxis("Mouse Y") - (Input.GetAxis("Mouse Y") * 2);
            transform.eulerAngles = pubRotation * cameraSpeed;
        }
        else
            Cursor.lockState = CursorLockMode.None;
    }
}