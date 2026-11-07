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
            Color Pink = new Color(213, 0, 255);
            Pink.a = 1f;
            spriteRenderer.color = Pink;
            print("Pink");
        }
        else
        {
            Color Purple = new Color(0, 0, 255);
            Purple.a = 1f;
            spriteRenderer.color = Purple;
            print("Purple");
        }
            
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Switch Trigger");
        GameManager.SwitchState = !GameManager.SwitchState;
    }
}
