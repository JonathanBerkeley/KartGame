using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAdapt : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Text>().text = "Player level: " + PlayerLevel.GetLevel();
    }
}
