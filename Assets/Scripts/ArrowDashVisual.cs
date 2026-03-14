using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDashVisual : MonoBehaviour
{
    PlayerInput Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.CanControl == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
            if (Input.GetMouseButtonUp(1))
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}