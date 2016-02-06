using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject dialogueManager;
	public GameObject giraffe;

	private Dialogue dialogueScript;
	private Entrance entranceScript;
	private playerMovement playerMovementScript;
	private dancing dancingScript;
	private EndGame endGameScript;

	public int wonGame = 0;

	enum State 
	{
		ENTRANCE,
		DANCE,
		ENDGAME
	};

	State state = State.ENTRANCE;

	void Start () 
	{
		dialogueScript 		 = dialogueManager.GetComponent<Dialogue> ();
		entranceScript 		 = gameObject.GetComponent<Entrance>();
		playerMovementScript = gameObject.GetComponent<playerMovement>();
		dancingScript 		 = giraffe.GetComponent<dancing>();
		endGameScript 		 = gameObject.GetComponent<EndGame> ();
	}

	void Update () 
	{

		switch (state)
		{

		case State.ENTRANCE:
			entranceScript.enabled = true;
			dialogueScript.enabled = false;
			dancingScript.enabled = false;
			playerMovementScript.enabled = false;
			endGameScript.enabled = false;
			break;

		case State.DANCE:
			entranceScript.enabled = false;
			dialogueScript.enabled = true;
			dancingScript.enabled = true;
			playerMovementScript.enabled = true;
			endGameScript.enabled = false;
			break;

		case State.ENDGAME:
			entranceScript.enabled = false;
			dialogueScript.enabled = false;
			dancingScript.enabled = false;
			playerMovementScript.enabled = true;
			endGameScript.enabled = true;
			break;
		}
	}


	public void endEntranceState () 
	{
		wonGame = 1;
		state = State.DANCE;
	}

	public void gameOver ()
	{
		state = State.ENDGAME;
		wonGame = 1;
		dialogueScript.hideUI (); 
	}
	public void gameWin(){
		state = State.ENDGAME;
		wonGame = 2;
		dialogueScript.hideUI (); 
	}
}