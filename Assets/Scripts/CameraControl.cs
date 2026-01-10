using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera rCamera;
    private CinemachineVirtualCamera vCamera;
    private Rigidbody2D Player;
    private PlayerInput PlayerInfo;
    private float TopVel = 0;
    private float Zoom = 0;
    private bool Lock = false;
    private float startTime;
    private Vector3 dragOrgin;

    // Start is called before the first frame update
    void Start()
    {
        vCamera = GetComponent<CinemachineVirtualCamera>();
        Player = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        PlayerInfo = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Lock == false)
        {
            TopVel -= 0.01f;
            if (TopVel <= Player.velocity.magnitude)
            {
                TopVel = (TopVel * 0.99f + Player.velocity.magnitude * 0.01f);
            }

            Zoom *= 0.999f;

        }

        Zoom = Zoom + Input.GetAxis("Mouse ScrollWheel") * -5;

        if (Input.GetMouseButton(2))
        {
            if (Input.GetMouseButtonDown(2))
            {
                
                if (Lock == false)
                {
                    Zoom = Zoom + TopVel * 0.25f;
                    TopVel = 0;
                }

                startTime = Time.time;
                Lock = true;   
            }

        }

        if (Input.GetMouseButtonUp(2))
        {
            if (Time.time - startTime < 0.2f)
            {
                StartCoroutine(SmoothZoom());
            }
        }

        if (Zoom < TopVel * -0.25f)
        {
            Zoom = TopVel * -0.25f;
        }

        if (Input.GetKeyDown("r") && Lock == false)
        {
            Zoom = Zoom + TopVel * 0.25f;
            TopVel = 0;
            StartCoroutine(SmoothZoom());
        }

            vCamera.m_Lens.OrthographicSize = (6 + Zoom + TopVel / 4);
            
    }

    IEnumerator SmoothZoom()
    {           

        for (int i = 0; i < 20 ; i++)
        {
            Zoom *= 0.8f;
            TopVel = TopVel * 0.99f + Player.velocity.magnitude * 0.01f;
            yield return new WaitForSeconds(0.025f);    
        }
        Zoom = 0;
        Lock = false;

    }

}
