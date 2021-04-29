using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

public class PlayerStats : MonoBehaviour
{
    public int currentPowerup = -1; //-1 means no powerup

    private string[] powerups = { "Speedboost", "Jumpboost" };

    private ArcadeKart arcadeKartStats;
    private void Start()
    {
        arcadeKartStats = gameObject.GetComponent<ArcadeKart>();
    }

    void Update()
    {
        if (Input.GetButtonDown("UsePowerup"))
        {
            switch (currentPowerup)
            {
                case -1:
                case 0:
                    break;
                case 1:
                    arcadeKartStats.baseStats.TopSpeed += 5.0f;
                    arcadeKartStats.baseStats.Acceleration += 5.0f;
                    break;
                case 2:
                    arcadeKartStats.baseStats.TopSpeed += 5.0f;
                    arcadeKartStats.baseStats.Acceleration += 5.0f;
                    break;

                default:
                    break;
            }

            Debug.Log("Used powerup: " + powerups[currentPowerup]);
            currentPowerup = -1;
        }
    }

    public void SetPowerup(int _power)
    {
        if (_power == 0)
        {
            currentPowerup = Random.Range(1, powerups.Length);
        }
        else
        {
            currentPowerup = _power;
        }
    }

    public int GetPowerup()
    {
        return currentPowerup;
    }
}
