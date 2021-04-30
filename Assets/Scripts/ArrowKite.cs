using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKite : MonoBehaviour
{
    public GameObject target;

    private float initialHeight;
    private void Awake()
    {
        initialHeight = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(
            target.transform.position.x, 
            initialHeight, 
            target.transform.position.z
        );

        gameObject.transform.forward = -target.transform.forward;
    }
}
