using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMouse : MonoBehaviour
{
    private GameObject Player;
    //private Vector2 mouseWorldPos;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ///mouseWorldPos);
    }
}
