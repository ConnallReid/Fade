using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public string targetTag = "Player";

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == targetTag) {
			
			Destroy(target.gameObject);
		}
	}
		


}
