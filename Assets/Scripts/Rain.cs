using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach to camera
public class Rain : MonoBehaviour
{
    public GameObject shower;

    void Update()
    {
        Vector3 camPos = gameObject.transform.position;
        shower.transform.position = new Vector3(camPos.x, camPos.y + 1.5f, camPos.z);
    }
}
