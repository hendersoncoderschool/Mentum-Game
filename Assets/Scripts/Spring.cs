using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class Spring : MonoBehaviour
{
    public float Strength = 10;
    GameObject Player;
    Animator SpringAnimator;
    // Start is called before the first frame update
    void Start()
    {
        SpringAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D Col)
    {
        //SpringAnimator.SetBool("Sprung", true);
        SpringAnimator.SetTrigger("sprung Trigger");
        Player = Col.gameObject;
        //print(gameObject.transform.forward);
        Player.transform.up = transform.up;
        /*
         ISSUE to keep not: when there is odd springs, it bounces perfectly, however; even springs causes to get stuck. 
        REASON: When player touches springs, it flips the player rotation and position and computes the velocity (bouncing up), if two are at the constant rate/time
                it will cause it contradict and make it stuck (it would compute up and down), if debug log displays the values two springs, it would show a positive 
                and negative. To fix, make the transform.up absolute or the variable of velocity in player.GetComponent positive.

         */
        Player.GetComponent<Rigidbody2D>().velocity = Vector3.Reflect (Player.GetComponent<Rigidbody2D>().velocity, transform.up);
        Player.GetComponent<Rigidbody2D>().AddForce(transform.up * Strength, ForceMode2D.Impulse);
        //Debug.Log(Player.GetComponent<Rigidbody2D>().velocity);
        //Debug.Log(ForceMode2D.Impulse);

        if (Player.tag == "Player")
        {
            Player.GetComponent<PlayerInput>().Dash = false;

        }

    }
}
