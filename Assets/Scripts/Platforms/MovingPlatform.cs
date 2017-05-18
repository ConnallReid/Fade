using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {



	public GameObject platform;
	public float moveSpeed;
	public Transform currentPoint;
	public Transform[] points;
	public int pointselection;
	public bool reverse=false;
	// Use this for initialization
	void Start () {
		currentPoint = points[pointselection];
	}

	// Update is called once per frame
	void Update () {
		platform.transform.position = Vector3.MoveTowards (platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
		if (platform.transform.position == currentPoint.position) {
			if (pointselection == points.Length-1) {
				reverse = true;
				//pointselection = 0;
			}
			if (pointselection <= 0) {
				reverse = false;
				//pointselection = 0;
			}
			if(!reverse){
				pointselection++;
			}else if(reverse){
				pointselection--;
			}
		
			currentPoint = points [pointselection];
		}
	}
	// Use this for initialization

	public void OnDrawGizmos(){
		//checks for points
		if(points==null || points.Length <2){
			return;
		}
		//draw line for path
		for(var i =1;i<points.Length;i++){
			Gizmos.DrawLine(points[i-1].position,points[i].position);
		}

	}
}
