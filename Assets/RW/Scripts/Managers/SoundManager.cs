using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Variable Declarations
    public static SoundManager Instance;    // Stores a reference to a SoundManager component

    public AudioClip shootClip;             // Reference to an AudioClip containing the hay shooting sound effect
    public AudioClip sheepHitClip;          // Reference to the sound effect for when a sheep gets hit by hay
    public AudioClip sheepDroppedClip;      // Reference to the sound a sheep makes when it drops off the edge

    private Vector3 cameraPosition;         // Cached position of the camera


    // Awake
    void Awake()
    {
        Instance = this;                                    // Cache this script inside the Instance variable
        cameraPosition = Camera.main.transform.position;    // Cache the position of the main camera (the camera with a MainCamera tag)
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // PlaySound
    private void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, cameraPosition);  // Create a temporary AudioSource that plays the audio clip that was passed as a parameter at the location of the camera
    }

    // Methods to trigger the actual playing of the sound effects
    public void PlayShootClip()
    {
        PlaySound(shootClip);
    }

    public void PlaySheepHitClip()
    {
        PlaySound(sheepHitClip);
    }

    public void PlaySheepDroppedClip()
    {
        PlaySound(sheepDroppedClip);
    }


}
