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

    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject playMenu;

    public AudioClip clickAudio;
    public float menuAudioVolume;

    public MenuCamera cameraScript;

    //Colours for fog true/false
    private Color buttonColorFalse = new Color32(164, 35, 35, 200);
    private Color buttonColorTrue = new Color32(75, 181, 75, 200);

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
        settingsMenu.SetActive(false);
        playMenu.SetActive(false);
        mainMenu.SetActive(true);
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

        //SceneManager.LoadScene("MultiScene");
    }

    void Singleplayer()
    {
        MenuClickAudio();
        //Hides all the menus
        settingsMenu.SetActive(false);
        mainMenu.SetActive(false);
        playMenu.SetActive(false);

        //SceneManager.LoadScene("GameScene");
    }

    //Audio on menu
    void MenuClickAudio()
    {
        //Figures out menu camera position and plays sound at that location
        Vector3 currentCameraPosition = Camera.main.transform.position;
        currentCameraPosition = (0.9f * currentCameraPosition) + (0.1f * transform.position);
        AudioSource.PlayClipAtPoint(clickAudio, currentCameraPosition, menuAudioVolume);
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
