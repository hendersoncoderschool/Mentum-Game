using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;


public class FadeTransition : MonoBehaviour
{
    GameObject Player;
    public bool fade = false;
    private float fadeamount = 24;
    RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Player = GameObject.FindWithTag("Player");
        fadeamount = 24;
    }

    // Update is called once per frame
    void Update()
    {
        if (fade == true)
        {
            if (fadeamount < 24)
            {
                fadeamount += Time.deltaTime * 10 * (1 + (fadeamount * 0.3f));
            }
            else
            {
                fadeamount = 24;
            }

            if (fadeamount > 24)
            {
                SceneManager.LoadScene("Testing Grounds");
            }
        }
        else
        {
            if (fadeamount > 0)
            {
            fadeamount -= Time.deltaTime * 10 * (1 + (fadeamount * 0.3f));
            }
            else
            {
                fadeamount = 0;
            }
        }
        rectTransform.localScale = new Vector3(24.688f, fadeamount, 1);
    }
}
