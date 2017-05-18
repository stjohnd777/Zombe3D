using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour {

	Animator anim;

	Rigidbody rigidBody;

	AudioSource audioSource;

	bool isJumping = false;

	public float jumpForce = 100f;

	public AudioClip sfxJumpSound;

	public AudioClip sfxDeathSound;



	void Awake(){
		Assert.IsNotNull (sfxJumpSound);
		Assert.IsNotNull (sfxDeathSound);
	}

	void Start () {

		anim = GetComponent<Animator>();

		rigidBody = GetComponent<Rigidbody>();

		audioSource = GetComponent<AudioSource>();
	}
	

	void Update () {
        if (GameManager.instance.IsGameOver )
        {
            return;
        }
        if ( Input.GetMouseButton(0) && GameManager.instance.IsGameStarted) {

            GameManager.instance.PlayerStartedGame();

            anim.Play("Jump");
			rigidBody.useGravity = true;
			isJumping = true;
		}
	}

	void FixedUpdate () {

		if (isJumping && GameManager.instance.IsGameStarted && !GameManager.instance.IsGameOver)
        {

			isJumping = false;

			rigidBody.velocity = Vector3.zero;

			rigidBody.AddForce(new Vector3(0,jumpForce,0), ForceMode.Impulse);

			audioSource.PlayOneShot(sfxJumpSound);

		}
 
	}

	void OnCollisionEnter(Collision collision){

		if (collision.gameObject.tag == "obstacle") {
			rigidBody.AddForce (new Vector2 (-600, 0), ForceMode.Impulse);
			rigidBody.detectCollisions = false;
			audioSource.PlayOneShot (sfxDeathSound);
			GameManager.instance.PlayerCollided ();
		}
	}
 
}
