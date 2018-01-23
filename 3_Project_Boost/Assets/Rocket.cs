using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource thrusterSound;
    AudioSource boosterSound;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        thrusterSound = GetComponents<AudioSource>()[0];
        boosterSound = GetComponents<AudioSource>()[1];
	}
	
	// Update is called once per frame
	void Update () {
        Thrust();
        Rotate();
	}

    private void PlayAudioSource(AudioSource source)
    {
        if (!source.isPlaying)
        {
            source.Play();
        }
    }

    private void StopAudioSource(AudioSource source)
    {
        source.Stop();
    }
    private void Rotate()
    {
        rigidBody.freezeRotation = true;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            PlayAudioSource(boosterSound);
            transform.Rotate(Vector3.forward);
            print("Rotating left");
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            PlayAudioSource(boosterSound);
            transform.Rotate(Vector3.back);
            print("Rotating right");
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            StopAudioSource(boosterSound);
        }

        rigidBody.freezeRotation = false;
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!thrusterSound.isPlaying)
            {
                thrusterSound.Play();
            }
            rigidBody.AddRelativeForce(Vector3.up);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            thrusterSound.Stop();
        }
    }
}
