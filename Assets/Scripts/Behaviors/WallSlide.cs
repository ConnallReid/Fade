using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide : StickToWall {

	public float slideVelocity=-1f;
	public float slideMultiplier=5f;

	// Update is called once per frame
	override protected void Update () {
		base.Update ();

		if (onWallDetected) {
			var velY = slideVelocity;
			if (inputState.GetButtonValue(inputButtons [0])) {
				velY *= slideMultiplier;
			}
				body2d.velocity = new Vector2 (body2d.velocity.x, velY);
			
		}
	}

	override protected void OnStick(){
		body2d.velocity = Vector2.zero;
	}
	override protected void OffWall(){
		//nothing
	}
}
