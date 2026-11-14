using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float TravelSpeed;
    public float ChangeRotation;
    private float ActiveRotation;
    private float RestingRotation;
    public string ControlKey;
    public GameObject Player;
    float targetAngle;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        RestingRotation = transform.eulerAngles.z;
        Player = GameObject.FindWithTag("Player");
        ActiveRotation = RestingRotation - ChangeRotation;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(ControlKey))
        {
            targetAngle = ActiveRotation;
            Debug.Log("PRESSED");
        }
        else
        {
            targetAngle = RestingRotation;
        }
        float currentAngle = rb.rotation;
        float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, TravelSpeed * Time.deltaTime);
        rb.MoveRotation(newAngle);
    }
}
