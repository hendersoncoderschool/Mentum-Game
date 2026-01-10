using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
        private Vector2 mouseWorldPos;
        private Vector2 mousePosition;
        private Vector3 objectPos;
    // Start is called before the first frame update
    void Start()
    {
        objectPos = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().WorldToScreenPoint(GameObject.FindWithTag("Player").transform.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //print (Input.mousePosition);
        transform.position = mouseWorldPos;
        
        //mousePosition.x -= objectPos.x;
        //mousePosition.y -= objectPos.y;
        //transform.position = objectPos;
    }
}
