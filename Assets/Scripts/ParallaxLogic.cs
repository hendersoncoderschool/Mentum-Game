using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ParallaxLogic : MonoBehaviour
{
    public GameObject Camera;
    public float ParallaxNum;
    public bool ChangeX;
    public bool ChangeY;
    private float OrginX;
    private float OrginY;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindWithTag("CameraTarget");
        OrginX = transform.position.x;
        OrginY = transform.position.y;
        /*print(OrginX);
        print(OrginY);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (ChangeX)
        {
            float DistDiffX = (Camera.transform.position.x - OrginX);
            DistDiffX *= ParallaxNum;
            transform.position = new Vector3 (OrginX - DistDiffX, transform.position.y, transform.position.z);
        }
        if (ChangeY)
        {
            float DistDiffY = (Camera.transform.position.y - OrginY);
            DistDiffY *= ParallaxNum;
            transform.position = new Vector3(transform.position.x, OrginY - DistDiffY, transform.position.z);
        }

        /*print(Camera.transform.position.x);
        print(Camera.transform.position.y);*/

    }
}
