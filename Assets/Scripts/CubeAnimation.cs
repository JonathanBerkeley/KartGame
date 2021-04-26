using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAnimation : MonoBehaviour
{
    [Header("Speed to spin exclamation mark")]
    public float spinSpeed = 100.0f;
    [Header("Deviation from starting Y position")]
    public float maxBobDeviation = 0.1f;
    [Header("Speed to raise up and down")]
    public float bobSpeed = 0.3f;

    private float initialY;
    private bool bobDirection;

    private void Start()
    {
        initialY = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Spinning animation
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime, Space.Self);

        #region bobbing animation code
        if (transform.position.y >= initialY + maxBobDeviation)
        {
            bobDirection = true;
        }
        else if (transform.position.y <= initialY - maxBobDeviation)
        {
            bobDirection = false;
        }

        if (bobDirection)
        {
            transform.position = new Vector3(transform.position.x,
                transform.position.y - bobSpeed * Time.deltaTime,
                transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x,
                transform.position.y + bobSpeed * Time.deltaTime,
                transform.position.z);
        }
        #endregion

    }
}
