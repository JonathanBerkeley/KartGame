using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text previousBest;
    private float startTime;
    // private float finishTime;
    // public static float current;
    public static bool startRace = false;
    private static bool win = false;
    private static float t = 0;
    

    void Start()
    {
        // Scene currentScene = SceneManager.GetActiveScene();
        // current = currentScene.buildIndex;
        float pb = GetBestTime();
        if (pb != float.MaxValue)
        {
            string minutes = ((int)pb / 60).ToString();
            string seconds = (pb % 60).ToString("f2");
            previousBest.text = minutes + ":" + seconds;
        }

        t = 0;
        win = false;
        startTime = Time.time;
        startRace = true;
    }

    void Update()
    {
        //if the game is won return.
        if (win) {
            return;
        }

        // starts the timer if startRace is true.
        if(startRace)
        {   
            t = Time.time - startTime;
            string minutes = ((int) t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            
            timerText.text = minutes + ":" + seconds;
        }
        
    }
    // used to give the player points after they win and to toggle the win variable which will then show the game is complete screen.
    public static void Win()
    {
        //t is the time that the player finished.ssssssssssssssaw

        // if(current == 1)
        // if(t < 60)
        // {
        //     score += 100;
        // }
        // }
        // toggles the game is complete to make the timer stop.

        float prevBest = PlayerPrefs.GetFloat("BestTime", float.MaxValue);
        if (t < prevBest)
        {
            PlayerPrefs.SetFloat("BestTime", t);
            PlayerPrefs.Save();
        }

        win = true;
    }

    public static float GetBestTime()
    {
        return PlayerPrefs.GetFloat("BestTime", float.MaxValue);
    }
}
