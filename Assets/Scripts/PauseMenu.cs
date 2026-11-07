using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    RectTransform rectTransform;
    public bool Paused = false;
    [SerializeField] public GameObject Pause;
    [SerializeField] public GameObject OptionMenu;
    [SerializeField] public GameObject SoundMenu;
    [SerializeField] public GameObject MusicSlider;
    [SerializeField] public GameObject SFXSlider;
    public float TimeScale = 1f;
    public float Squish = 0f;
    public AudioMixer audioMixer;
    public AudioMixer SFXaudioMixer;
    public PlayerInput Player;
    public string Menu = "Main";
    public Slider MusicVol;
    public Slider SFXVol;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Player = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
        MusicVol = MusicSlider.GetComponent<Slider>();
        SFXVol = SFXSlider.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paused = !Paused;
            if (Paused == true)
            {
                Pause.SetActive(true);
                OptionMenu.SetActive(false);
                SoundMenu.SetActive(false);
            }
        }
        if (Paused == true)
        {
            Time.timeScale = 0;
            if (Squish < 1)
            {
                //Squish += Time.deltaTime * 2 * (1 + (Squish * 0.05f));
                Squish = Squish + 0.01f;
                {
                    if (Squish > 1)
                    {
                        Squish = 1;
                    }
                }
            }
        }
        else
        {
            Time.timeScale = TimeScale;
            if (Squish > 0f)
            {
                //Squish -= Time.deltaTime * 2 * (1 + (Squish * 0.05f));
                Squish -= 0.01f;
                {
                    if (Squish < 0)
                    {
                        Squish = 0;
                    }
                }
            }
        }
        rectTransform.localScale = new Vector3(Squish, 1, 1);
        if (SoundMenu.active == true)
        {
            audioMixer.SetFloat("MusicEQ", 1);
        }
        else
        {
            audioMixer.SetFloat("MusicEQ", 1 - Squish);
        }
    }

    public void Resume()
    {
        Paused = false;
    }
    public void Options()
    {
        Pause.SetActive(false);
        OptionMenu.SetActive(true);
        SoundMenu.SetActive(false);
    }
    public void ReturnToCheckpoint()
    {
        Player.ReturnToCheckpoint();
        Paused = false;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ReturnToHUB()
    {
        SceneManager.LoadScene("HUB");
    }
    public void MainMenu()
    {

    }
    public void Sound()
    {
        Pause.SetActive(false);
        OptionMenu.SetActive(false);
        SoundMenu.SetActive(true);

    }
    public void BackToMainMenu()
    {
        Pause.SetActive(true);
        OptionMenu.SetActive(false);
        SoundMenu.SetActive(false);
    }
    public void BackToOptionMenu()
    {
        Pause.SetActive(false);
        OptionMenu.SetActive(true);
        SoundMenu.SetActive(false);
    }
    public void ChangeMusicVol()
    {
        if (MusicVol.value > 0.01)
        {
            audioMixer.SetFloat("MusicVol", Mathf.Log10(MusicVol.value) * 20f);
        }
        else
        {
            audioMixer.SetFloat("MusicVol", -80);
        }


    }
    public void ChangeSFXVol()
    {
        print("SFX CHANGE");
        if (MusicVol.value > 0.01)
        {
            SFXaudioMixer.SetFloat("SFXVol", Mathf.Log10(SFXVol.value) * 20f);
        }
        else
        {
            SFXaudioMixer.SetFloat("SFXVol", -80);
        }


    }

}
