using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskGradient : MonoBehaviour
{
    public float ChargeTime;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 currentPositon = transform.localPosition;
        currentPositon.y = -1.81f;
        transform.localPosition = currentPositon;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPositon = transform.localPosition;
        if (Input.GetKey("1") && currentPositon.y < 0)
        {
            currentPositon.y += Time.deltaTime * 1.81f / ChargeTime;
            transform.localPosition = currentPositon;
        }
        else if (Input.GetKeyUp("1"))
        {
            currentPositon.y = -1.81f;
            transform.localPosition = currentPositon;
        }
    }
}
