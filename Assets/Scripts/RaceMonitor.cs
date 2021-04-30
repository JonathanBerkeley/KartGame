using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;

public class RaceMonitor : MonoBehaviourPunCallbacks
{
    public GameObject startRace;
    int playerCar;

    void Start()
    {
        startRace.SetActive(false);
        if (PhotonNetwork.IsConnected)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                startRace.SetActive(true);
            }
        }
    }
}
