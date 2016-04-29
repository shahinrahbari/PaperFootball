using UnityEngine;
using System.Collections;

public class checkBallPass : MonoBehaviour {

	// Use this for initialization
	public GameObject[] balls = new GameObject[3]; 

	public Vector3 minVelocity = new Vector3();


	private int speed = 5;

	//public LayerMask forground;

	public Vector3 newPosition1 = new Vector3();
	public Vector3 newPosition2 = new Vector3();
	public Vector3 newPosition3 = new Vector3();


	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


		checkIfBallIsMoving ();
		checkIfBallIsPassed ();

		if (gameStatus.ballPassed) {
			Debug.Log ("ispassed: " + gameStatus.ballPassed);
		}

		if (gameStatus.pressed) {

			if (!gameStatus.ballMoving) {
				if (gameStatus.isShooted) {
					if (!gameStatus.ballPassed) {
						//changeTurn();
						reset ();
					} else {
						gameStatus.isShooted = false;
						gameStatus.ballPassed = false;
					}
				}
			}
		}

		if (gameStatus.isReseting) {
			balls [0].transform.position = Vector2.MoveTowards (balls [0].transform.position, newPosition1, speed * Time.deltaTime);
			balls [1].transform.position = Vector2.MoveTowards (balls [1].transform.position, newPosition2, speed * Time.deltaTime);
			balls [2].transform.position = Vector2.MoveTowards (balls [2].transform.position, newPosition3, speed * Time.deltaTime);
		}
		if ((balls [0].transform.position - newPosition1 ).magnitude < 0.5f
			&& (balls [1].transform.position - newPosition2).magnitude < 0.5f 
			&& (balls [2].transform.position - newPosition3).magnitude < 0.5f) {

			gameStatus.isReseting = false;

		}

	}


	public void checkIfBallIsMoving(){

		if (gameStatus.pressed) {
	
			if (balls [0].GetComponent<Rigidbody2D> ().velocity.magnitude > 0.001) {
				gameStatus.ballMoving = true;
				//Debug.Log ("velo0:" + balls [0].GetComponent<Rigidbody2D> ().velocity.x);
			}

			else if (balls [1].GetComponent<Rigidbody2D> ().velocity.magnitude > 0.001) {
				gameStatus.ballMoving = true;
			}

			else if (balls [2].GetComponent<Rigidbody2D> ().velocity.magnitude > 0.001) {
				gameStatus.ballMoving = true;
			} else {

				gameStatus.ballMoving = false;

			}


		}

	}

	public void checkIfBallIsPassed(){


		Vector3 A = balls [0].transform.position;
		Vector3 B = balls [1].transform.position;
		Vector3 C = balls [2].transform.position;
//		if(Physics.Linecast(balls[0].transform.position,balls[1].transform.position)){
//			ballPassed = true;
//			Debug.Log ("ball pass");
//		}
//
//		else if(Physics.Linecast(balls[1].transform.position,balls[2].transform.position)){
//			ballPassed = true;
//			Debug.Log ("ball pass");
//		}
//
//		else if (Physics.Linecast (balls [0].transform.position, balls [2].transform.position)) {
//			ballPassed = true;
//			Debug.Log ("ball pass");
//		}
		float AB = (A - B).magnitude;
		float AC = (A - C).magnitude;
		float BC = (B - C).magnitude;
		if(Mathf.Abs(AB+AC-BC)<0.01f){
			gameStatus.ballPassed = true;

		}
		if(Mathf.Abs(AB+BC-AC)<0.01f){
			gameStatus.ballPassed = true;

		}
		if(Mathf.Abs(BC+AC-AB)<0.01f){
			gameStatus.ballPassed = true;

		}
		if (gameStatus.ballPassed)
			Debug.Log ("BALL PASSSSS");

	}

	public void reset(){

		if(!gameStatus.turnRight){



			Debug.Log ("x1:" + ResetPoints.i().x1);
			Debug.Log ("x2:" + ResetPoints.i().x2);
			Debug.Log ("x3:" + ResetPoints.i().x3);


			newPosition1 = new Vector3 (ResetPoints.i().x1,ResetPoints.i().y1,0);
			newPosition2 = new Vector3 (ResetPoints.i().x2,ResetPoints.i().y2,0);
			newPosition3 = new Vector3 (ResetPoints.i().x3,ResetPoints.i().y3,0);


			gameStatus.isReseting = true;
			gameStatus.ballPassed = false;


		}

	}

	 public class ResetPoints{
		public int x1,x2,x3,y1,y2,y3;
		static private ResetPoints instance=null;
		private ResetPoints(){
			 x1 = Random.Range (-7, -1);
		    x2 = Random.Range(-7,-1);
			x3 = Random.Range(-7,-1);
			y1 = Random.Range (-3, 2);
			y2 = Random.Range (-3, 2);
			y3 = Random.Range (-3, 2);
		}
		static public void clear(){
			instance = null;
		}
		static public ResetPoints i(){
			if (instance == null)
				instance = new ResetPoints ();
			return instance;
		}
			
	}
}
