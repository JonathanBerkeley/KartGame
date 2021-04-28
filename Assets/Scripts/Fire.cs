using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to flicker light intensity
public class Fire : MonoBehaviour
{
    public float min = 4.5f;
    public float max = 10.0f;
    public float duration = 10.0f;


    private Light fireLight;
    private float t = 0.0f;
    private void Start()
    {
        fireLight = gameObject.GetComponent<Light>();
    }
    private void Update()
    {

        fireLight.intensity = Mathf.Lerp(min, max, t);
        if (t <= 1)
        {
            t += Time.deltaTime / duration;
        }
        else
        {
            t = Random.Range(0.0f, 0.9f);
        }
    }
}
