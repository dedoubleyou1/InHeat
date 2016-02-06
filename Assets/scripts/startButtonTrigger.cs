using UnityEngine;
using System.Collections;

public class startButtonTrigger : MonoBehaviour {

	public Sprite buttonDeprecated;
	public Sprite button;
	private SpriteRenderer spriteRenderer;

	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void Update(){
		Ray myRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit rayHit = new RaycastHit ();
		if (Physics.Raycast (myRay, out rayHit, 100f) && rayHit.collider.tag == "sign") {
			spriteRenderer.sprite = button;

			if (Input.GetKey (KeyCode.Mouse0)) {
				Application.LoadLevel("prototype1");
			}
		} else {
			spriteRenderer.sprite = buttonDeprecated;
		}
	}
}
