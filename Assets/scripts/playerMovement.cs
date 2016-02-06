using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {
	private float speed = 3f;
	//private float rotSpeed = 0.5f;

	public int targetDirection;
	// 0 up
	// 1 right
	// 2 down
	// 3 left

	static Vector3 middlePos;
	static Vector3 upPos;
	static Vector3 downPos;
	static Vector3 leftPos;
	static Vector3 rightPos;

	/*static Vector3 middleRot;
	static Vector3 upRot;
	static Vector3 downRot;
	static Vector3 leftRot;
	static Vector3 rightRot;*/

	private void Start(){
		middlePos = Camera.main.transform.position;
		upPos = new Vector3 (middlePos.x, middlePos.y + 0.2f, middlePos.z);
		downPos = new Vector3 (middlePos.x, middlePos.y - 0.2f, middlePos.z);
		leftPos = new Vector3 (middlePos.x - 0.2f, middlePos.y, middlePos.z);
		rightPos = new Vector3(middlePos.x+0.2f, middlePos.y, middlePos.z);

		/*middleRot = Camera.main.transform.rotation.eulerAngles;
		upRot = new Vector3(middleRot.x - 10f, middleRot.y, middleRot.z);
		downRot = new Vector3 (middleRot.x + 10f, middleRot.y, middleRot.z);
		leftRot = new Vector3(middleRot.x, middleRot.y + 10f, middleRot.z);
		rightRot = new Vector3(middleRot.x, middleRot.y - 10f, middleRot.z);*/
	}
	void Update () {
		Vector3 currentPosition = Camera.main.transform.position;
		//Vector3 currentRotation = Camera.main.transform.localEulerAngles;

		if (Input.GetKey (KeyCode.W)) {
			Camera.main.transform.position = Vector3.Lerp(currentPosition, upPos, Time.deltaTime * speed);
			//Camera.main.transform.localEulerAngles = Vector3.Slerp(currentRotation, upRot, Time.deltaTime * rotSpeed);
		} else if (Input.GetKey (KeyCode.S)) {
			Camera.main.transform.position = Vector3.Lerp(currentPosition, downPos, Time.deltaTime * speed);
			//Camera.main.transform.localEulerAngles = Vector3.Slerp(currentRotation, downRot, Time.deltaTime * rotSpeed);

		} else if (Input.GetKey (KeyCode.A)) {
			Camera.main.transform.position = Vector3.Lerp(currentPosition, leftPos, Time.deltaTime * speed);
			//Camera.main.transform.localEulerAngles = Vector3.Slerp(currentRotation, leftRot, Time.deltaTime * rotSpeed);

		} else if (Input.GetKey (KeyCode.D)) {
			Camera.main.transform.position = Vector3.Lerp(currentPosition, rightPos, Time.deltaTime * speed);
			//Camera.main.transform.localEulerAngles = Vector3.Slerp(currentRotation, rightRot, Time.deltaTime * rotSpeed);

		} else {
			Camera.main.transform.position = Vector3.Lerp(currentPosition, middlePos, Time.deltaTime * speed);
			//Camera.main.transform.localEulerAngles = Vector3.Slerp(currentRotation, middleRot, Time.deltaTime * rotSpeed);
		}
	}
}