﻿using UnityEngine;
using System.Collections;

public class dancing : MonoBehaviour {

	Animator animator;
	Animator arrowAnimator;
	AudioSource myAudio; 
	//private arrowManager arrowManage;
	private GameManager gameManager;
	//public GameObject arrow;
	public ParticleSystem heartParticles;
	public GameObject arrowNew;
	public float timeBeforeChangeDirection;


	float  changeDirectionTimer = 0;
	//float  timeBeforeChangeDirection = 2;
	string currentDirection = "left";
	bool   moveMadeForThisTurn = false;
	int    playerDancingHealth = 10;

	void Start () {
		Debug.Log (arrowNew);
		myAudio = GetComponent<AudioSource> (); 
		gameManager = Camera.main.GetComponent<GameManager> ();
	//	arrowManage = arrow.GetComponent<arrowManager> ();
		animator = GetComponent<Animator> ();
		arrowAnimator = arrowNew.GetComponent<Animator>();
		ChangeDirection ();
	}

	void Update () {
		Debug.Log (playerDancingHealth);

		// Check for game over
		if (playerDancingHealth <= 0) {
			animator.SetInteger ("state", 0);
		//	arrowManage.HideArrow ();
			gameManager.gameOver();
			this.enabled = false;
		}

		// Change direction every 5 seconds
		changeDirectionTimer += Time.deltaTime;
		if (changeDirectionTimer >= timeBeforeChangeDirection) {
			arrowAnimator.SetBool("isError", false);
			ChangeDirection();

			// If move never made
			if (!moveMadeForThisTurn) {
				playerDancingHealth--;
			}

			moveMadeForThisTurn = false;
			changeDirectionTimer = 0;
		}

		// Check if player made a move and whether its the correct move
		// Notes:  only allow one move per animal's movement, whether it be correct or incorrect
		if (!moveMadeForThisTurn) {
			string directionPushed = GetKeyDown ();

			if (directionPushed != null) {
				moveMadeForThisTurn = true;

				if (directionPushed == currentDirection) { // If made the correct move
					myAudio.Play ();
					//if (heartParticles.isPlaying) heartParticles.Stop();
					if (!heartParticles.isPlaying) heartParticles.Play();
				} else { // If made wrong move
					// Turn arrow red then fade out
					arrowAnimator.SetBool("isError", true);
					playerDancingHealth--;
				}

			}
		}
	}

	void ChangeDirection () {
		
		int random = Random.Range(0, 4);

		if (random == 0) { // LEFT
			
			animator.SetInteger("state", 3);
			currentDirection = "left"; 
		//	arrowManage.ShowArrow ("left");
			arrowAnimator.SetTrigger("arrowLeftPlay");

		} else if (random == 1) { //RIGHT
			
			animator.SetInteger("state", 4);
			currentDirection = "right"; 
		//	arrowManage.ShowArrow ("right");
			arrowAnimator.SetTrigger("arrowRightPlay");

		} else if (random == 2) { // UP
			
			animator.SetInteger("state", 1);
			currentDirection = "up";
		//	arrowManage.ShowArrow ("up");
			arrowAnimator.SetTrigger("arrowUpPlay");

		} else if (random == 3) { // DOWN
			
			animator.SetInteger("state", 2);
			currentDirection = "down";  
		//	arrowManage.ShowArrow ("down");
			arrowAnimator.SetTrigger("arrowDownPlay");
		}
	}

	string GetKeyDown () {
		if (Input.GetKeyDown (KeyCode.S))
			return "down";
		else if (Input.GetKeyDown (KeyCode.W))
			return "up";
		else if (Input.GetKeyDown (KeyCode.A))
			return "left";
		else if (Input.GetKeyDown (KeyCode.D))
			return "right";
		else
			return null;
	}
}
	

