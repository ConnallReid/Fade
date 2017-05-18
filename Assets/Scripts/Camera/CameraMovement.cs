using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public GameObject player;
	public float smoothTime = 0.25f;
	public Vector2 volocity;
	private Transform moveCamera;

	void Start () 
	{
		moveCamera = transform;
	}

	void Update () 
	{
		//follow the player at a delay for smooth follow
		moveCamera.position = new Vector3 (Mathf.SmoothDamp (moveCamera.position.x, player.transform.position.x, ref volocity.x, smoothTime), moveCamera.position.y, moveCamera.position.z);
		moveCamera.position = new Vector3 (moveCamera.position.x, Mathf.SmoothDamp (moveCamera.position.y, player.transform.position.y, ref volocity.y, smoothTime), moveCamera.position.z);


	}
}
