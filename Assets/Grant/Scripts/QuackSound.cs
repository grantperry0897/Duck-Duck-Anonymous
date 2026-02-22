using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuackSound : MonoBehaviour
{
    [SerializeField] private AudioSource quackAudioSource;
 void OnTriggerEnter(Collider collider)
    {
        // Goose chases player 
        if (collider.tag == "Player")
        {
            quackAudioSource.Play();
        }
    }
}
