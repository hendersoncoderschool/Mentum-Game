using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetController : MonoBehaviour
{
    public Transform player;
     
    private Vector3 dragOrgin;
    private bool userControl = false;
    private float startTime;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            dragOrgin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            userControl = true;
            startTime = Time.time;
        }
        if (Input.GetMouseButtonUp(2))
        {
            if (Time.time - startTime < 0.2f)
            {
                userControl = false;
            }
        }
        if (userControl)
        {
            DragCamera();
        }
        else
        {
            //Snap back to player
            Vector3 newPos = Vector3.Lerp(transform.position, player.position, Time.deltaTime * 5f);
            newPos.z = transform.position.z;
            transform.position = newPos;
        }
    }

    void DragCamera()
    {
        Vector3 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = dragOrgin - currentPos;

        difference.z = 0;
        if (Input.GetMouseButton(2))
        {
            transform.position += difference;
        }
        dragOrgin = currentPos;
    }
}
