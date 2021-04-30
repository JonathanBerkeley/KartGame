using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapScript : MonoBehaviour
{
    private int currentLap = 1;
    //private bool returnControl = true;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var _actor = collision.gameObject.transform.root.GetComponent<UpdateUI>();
            if (_actor == null)
                return;

            //returnControl = false;
            if (++currentLap > 3)
            {
                PlayerLevel.playerXp += 100.0f;
                PlayerPrefs.SetFloat("Level", PlayerLevel.playerXp);
                PlayerPrefs.Save();
                _actor.EnableWinUI();
                return;
            }

            //StartCoroutine(LapCount());

            _actor.SetLap(currentLap);

            //returnControl = true;
        }
    }

    /*
    IEnumerator LapCount()
    {
        yield return new WaitForSeconds(15.0f);
    }
    */
}
