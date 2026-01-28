using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{   
    [SerializeField] private AudioSource flapAudioSource;
    [SerializeField] private AudioSource collisionAudioSource;

    //subscribes to bird flap and collision events
    private void OnEnable()
    {
        Bird bird = Locator.instance.bird;
        bird.OnBirdFlap += HandleBirdFlap;
        bird.OnBirdCollision += HandleBirdCollision;
    }

    private void HandleBirdFlap()
    {
        // Play flap sound
        flapAudioSource.Play();

    }

    private void HandleBirdCollision()
    {
        // Play collision sound
        collisionAudioSource.Play();
    }
}