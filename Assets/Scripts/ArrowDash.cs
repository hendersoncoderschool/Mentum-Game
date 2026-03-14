using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDash : MonoBehaviour
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
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
