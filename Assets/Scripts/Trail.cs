using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    public GameObject Player;
    private ParticleSystem DebriesPS;
    [Range(0, 10)]
    public int occurAftervelocity;
    private PlayerInput PlayerPI;
    

    //[Range(0, .2f)]
    public float Frequency;

    private float Counter;

    private Rigidbody2D playerRB;

    // Start is called before the first frame update
    void Start()
    {
        DebriesPS = gameObject.GetComponent<ParticleSystem>();
        playerRB = Player.GetComponent<Rigidbody2D>();
        PlayerPI = Player.GetComponent<PlayerInput>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Frequency = 2/(playerRB.velocity.magnitude+1);
        Counter += Time.deltaTime;
        if (Mathf.Abs(playerRB.velocity.x) + Mathf.Abs(playerRB.velocity.y) > occurAftervelocity)
        {
            if (Counter > Frequency && PlayerPI.Grounded == true)
            {
                DebriesPS.Play();
                Counter = 0;
            }
        }
    }
}
