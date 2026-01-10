using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (transform.position.x * 0.95f + Player.transform.position.x * 0.05f, transform.position.y * 0.95f + Player.transform.position.y * 0.05f, -0.5f);
    }
}
