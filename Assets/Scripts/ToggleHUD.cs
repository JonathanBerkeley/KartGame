using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleHUD : MonoBehaviour
{
    private GameObject rearMirror;
    private GameObject miniMap;
    private bool mirrorIsVisible = false;
    
    private bool mapIsVisible = true;

    void Start()
    {
        GameObject canvasObject = GameObject.FindGameObjectWithTag("Canvas");
        CanvasBasket easyReferences = canvasObject.GetComponent<CanvasBasket>();
        rearMirror = easyReferences.rearMirror;
        miniMap = easyReferences.miniMap;

        mirrorIsVisible = false;
        mapIsVisible = true;
    }
    void Update()
    {
        // if the mirror variable is true show the mirror, if false hide the mirror.
        if(mirrorIsVisible) 
        {
            rearMirror.SetActive(true);
        } else 
        {
            rearMirror.SetActive(false);
        }
        // if the map variable is true show the map, if false hide the map.        
        if(mapIsVisible)
        {
            miniMap.SetActive(true);
        } else 
        {
            miniMap.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.R)) 
        {
            if(mirrorIsVisible)
            {
                mirrorIsVisible = false;
            } else 
            {
                mirrorIsVisible = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.M)) 
        {
            if(mapIsVisible)
            {
                mapIsVisible = false;
            } else 
            {
                mapIsVisible = true;
            }
        }
    }
    

}
