using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int respawnDelay = 10;
    public int regenAmount = 100;
    public AudioClip[] packAudio;

    [Header("0 for random effect")]
    public int effect = 0;

    //Detecting if a player touches Pickup
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 9)
        {
            //Increases the player's health that touches the health pack
            //collision.gameObject.GetComponent<PlayerStats>().IncreaseHealth(regenAmount);

            //Effect code goes here
            if (effect == 0)
            {
                Random.Range(0, 1);
            }

            StartCoroutine(RespawnPickup());
        }
    }

    IEnumerator RespawnPickup()
    {
        //Play regenerate sound
        AudioSource.PlayClipAtPoint(packAudio[1], transform.position);

        //Hide under world
        transform.position = new Vector3(
            transform.position.x
            , transform.position.y - 1000
            , transform.position.z);

        //Wait for two seconds efficiently
        yield return new WaitForSeconds(respawnDelay);

        //Reset to position
        transform.position = new Vector3(
            transform.position.x
            , transform.position.y + 1000
            , transform.position.z);

        //Play respawn sound
        AudioSource.PlayClipAtPoint(packAudio[0], transform.position);
    }
}