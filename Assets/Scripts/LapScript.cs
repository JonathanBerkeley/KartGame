using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapScript : MonoBehaviour
{
    private int currentLap = 1;
    private static bool returnControl = true;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && returnControl)
        {
            var _actor = collision.gameObject.transform.root.GetComponent<UpdateUI>();
            if (_actor == null)
                return;
            returnControl = false;
            ++currentLap;
            StartCoroutine(LapCount());

            _actor.SetLap(currentLap);

            if (currentLap == 3)
            {
                Debug.Log("3rd lap");
            }
            returnControl = true;
        }
    }

    IEnumerator LapCount()
    {
        yield return new WaitForSeconds(15.0f);
        returnControl = true;
    }
}
