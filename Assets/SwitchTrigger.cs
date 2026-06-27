using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    private GameManagement GameManager;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManagement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.SwitchState == false)
        {
            spriteRenderer.color = new Color(213, 0, 255);
            print("Pink");
        }
        else
        {
            spriteRenderer.color = new Color(0, 0, 255);
            print("Purple");
        }
            
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Switch Trigger");
        GameManager.SwitchState = !GameManager.SwitchState;
    }
}
