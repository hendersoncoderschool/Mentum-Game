using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToriiGate : MonoBehaviour
{
    private float maxSpeed = 30f;
    private float falloff = 2f;
    private float maxBoost = 20f;
    //private BoxCollider2D ToriiTrigger;
    AudioSource audioSource;
    public AudioClip sfx_gate;
    // Start is called before the first frame update
    void Start()
    {
        //ToriiTrigger = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
    void OnTriggerEnter(Collider other)
    {
        audioSource.PlayOneShot(sfx_gate, 1);
        Vector3 velocity = other.attachedRigidbody.velocity;
        float speed = other.attachedRigidbody.velocity.magnitude;
        Vector3 direction = speed > 0.01f ? velocity / speed : transform.forward;
        float t = Mathf.Clamp01(speed / maxSpeed);
        float gain = maxBoost + Mathf.Pow(1f - t, falloff);

        other.attachedRigidbody.velocity = direction * Mathf.Min(speed + gain, maxSpeed);
        Debug.Log("Passed Torii Gate");
    }
}
