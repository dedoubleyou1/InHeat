using UnityEngine;
using System.Collections;

public class Entrance : MonoBehaviour {

	public GameObject myCamera;
	private GameManager gameManagerScript;
	
	//raycast 
	//when mouse hovers over object and user left clicks, zoom in on object
	//zoom = camera tween
	bool move = false; 
	bool again = true; 
	public Transform marker; 
	public Transform giraffe; 

	void Start () 
	{
		gameManagerScript = myCamera.GetComponent<GameManager> ();
	}

	void Update () 
	{
		Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition); 
		RaycastHit rayHit = new RaycastHit (); 
		if (Physics.Raycast (mouseRay, out rayHit, 100f) && rayHit.collider.tag == "giraffe" && Input.GetKeyDown(KeyCode.Mouse0) && again) 
		{
			move = true; 
			again = false;
		}
		if (move) 
		{
			Camera.main.transform.position += new Vector3 (0f, 0f, .1f); 
			if (Camera.main.transform.position.z >= marker.position.z) 
			{
				move = false; 
			}

		}
		if (!again && !move) 
		{
			gameManagerScript.endEntranceState ();
		}
	}
}
