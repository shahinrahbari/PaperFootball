using UnityEngine;
using System.Collections;

public class checkBallPass : MonoBehaviour {

	// Use this for initialization
	public GameObject[] balls = new GameObject[3]; 

	public Vector3 minVelocity = new Vector3();

	public bool ballPassed = false;

	public bool isReseting = false;

	private int speed = 5;

	public LayerMask forground;

	public Vector3 newPosition1 = new Vector3();
	public Vector3 newPosition2 = new Vector3();
	public Vector3 newPosition3 = new Vector3();


	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


		checkIfBallIsMoving ();
		checkIfBallIsPassed ();

		Debug.Log ("ismoving: " + gameStatus.ballMoving);


		if (gameStatus.pressed) {

			if (!gameStatus.ballMoving) {
				if (gameStatus.isShooted) {
					if (!ballPassed) {
						//changeTurn();
						reset ();
					} else {
						gameStatus.isShooted = false;
						ballPassed = true;
					}
				}
			}
		}

		if (isReseting) {
			balls [0].transform.position = Vector2.MoveTowards (balls [0].transform.position, newPosition1, speed * Time.deltaTime);
			balls [1].transform.position = Vector2.MoveTowards (balls [1].transform.position, newPosition2, speed * Time.deltaTime);
			balls [2].transform.position = Vector2.MoveTowards (balls [2].transform.position, newPosition3, speed * Time.deltaTime);
		}
		if ((balls [0].transform.position - newPosition1 ).magnitude < 0.5f
			&& (balls [1].transform.position - newPosition2).magnitude < 0.5f 
			&& (balls [2].transform.position - newPosition3).magnitude < 0.5f) {

			isReseting = false;

		}

	}


	public void checkIfBallIsMoving(){

		if (gameStatus.pressed) {
	
			if (balls [0].GetComponent<Rigidbody2D> ().velocity.magnitude > 0.001) {
				gameStatus.ballMoving = true;
				Debug.Log ("velo0:" + balls [0].GetComponent<Rigidbody2D> ().velocity.x);
			}

			if (balls [1].GetComponent<Rigidbody2D> ().velocity.magnitude > 0.001) {
				gameStatus.ballMoving = true;
			}

			if (balls [2].GetComponent<Rigidbody2D> ().velocity.magnitude > 0.001) {
				gameStatus.ballMoving = true;
			} else {

				gameStatus.ballMoving = false;

			}


		}

	}

	public void checkIfBallIsPassed(){



		if(Physics.Linecast(balls[0].transform.position,balls[1].transform.position,forground)){
			ballPassed = true;
		}

		if(Physics.Linecast(balls[1].transform.position,balls[2].transform.position,forground)){
			ballPassed = true;
		}

		if (Physics.Linecast (balls [0].transform.position, balls [2].transform.position, forground)) {
			ballPassed = true;
		} else {
			ballPassed = false;
		}


	}

	public void reset(){

		if(!gameStatus.turnRight){

			int x1 = Random.Range (-7, -1);
			int x2 = Random.Range(-7,-1);
			int x3 = Random.Range(-7,-1);
			int y1 = Random.Range (2, -3);
			int y2 = Random.Range (2, -3);
			int y3 = Random.Range (2, -3);

			newPosition1 = new Vector3 (x1,y1,0);
			newPosition2 = new Vector3 (x2,y2,0);
			newPosition3 = new Vector3 (x3,y3,0);


			isReseting = true;



		}

	}
}
