using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnter : MonoBehaviour
{
    public float LevelNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameObject Player = col.gameObject;
            PlayerInput PlayerScript = Player.GetComponent<PlayerInput>();
            PlayerScript.CanControl = false;
            Rigidbody2D RB = Player.GetComponent<Rigidbody2D>();
            RB.velocity = Vector3.zero;
            Player.transform.position = transform.position;
            RB.constraints = RigidbodyConstraints2D.FreezePosition;
            RB.angularVelocity = 0;
        }
    }
}