/*public class dancing : MonoBehaviour {
	public static bool gameOva = false; 
	bool notDone = true; 
	bool pressed = false; 
	bool goAgain = true; //makes the giraffe only move when this is true
	bool timer = false; //the window for when the player should move the character
	//bool rightDirection;  //set to true if the player moves in the right direction
	string direction = ""; //the direction the giraffe moved in
	Vector3 startPos; //the start position for the giraffe to return to
	AudioSource myAudio; 
	int numOfBadMoves = 0;

	public GameObject arrow;
	private arrowManager arrowManage;

	private GameManager gameManager;

	Animator animator;


	void Start () {
		myAudio = GetComponent<AudioSource> (); 
		gameManager = Camera.main.GetComponent<GameManager> ();
		arrowManage = arrow.GetComponent<arrowManager> ();

		animator = GetComponent<Animator> ();
	}

	void Update () {

		if (numOfBadMoves >= 40) {
			animator.SetInteger ("state", 0);
			notDone = false; 
			gameOva = true; 
			arrowManage.HideArrow ();
			numOfBadMoves = -100; 

			StartCoroutine (CallGameOver()); 
		
		}

		if (goAgain && notDone) {
			float randomNum = Random.Range (0.0f, 1f); 

			if (randomNum <= .25f) { //Left
				animator.SetInteger("state", 3);
				direction = "left"; 
				goAgain = false; 
				timer = true; 
				arrowManage.ShowArrow ("left");
				StartCoroutine (WaitTime ()); 
			} else if (randomNum > .25f && randomNum <= .50f) { //Right
				animator.SetInteger("state", 4);
				direction = "right"; 
				goAgain = false; 
				timer = true; 
				arrowManage.ShowArrow ("right");
				StartCoroutine (WaitTime ());
			} else if (randomNum > .50f && randomNum <= .75f) { //Up
				animator.SetInteger("state", 1);
				direction = "up";
				goAgain = false; 
				timer = true; 
				arrowManage.ShowArrow ("up");
				StartCoroutine (WaitTime ());

			} else {
				animator.SetInteger("state", 2);
				direction = "down";  
				goAgain = false; 
				timer = true; 
				arrowManage.ShowArrow ("down");
				StartCoroutine (WaitTime ()); 
			}


		}
		if (timer && direction == "down" && Input.GetKeyDown (KeyCode.S)) {
			myAudio.Play (); 


		}
		if (timer && direction == "up" && Input.GetKeyDown (KeyCode.W)) {
			myAudio.Play (); 
			//StartCoroutine (ParticleWait ()); 

		}
		if (timer && direction == "left" && Input.GetKeyDown (KeyCode.A)) {
			myAudio.Play (); 
			//StartCoroutine (ParticleWait ()); 

		}
		if (timer && direction == "right" && Input.GetKeyDown (KeyCode.D)) {
			myAudio.Play (); 
			//StartCoroutine (ParticleWait ()); 

		}


		//if (!timer && Input.GetKeyDown (KeyCode.S) || !timer && Input.GetKeyDown (KeyCode.W) ||!timer && Input.GetKeyDown (KeyCode.A) ||
			//!timer && Input.GetKeyDown (KeyCode.D)) {
			//numOfBadMoves++; 
		//}
		if (timer && direction == "down" && Input.GetKeyDown (KeyCode.W) || timer && direction == "down" && Input.GetKeyDown (KeyCode.A) || 
			timer && direction == "down" && Input.GetKeyDown (KeyCode.D)) {
			numOfBadMoves++; 

		}
		else if (timer && direction == "up" && Input.GetKeyDown (KeyCode.A) || timer && direction == "up" && Input.GetKeyDown (KeyCode.S) || 
			timer && direction == "up" && Input.GetKeyDown (KeyCode.D)) {
			numOfBadMoves++;  
		}
		else if (timer && direction == "left" && Input.GetKeyDown (KeyCode.W) || timer && direction == "left" && Input.GetKeyDown (KeyCode.S) ||
			timer && direction == "left" && Input.GetKeyDown (KeyCode.D)) {
			numOfBadMoves++; 
		}
		else if (timer && direction == "right" && Input.GetKeyDown (KeyCode.W) || timer && direction == "right" && Input.GetKeyDown (KeyCode.S) || 
			timer && direction == "right" && Input.GetKeyDown (KeyCode.A)) {
			numOfBadMoves++;  
		}
		else if (timer && Input.GetKeyDown(KeyCode.A)  || timer && Input.GetKeyDown(KeyCode.W)  || timer  && Input.GetKeyDown(KeyCode.S)  || timer
			&& Input.GetKeyDown(KeyCode.D)){
			pressed = true; 
		}

	}
	IEnumerator WaitTime(){
		//wait to move back to position
		//Debug.Log("Timer: " + timer); 
		yield return new WaitForSeconds (1f); 
		//transform.position = startPos; 
		if (!pressed) {
			numOfBadMoves++;
		}
		if (pressed) {
			pressed = false; 
		}
			
		//the player should have moved by now
		timer = false; 
		//Debug.Log("Timer: " + timer); 
		animator.SetInteger ("state", 0);
		direction = ""; 
		yield return new WaitForSeconds (1f); 
		goAgain = true; 



	}


	IEnumerator CallGameOver(){
		numOfBadMoves = 0;
		notDone = true; 
		yield return new WaitForSeconds (1f); 
		gameManager.gameOver();

	}
}*/
