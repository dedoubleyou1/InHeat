using UnityEngine;
using System.Collections;

public class answerImageSwitcher : MonoBehaviour {

	public Sprite buttonDeprecated;
	public Sprite button;
	private SpriteRenderer spriteRenderer;

	public string myTag;

	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void Update(){
		Ray myRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit rayHit = new RaycastHit ();
		if (Physics.Raycast (myRay, out rayHit, 100f) && (rayHit.collider.tag == myTag)) {
			spriteRenderer.sprite = button;
		} else {
			spriteRenderer.sprite = buttonDeprecated;
		}
	}
}
