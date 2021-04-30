using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    //private bool triggered = false;


    private void OnTriggerExit(Collider other)
    {
        KartAi bot;
        other.gameObject.transform.root.TryGetComponent<KartAi>(out bot);
        
        if (bot == null)
            return;

        StartCoroutine(BotLook(bot));
    }


    IEnumerator BotLook(KartAi _bot)
    {
        yield return new WaitForSeconds(0.3f);
        _bot.SetLook();
    }
}
