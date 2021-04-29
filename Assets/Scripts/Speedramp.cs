using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;


//Script to apply effects to player on event such as going over speedramps
public class Speedramp : MonoBehaviour
{
    public float effectTime = 3.0f;
    public float changeAmount = 10.0f;

    private AudioSource audioSrc;
    private void Start()
    {
        audioSrc = gameObject.GetComponent<AudioSource>();
    }

    //When the player collides with this
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var _actor = collision.gameObject.transform.root.GetComponent<PlayerStats>();
            _actor.SetEffect(0, changeAmount, effectTime); //Speedup effect

            audioSrc.Play(); //Audio effect
        }
    }

    
}
