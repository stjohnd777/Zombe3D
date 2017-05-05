using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	Animator anim;

	Rigidbody rigidBody;

	AudioSource audioSource;

	bool isJumping = false;

	public float jumpForce = 100f;

	public AudioClip sfxJumpSound;





	void Start () {

		anim = GetComponent<Animator>();

		rigidBody = GetComponent<Rigidbody>();

		audioSource = GetComponent<AudioSource>();
	}
	

	void Update () {

		if ( Input.GetMouseButton(0)) {
			anim.Play("Jump");
			rigidBody.useGravity = true;
			isJumping = true;
		}
	}

	void FixedUpdate () {

		if (isJumping){

			isJumping = false;

			rigidBody.velocity = Vector3.zero;

			rigidBody.AddForce(new Vector3(0,jumpForce,0), ForceMode.Impulse);

			audioSource.PlayOneShot(sfxJumpSound);

		}

		print(rigidBody.velocity.y);
 
	}
 
}
