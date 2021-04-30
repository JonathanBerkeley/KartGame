using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    private GameObject panel;
    private Text powerUpText;
    private Text lapText;
    private GameObject endPhase;

    private void Start()
    {
        GameObject canvasObject = GameObject.FindGameObjectWithTag("Canvas");
        CanvasBasket easyReferences = canvasObject.GetComponent<CanvasBasket>();
        panel = easyReferences.panel;
        powerUpText = easyReferences.powerUpText;
        lapText = easyReferences.lapText;
        endPhase = easyReferences.endPhase;
        endPhase.SetActive(false);
    }

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

    public void EnableWinUI()
    {
        Timer.Win();
        PauseMenu.GameIsComplete = true;
        // endPhase.SetActive(true);
    }
}
