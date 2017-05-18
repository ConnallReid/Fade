using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : AbstractBehavior {

	public float shootDelay = .5f;
	public GameObject ProjectlePrefab;
	public Vector2 firePosition=Vector2.zero;
	public Color debugColor=Color.yellow;
	public float debugRadius = .5f;

	private float timeElapsed = 0f;


	
	// Update is called once per frame
	void Update () {
		if (ProjectlePrefab != null) {
			var canFire = inputState.GetButtonValue (inputButtons [0]);
			if (canFire&&timeElapsed>shootDelay) {
				CreateProjectle (CalculateFirePosition());
				timeElapsed = 0f;
			}
			timeElapsed += Time.deltaTime;
		}
	}
	Vector2 CalculateFirePosition(){
		var pos = firePosition;
		pos.x *= (float)inputState.direction;
		pos.x += transform.position.x;
		pos.y += transform.position.y;
		return pos;
	}
	public void CreateProjectle(Vector2 pos){
		var clone = Instantiate (ProjectlePrefab,pos,Quaternion.identity)as GameObject;
		clone.transform.localScale = transform.localScale;
	}

	void OnDrawGizmos(){
		Gizmos.color = debugColor;
		var pos = firePosition;
		if (inputState != null) {
			pos.x *= (float)inputState.direction;
		}
		pos.x += transform.position.x;
		pos.y += transform.position.y;
		Gizmos.DrawWireSphere (pos, debugRadius);

	}
}
