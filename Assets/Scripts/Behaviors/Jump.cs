using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : AbstractBehavior {

	public float JumpSpeed = 5f;
	public float JumpDelay = .1f;
	public int JumpCount = 2;

	public GameObject DustEffectPrefab;

	protected float lastJumpTime = 0f;
	protected int jumpRemaining = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		var canJump = inputState.GetButtonValue (inputButtons [0]);
		var holdTime= inputState.GetButtonHoldTime (inputButtons [0]);

		if (collisionState.standing) {
			if (canJump && holdTime < .1f) {
				jumpRemaining = JumpCount - 1;
				OnJump ();
			}
		} else {
			if (canJump&&holdTime<.1f && Time.time-lastJumpTime>JumpDelay) {

				if(jumpRemaining>0){
					OnJump ();
					jumpRemaining--;
					var clone = Instantiate (DustEffectPrefab);
					clone.transform.position = transform.position;
				}

			}
		}
	}

	protected virtual void OnJump(){
		var vel = body2d.velocity;
		lastJumpTime = Time.time;
		body2d.velocity = new Vector2 (vel.x, JumpSpeed);
	}
}
