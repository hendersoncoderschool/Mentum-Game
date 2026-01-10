using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource source_badexplosion;

    public AudioClip clip_badexplosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playSFX(AudioClip clip)
    {
        source_badexplosion.PlayOneShot(clip);
    }
}
