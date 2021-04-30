using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

public class PlayerStats : MonoBehaviour
{
    public int currentPowerup = -1; //-1 means no powerup
    public float viewShiftOnAccelerate = 15.0f;

    private string[] powerups = { "Speedboost", "Low-Gravity" };

    private ArcadeKart arcadeKartStats;
    private ExtendedControls extraControls;
    private float currentPowerupTime = 0.0f; //Set by powerup script

    private UpdateUI updateUI;
    private void Start()
    {
        updateUI = gameObject.GetComponent<UpdateUI>();
        arcadeKartStats = gameObject.GetComponent<ArcadeKart>();
        extraControls = gameObject.GetComponent<ExtendedControls>();
    }

    void Update()
    {
        if (Input.GetButtonDown("UsePowerup") && currentPowerup != -1)
        {
            switch (currentPowerup)
            {
                case 0:
                    return;
                case 1:
                    arcadeKartStats.baseStats.TopSpeed += 5.0f;
                    arcadeKartStats.baseStats.Acceleration += 5.0f;
                    extraControls.SetCameraFOV(viewShiftOnAccelerate, currentPowerupTime);
                    StartCoroutine(UndoPowerup(1));
                    break;
                case 2:
                    arcadeKartStats.baseStats.AddedGravity -= 1.0f;
                    StartCoroutine(UndoPowerup(2));
                    break;
                case 3:
                    break;
                default:
                    break;
            }
            Debug.Log("Used powerup: " + powerups[currentPowerup - 1]);
            currentPowerup = -1;
        }
        else if (currentPowerup == -1)
        {
            if (updateUI != null)
            {
                updateUI.DisablePanel();
            }
        }
    }

    public void SetPowerup(int _power, float _time)
    {
        if (_power == 0)
        {
            currentPowerup = Random.Range(1, powerups.Length + 1);
        }
        else
        {
            currentPowerup = _power;
        }

        if (updateUI != null)
        {
            updateUI.SetText("Powerup: " + powerups[currentPowerup - 1]);
        }
            

        currentPowerupTime = _time;
    }

    public int GetPowerup()
    {
        return currentPowerup;
    }

    public void SetEffect(int _effectID, float _difference, float _timeToUndo)
    {
        switch (_effectID)
        {
            case 0:
                arcadeKartStats.baseStats.Acceleration += _difference;
                arcadeKartStats.baseStats.AccelerationCurve += _difference;
                arcadeKartStats.baseStats.TopSpeed += _difference;
                extraControls.SetCameraFOV(viewShiftOnAccelerate, 3.0f);
                StartCoroutine(UndoEffect(_effectID, _difference, _timeToUndo));
                break;
            default:
                break;
        }
    }

    //Reverses the effect after some time
    IEnumerator UndoEffect(int _effectID, float _difference, float _time)
    {
        yield return new WaitForSeconds(_time);
        switch (_effectID)
        {
            case 0:
                arcadeKartStats.baseStats.Acceleration -= _difference;
                arcadeKartStats.baseStats.AccelerationCurve -= _difference;
                arcadeKartStats.baseStats.TopSpeed -= _difference;
                break;
            default:
                break;
        }
    }

    IEnumerator UndoPowerup(int _powerupID)
    {
        yield return new WaitForSeconds(currentPowerupTime);
        //Undo powerup:
        switch (_powerupID)
        {
            case 0:
                break;
            case 1:
                arcadeKartStats.baseStats.TopSpeed -= 5.0f;
                arcadeKartStats.baseStats.Acceleration -= 5.0f;
                break;
            case 2:
                arcadeKartStats.baseStats.AddedGravity += 1.0f;
                break;
            default:
                break;
        }
    }
}
