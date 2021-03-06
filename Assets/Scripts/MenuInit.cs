using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuInit : MonoBehaviour
{
    public static MenuInit instance;

    public Button[] uiButtons;
    public Button[] settingsButtons;
    public Button[] playButtons;
    public Button[] connectButtons;

    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject playMenu;
    public GameObject connectMenu;
    public GameObject menuAudioListener;

    public AudioClip clickAudio;
    public float menuAudioVolume;

    public AudioClip menuSong;
    public float menuSongVolume;

    public MenuCamera cameraScript;

    //For resetting camera speed
    private float previousCameraSpeed = 0.0f;

    void Awake()
    {
        //Make this a singleton class
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already in existence, destroying self");
            Destroy(this);
        }
    }

    void Start()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        playMenu.SetActive(false);
        connectMenu.SetActive(false);

        //Sets up event listeners for main menu
        if (uiButtons.Length == 3)
        {
            Button btn = uiButtons[0].GetComponent<Button>();
            btn.onClick.AddListener(PlayButtonClicked);

            btn = uiButtons[1].GetComponent<Button>();
            btn.onClick.AddListener(SettingsButtonClicked);

            btn = uiButtons[2].GetComponent<Button>();
            btn.onClick.AddListener(ExitButtonClicked);
        }

        //Set up listeners for settings menu
        if (settingsButtons.Length == 1)
        {
            Button pbtn = settingsButtons[0].GetComponent<Button>();
            pbtn.onClick.AddListener(BackButtonClicked);
        }

        //Set up listeners for play menu
        if (playButtons.Length == 3)
        {
            Button pbtn = playButtons[0].GetComponent<Button>();
            pbtn.onClick.AddListener(Multiplayer);

            pbtn = playButtons[1].GetComponent<Button>();
            pbtn.onClick.AddListener(Singleplayer);

            pbtn = playButtons[2].GetComponent<Button>();
            pbtn.onClick.AddListener(BackButtonClicked);
        }

        //Set up listeners for connect menu
        if (connectButtons.Length == 2)
        {
            Button cbtn = connectButtons[0].GetComponent<Button>();
            //cbtn.onClick.AddListener();

            cbtn = connectButtons[1].GetComponent<Button>();
            cbtn.onClick.AddListener(BackOneDepth);
        }

        //Play main menu music
        AudioSource.PlayClipAtPoint(menuSong,
            menuAudioListener.transform.position,
            menuSongVolume);
    }

    void Update()
    {
        //Shows cursor when returning from play
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    //Menu button functionality below

    void PlayButtonClicked()
    {
        MenuClickAudio();
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        playMenu.SetActive(true);
        previousCameraSpeed = cameraScript.GetCameraSpeed();
    }

    void SettingsButtonClicked()
    {
        MenuClickAudio();
        mainMenu.SetActive(false);
        playMenu.SetActive(false);
        settingsMenu.SetActive(true);
        previousCameraSpeed = cameraScript.SetRotateSpeed(-0.3f);
    }

    //Exit when button clicked. Also supports stopping editor.
    //Interesting reflection code for forcing editor to stop adopted from below link
    //http://answers.unity.com/answers/599597/view.html
    //This should also work for webplayer, whereas Application.Quit() does not.
    void ExitButtonClicked()
    {
        MenuClickAudio();
        if (Application.isEditor)
        {
            Type t = null;
            foreach (var assm in AppDomain.CurrentDomain.GetAssemblies())
            {
                t = assm.GetType("UnityEditor.EditorApplication");
                if (t != null)
                {
                    t.GetProperty("isPlaying").SetValue(null, false, null);
                    break;
                }
            }
        }
        else
        {
            Application.Quit();
        }
    }

    void BackButtonClicked()
    {
        MenuClickAudio();
        connectMenu.SetActive(false);
        settingsMenu.SetActive(false);
        playMenu.SetActive(false);
        mainMenu.SetActive(true);
        GamePreferencesManager.instance.SavePrefs();
        cameraScript.SetRotateSpeed(previousCameraSpeed);
    }

    //Play menu buttons below
    void Multiplayer()
    {
        MenuClickAudio();
        //Hides all the menus
        settingsMenu.SetActive(false);
        mainMenu.SetActive(false);
        playMenu.SetActive(false);

        connectMenu.SetActive(true);
    }

    void Singleplayer()
    {
        MenuClickAudio();
        //Hides all the menus
        settingsMenu.SetActive(false);
        mainMenu.SetActive(false);
        playMenu.SetActive(false);

        SceneManager.LoadScene("LevelSelect");
    }

    //Connect menu functionality below
    void BackOneDepth()
    {
        MenuClickAudio();
        connectMenu.SetActive(false);
        playMenu.SetActive(true);
        GamePreferencesManager.instance.SavePrefs();
    }

    //Audio on menu
    void MenuClickAudio()
    {
        AudioSource.PlayClipAtPoint(clickAudio, 
            menuAudioListener.transform.position,
            menuAudioVolume);
    }

    public AudioClip GetClickAudio()
    {
        return clickAudio;
    }

    public float GetMenuVolume()
    {
        return menuAudioVolume;
    }

    public void SetMenuVolume(float _vol)
    {
        menuAudioVolume = _vol;
    }
}
