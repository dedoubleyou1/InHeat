using UnityEngine;
using System.Collections;

public class dancing : MonoBehaviour {
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
}
