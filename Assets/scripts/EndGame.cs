using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class EndGame : MonoBehaviour {
	//Rigidbody rbody; 
	public GameObject heart; 
	public GameObject giraffe;
	public Image butts; 
	public Text bye;  
	private GameManager gameManager;
	bool fadeGiraffe = false;
	bool fadeToBlack = false;
	AudioSource myAudio; 


	void Start () {
		//blackScreen.SetActive (true);
		//rbody = giraffe.GetComponent<Rigidbody>(); 
		gameManager = Camera.main.GetComponent<GameManager> ();
		myAudio = GetComponent<AudioSource> (); 
		if (gameManager.wonGame == 1) {
			StartGameLose ();
		} else if (gameManager.wonGame == 2) {
			StartGameWin ();
		}
	}

	void Update () {



		if (fadeGiraffe) {
			bye.text = "Yeah I'm not into this. Peace."; 
			//giraffe.transform.position = new Vector3 (-.3f, 0f, 0f); 
			//rbody.AddForce (-.2f, 0f, 0f); 
			/*float alpha = giraffe.transform.GetComponent<Renderer>().material.color.a;
			while (alpha > 0) {
				alpha -= Time.deltaTime;
				Color newColor = new Color (1, 1, 1, alpha);
				giraffe.transform.GetComponent<Renderer>().material.color = newColor;
			}*/
		}

		if (fadeToBlack) {
			
			StartCoroutine (waitForFade ()); 

			/*
			float alpha = giraffe.transform.GetComponent<Renderer>().material.color.a;
			while (alpha < 1) {
				alpha += Time.deltaTime;
				Color newColor = new Color (1, 1, 1, alpha);
				blackScreen.transform.GetComponent<Renderer>().material.color = newColor;
			}
			*/

		}
	}

	void StartGameLose () {
		fadeGiraffe = true;
		Debug.Log ("Invoking Fade Screen"); 
		Invoke("FadeScreenToBlack", 1);
		Invoke ("ShowTitleScreen", 5);
	}

	void StartGameWin () {
		Debug.Log ("Invoking Fade Screen"); 
		heart.SetActive (true); 
		GameObject.FindGameObjectWithTag ("giraffe").GetComponent<AudioSource> ().Stop ();
		myAudio.Play ();
		bye.text = "I like you. Let's get outta here."; 
		fadeToBlack = true;
		Invoke ("ShowTitleScreen", 5);
		// play animal sex noises
	}

	void FadeScreenToBlack () {
		fadeToBlack = true;
	}

	void ShowTitleScreen () {
		Application.LoadLevel("Start Screen");
	}
	IEnumerator waitForFade(){

		yield return new WaitForSeconds (2f); 
		butts.color = Color.Lerp (butts.color, Color.black, Time.deltaTime * 2f); 

	}
}