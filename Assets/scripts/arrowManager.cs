using UnityEngine;
using System.Collections;

public class arrowManager : MonoBehaviour {

	public Sprite up;
	public Sprite down;
	public Sprite left;
	public Sprite right;

	private SpriteRenderer spriteRenderer;


	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
		HideArrow ();
	}

	void Update () {

	}

	public void ShowArrow(string d) {
		ShowArrow ();
		if (d == "up") {
			spriteRenderer.sprite = up;
		} else if (d == "down") {
			spriteRenderer.sprite = down;
		} else if (d == "left") {
			spriteRenderer.sprite = left;
		} else if (d == "right") {
			spriteRenderer.sprite = right;
		}
	}

	public void HideArrow() {
		spriteRenderer.enabled = false;
	}

	void ShowArrow() {
		spriteRenderer.enabled = true;
	}
}
