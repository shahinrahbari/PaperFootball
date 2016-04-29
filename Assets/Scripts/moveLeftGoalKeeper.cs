using UnityEngine;
using System.Collections;

public class moveLeftGoalKeeper : MonoBehaviour {

	private bool down = false;
	public Vector2 upPosition = new Vector2(-6.3f,2.2f);
	public Vector2 downPosition = new Vector2(-6.3f, -2.2f);
	public int speed = 1;
	private bool goingUp = false;



	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (gameStatus.turnRight) {
			transform.gameObject.active = true;

		} else {
			transform.gameObject.active = false;


		}
		goalKeeperMovingUp ();


	}


	public void goalKeeperMovingUp() {

		//yield return new WaitForSeconds (0.0f);
		if (goingUp)
			transform.position = Vector2.MoveTowards (transform.position, upPosition, speed * Time.deltaTime);
		else {
			transform.position = Vector2.MoveTowards (transform.position, downPosition, speed * Time.deltaTime);
		}

		if (transform.position.y == upPosition.y) {
			goingUp = false;
		}
		if (transform.position.y == downPosition.y) {
			goingUp = true;
		}
		//goingUpFinished = false;

	}

	//	IEnumerator goalKeeperMovingDown() {
	//
	//		yield return new WaitForSeconds (0.0f);
	//		transform.position = Vector2.MoveTowards (transform.position, downPosition, speed * Time.deltaTime);
	//		goingUpFinished = false;
	//
	//	}


}
