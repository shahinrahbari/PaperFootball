using UnityEngine;
using System.Collections;

public class checkBallsGoal : MonoBehaviour {

	public GameObject[] balls = new GameObject[3];
	private int speed = 8;
	public Vector3 newPosition1 = new Vector3();
	public Vector3 newPosition2 = new Vector3();
	public Vector3 newPosition3 = new Vector3();

	public bool isReseting = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		for (int i = 0; i<3; i++){

			if (balls[i].transform.position.x > gameStatus.rightGoal_x || balls[i].transform.position.x < gameStatus.leftGoal_x) 
			{
				if (balls[i].transform.position.y >gameStatus.goal_y2 && balls[i].transform.position.y < gameStatus.goal_y1){
					Debug.Log("Goal!");
					if (!isReseting) {
						reset ();
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

	public void reset(){

		gameStatus.isShooted = false;

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
