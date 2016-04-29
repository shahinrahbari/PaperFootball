using UnityEngine;
using System.Collections;

public class ballLogic : MonoBehaviour {


	AudioSource audio;

	public Rigidbody2D rb;
	//private bool isDrag;
	//public Vector2 thrust = new Vector2(10,10);

	// Use this for initialization
	void Start () {
	
		rb = GetComponent<Rigidbody2D> ();
		//audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() {

		gameStatus.pressed = true;
	}

	void OnMouseUp(){


		Vector2 shoot = new Vector2();
		shoot.x = rb.position.x - Camera.main.ScreenToWorldPoint (Input.mousePosition).x;
		shoot.y = rb.position.y - Camera.main.ScreenToWorldPoint (Input.mousePosition).y;

		if (shoot.magnitude > 15)
			shoot = shoot / shoot.magnitude * 15;
		rb.AddForce (shoot, ForceMode2D.Force);
		//audio.Play ();

		gameStatus.ballMoving = true;
		StartCoroutine (makeIsShootedtrue ());
	}

	IEnumerator makeIsShootedtrue(){
		yield return new WaitForSeconds(0.1f);
			gameStatus.isShooted = true;
		
	}
		

}
