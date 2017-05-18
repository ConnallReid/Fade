using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {

	public Vector2 initalVelocity = new Vector2 (10, 0);
	public int Bounces =1;
	private Rigidbody2D body2d;

	// Use this for initialization
	void Awake () {
		body2d = GetComponent<Rigidbody2D> ();
	}
	// Use this for initialization
	void Start () {
		var startVelX = initalVelocity.x * transform.localScale.x;
		body2d.velocity = new Vector2 (startVelX, initalVelocity.y);
	}
	void OnCollisionEnter2D(Collision2D target){

		if (target.gameObject.transform.position.y < transform.position.y) {
			Bounces--;
		}
		if (Bounces <= 0) {
			Destroy (gameObject);
		}

	}
}
