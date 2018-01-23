using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource thrusterSound;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        thrusterSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
	}

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!thrusterSound.isPlaying)
            {
                thrusterSound.Play();
            }
            rigidBody.AddRelativeForce(Vector3.up);
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            thrusterSound.Stop();
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward);
            print("Rotating left");
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.back);
            print("Rotating right");
        }
    }
}
