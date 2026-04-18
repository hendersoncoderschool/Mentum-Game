using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    RectTransform rectTransform;
    public bool Paused = false;
    public float TimeScale = 1f;
    public float Squish = 0f;
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paused = !Paused;
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
        audioMixer.SetFloat("MyExposedParam", 1 - Squish);
    }

    public void Resume()
    {
        Paused = false;
    }
    public void Options()
    {

    }
    public void ReturnToCheckpoint()
    {

    }
    public void RestartLevel()
    {

    }
    public void ReturnToHUB()
    {

    }
    public void MainMenu()
    {

    }


}
