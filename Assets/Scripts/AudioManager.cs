using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]AudioSource jumpSound;
    [SerializeField] AudioSource deathSound;
    [SerializeField] AudioSource pickSound;
    [SerializeField] AudioSource doorSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayJumpSound() 
    {
        jumpSound.Play();
    }

    public void PlayDeathSound()
    {
        deathSound.Play();
    }

    public void PlayPickSound()
    {
        pickSound.Play();
    }

    public void PlayDoorSound()
    {
        doorSound.Play();
    }
}
