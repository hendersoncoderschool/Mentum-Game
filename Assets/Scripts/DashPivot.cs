using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPivot : MonoBehaviour
{
    public Transform Player;
    private Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Get angle of mouse to game object
        float angle = (Mathf.Atan2(RB.velocity.x, RB.velocity.y) * Mathf.Rad2Deg * -1) - Player.rotation.z;


        transform.rotation = Quaternion.Euler(0, 0, angle);

        ;
        /*
        // Calculate the direction vector
        Vector2 direction =  - (Vector2)transform.position;

        // Calculate the angle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the object
        transform.rotation = Quaternion.Euler(0, 0, angle);
        */
    }
}
