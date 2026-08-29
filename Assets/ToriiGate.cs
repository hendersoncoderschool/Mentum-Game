using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToriiGate : MonoBehaviour
{
    private float maxSpeed = 500f;
    private float maxBoost = 30f;
    AudioSource audioSource;
    public AudioClip sfx_gate;
    // Start is called before the first frame update
    void Start()
    {
        //ToriiTrigger = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(sfx_gate, 1);
            if (other.attachedRigidbody.velocity.magnitude >= maxSpeed) return;
            Vector3 velocity = other.attachedRigidbody.velocity;
            float speed = other.attachedRigidbody.velocity.magnitude;
            Vector3 direction = speed > 0.01f ? velocity / speed : transform.forward;
            float speedRatio = speed / maxSpeed;
            float diminishingMult = 1f - Mathf.Log10(1f + (speedRatio * 9f));
            diminishingMult = Mathf.Clamp01(diminishingMult);
            other.attachedRigidbody.velocity = direction * (maxBoost * diminishingMult);
            Debug.Log("Passed Torii Gate");
        }
    }

    float CalculateBoost(Vector3 Velocity)
    {

    }
}
