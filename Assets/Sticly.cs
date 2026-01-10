using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticly : MonoBehaviour
{
    private PlayerInput Player;
    private Rigidbody2D RB2D;
    // Start is called before the first frame update
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D ObjectRigidbody = collision.GetComponent<Rigidbody2D>();
        if (ObjectRigidbody)
        {
            ObjectRigidbody.drag = 7;       
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Rigidbody2D ObjectRigidbody = collision.GetComponent<Rigidbody2D>();
        if (ObjectRigidbody)
        {
            ObjectRigidbody.drag = 0.05f;
        }
    }
}   
