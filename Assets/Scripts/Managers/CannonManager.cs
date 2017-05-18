using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CannonDirection{
	Right=270,
	Left=90,
	Up=0,
	Down=180
}

public class CannonManager : MonoBehaviour {
	public CannonDirection direction = CannonDirection.Right;

	public GameObject ProjectlePrefab;
	public float shootDelay = .5f;
	private float timeElapsed = 0f;
	public Vector2 fireDirection = new Vector2 (0, 0);

	public Vector2 firePosition=Vector2.zero;
	public Color debugColor=Color.yellow;
	public float debugRadius = .5f;
	// Use this for initialization
	void Start () {
		//transform.localRotation.z = direction;
		transform.localRotation = Quaternion.Euler(0.0f, 0.0f, (float)direction);
		if (direction == CannonDirection.Right) {
			fireDirection.x = 10;
		}else if (direction == CannonDirection.Left) {
			fireDirection.x = -10;
		}else if (direction == CannonDirection.Up) {
			fireDirection.y = 10;
		}else if (direction == CannonDirection.Down) {
			fireDirection.y = -10;
		}
	}
	
	void Update () {
		if (ProjectlePrefab != null) {
			if (timeElapsed>shootDelay) {
				CreateProjectle (CalculateFirePosition());
				timeElapsed = 0f;
			}
			timeElapsed += Time.deltaTime;
		}
	}
	Vector2 CalculateFirePosition(){
		var pos = firePosition;
		//pos.x *= (float)inputState.direction;
		pos.x += transform.position.x;
		pos.y += transform.position.y;
		return pos;
	}
	public void CreateProjectle(Vector2 pos){
		var clone = Instantiate (ProjectlePrefab,pos,Quaternion.identity)as GameObject;
		clone.GetComponent<CannonBall>().initalVelocity= fireDirection;
		clone.transform.localScale = transform.localScale;
	}
}
