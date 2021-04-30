using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Resets position and rotation if kart makes it out of bounds
public class ResetPos : MonoBehaviour
{
    public Vector3 goToPosition = new Vector3(0, 0, 0);
    public Vector3 setRotation = new Vector3(0, 0, 0);

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.root.position = goToPosition;
            collision.gameObject.transform.root.eulerAngles = setRotation;
        }
    }
}
