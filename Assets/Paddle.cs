using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float TravelTime;
    public float ChangeRotation;
    private float RestingRotation;
    public string ControlKey;
    // Start is called before the first frame update
    void Start()
    {
        RestingRotation = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        //NEED TO CHANGE HOW THIS IS BEING DONE. Likely need to use Rigidbody 2D.
        //Need to change, because although the rotation is going where it should, the player is not being launched, it is simply being pushed out of the object
        //Need to transfer force to the player
        if (Input.GetKey(ControlKey))
        {
            transform.eulerAngles = new Vector3(0, 0, RestingRotation + ChangeRotation);

            print("I am peing pressed down!");
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, RestingRotation);
        }
    }
}
