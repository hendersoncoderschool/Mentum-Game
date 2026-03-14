using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FadeTransition : MonoBehaviour
{
    GameObject Player;
    public bool fade = false;
    private float fadeamount = 0;
    RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (fade == true)
        {
            fadeamount += Time.deltaTime * 10 * (1 + (fadeamount * 0.3f));
            rectTransform.localScale = new Vector3(24.688f, fadeamount, 1);
        }
    }
}
