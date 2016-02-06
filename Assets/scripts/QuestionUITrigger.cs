using UnityEngine;
using System.Collections;

public class QuestionUITrigger : MonoBehaviour {

	void Update () {
		Ray myRay = Camera.main.ScreenPointToRay (Input.mousePosition); 
		RaycastHit rayHit = new RaycastHit (); 
		if (Input.GetKeyDown (KeyCode.Mouse0) && Physics.Raycast (myRay, out rayHit, 100f)){
			if (rayHit.collider.tag == "a1") {
				transform.GetComponent<Dialogue> ().choseAnswer (0);
			}
			else if (rayHit.collider.tag == "a2") {
				transform.GetComponent<Dialogue> ().choseAnswer (1);
			}
			else if (rayHit.collider.tag == "a3") {
				transform.GetComponent<Dialogue> ().choseAnswer (2);
			}
			else if (rayHit.collider.tag == "a4") {
				transform.GetComponent<Dialogue> ().choseAnswer (3);
			}

		}
	}

}
