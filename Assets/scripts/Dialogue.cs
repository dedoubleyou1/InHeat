using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Dialogue : MonoBehaviour {

	private GameManager gameManager;

	public GameObject questionUI;
	public GameObject[] answerUIs;
	public GameObject responseUI;

	List<DialogueInfo> dialogueInfo = new List<DialogueInfo> ();

	int questionNumber = 0;

	int health = 7;

	void Start () {

		// Define game manager
		gameManager = Camera.main.GetComponent<GameManager>();

		// Fill dialogue array
		dialogueInfo.Add (new DialogueInfo (
			"Hey. You having a good \ntime? This club is full of \ndrunk college students, \nhaha, so sick of that scene.", 
			new string[] {
				"Then why are you here?",
				"I’m a college student.",
				"You’re absolutely right, wow! \nYou’re, like, so smart!",
				"I’m having a great time, \nnow that I’m with you!"
			}, 
			new int[] {
				-3, -1, -2, 0
			},
			new string[] {
				" I don’t know. Boredom?",
				"Oh, haha. Me too actually.",
				"Uhh, okay. Little overeager, \nare we?",
				"Oh yeah? Glad to hear it!"
			}
		));

		dialogueInfo.Add (new DialogueInfo (
			"So, what do you do? \nI’m a self-proclaimed \n“brogrammer.", 
			new string[] {
				"You did NOT just say that. Ew.",
				"I’m funemployed and livin’ it up! \n *BURP*",
				"Haha, then I’m a \n“sis-iologist”!",
				"I’m actually studying mating \nrituals in various species, \nwith a focus on human mating."
			}, 
			new int[] {
				-2, -3, 0, -1
			}, 
			new string[] {
				"I did, and I will change for no one.\n",
				"Wow, I’m embarrassed for you.\n",
				"OK, sissy.",
				"Human mating is so dry, \nthey can barely swing their necks."
			}
		));

		dialogueInfo.Add (new DialogueInfo (
			"You’re a pretty good dancer. \nVery nuanced neck motions.", 
			new string[] {
				"Thanks. You swing your \nneck with reckless abandon.",
				"And your knobby knees \nare simply adorable!",
				"You should be taking \nnotes.",
				"I love the shade of brown\n of your spots."
			}, 
			new int[] {
				0, -3, -2, -1
			}, 
			new string[] {
				"Well, thank you. I pride \nmyself on my neck flailing.",
				"They’re not CUTE, they’re \nsturdy and reliable. God. ",
				"HA! Says the person who’s \nplaying follow the leader. ",
				"Well, at least you didn’t \ncompare them to chocolate. "
			}
		));

		dialogueInfo.Add (new DialogueInfo (
			"I’m having a good time with you. \nCan I ask what your intentions \nare for the night?", 
			new string[] {
				"I want to mate with you.",
				"You have a very long neck. ",
				"That’s a weird question. \nThis is a club, I’m dancing.",
				"You caught my eye. And I \nlike you."
			}, 
			new int[] {
				-3, -1, -2, 0
			},
			new string[] {
				"Oh, yeah, naturally. \nNot creepy at all.",
				"That doesn’t answer my \nquestion, but thanks!",
				"Right. Silly of me to ask. \n",
				"I’m flattered. That’s not usually \nhow clubs work."
			}
		));

		dialogueInfo.Add (new DialogueInfo (
			"I think I’d like to get to know you more. \nI haven’t met anyone who could keep \nup with my necking before. \n", 
			new string[] {
				"Cool, come back to my place.",
				"I’m more of a “neck ‘em and \nleave ‘em” type gal. ",
				" I’ll give you my number. Maybe we could go eat \nsome Acadia leaves sometime.",
				"We could get take \nnecking lessons together."
			}, 
			new int[] {
				-2, -3, 0, -1
			}, 
			new string[] {
				"Uh, that’s not really \nwhat I had in mind.",
				"Oh. Yeah, me too, usually. ",
				"Yeah, totally! That \nsounds great, I love Acacia.",
				"Lessons? I'm already a master."
			}
		));

		hideUI ();

		InvokeRepeating("spawnUI", 2, 10);
	}
	void Update(){

		if (dancing.gameOva) {
			Debug.Log ("I am in gameOva"); 
			hideUI (); 
			dancing.gameOva = false; 

		}
	}

	void spawnUI ()
	{
		// Look for won game
		if (questionNumber >= dialogueInfo.Count) {
			hideUI (); 
			gameManager.gameWin (); 
		}

		string question = dialogueInfo [questionNumber].question;
		string[] answers = dialogueInfo [questionNumber].answers;

		// Spawn question
		questionUI.transform.GetChild(0).GetComponent<TextMesh> ().text = question;
		questionUI.SetActive (true);

		// Spawn answers
		for(int i = 0; i < answerUIs.Length; i++)
		{
			answerUIs [i].transform.GetChild (0).GetComponent<TextMesh> ().text = answers [i];
			answerUIs [i].SetActive (true);
		}
	}

	void hideUI ()
	{
		// Hide question
		questionUI.SetActive (false); 

		// Hide answers
		for(int i = 0; i < answerUIs.Length; i++)
		{
			answerUIs [i].SetActive (false);
		}
	}

	void spawnResponseUI (int answer)
	{
		string response = dialogueInfo[questionNumber].responses[answer];

		// Show response UI
		responseUI.transform.GetChild (0).GetComponent<TextMesh> ().text = response;
		responseUI.SetActive (true);

		// Hide response UI after 2 seconds
		Invoke("hideResponseUI", 2);
	}

	void hideResponseUI ()
	{
		responseUI.SetActive (false);

		// Advance to next question
		questionNumber++;
	}

	public void choseAnswer (int answer)
	{
		// Hide UI
		hideUI();

		// Change health
		health += dialogueInfo[questionNumber].answerValues[answer];
		Debug.Log ("HEALTH: " + health);

		if (health <= 0) {
			hideUI (); 

			gameManager.gameOver ();
		} else {
			spawnResponseUI (answer);
		}
	}

	public class DialogueInfo
	{
		public string question;
		public string[] answers;
		public int[] answerValues;
		public string[] responses;

		public DialogueInfo(string Question, string[] Answers, int[] AnswerValues, string[] Responses)
		{
			question = Question;
			answers = Answers;
			answerValues = AnswerValues;
			responses = Responses;
		}
	}

}