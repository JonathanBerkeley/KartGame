using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    public GameObject panel;
    public Text powerUpText;
    public Text lapText;

    public void SetText(string _text)
    {
        panel.SetActive(true);
        powerUpText.text = _text;
    }

    public void DisablePanel()
    {
        panel.SetActive(false);
    }

    public void SetLap(int _text)
    {
        lapText.text = "Lap " + _text + "/3";
    }
}
