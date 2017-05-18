using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingPlatform : MonoBehaviour {
	public float fadeDelay=2f;
	public bool fadeBool;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		//if fadeBool is true start fading IEnumerator
		//if fadeActice is true start fade animation else continue
		if(fadeBool){
			animator.SetInteger ("AnimState", 1);
		}else{
			animator.SetInteger ("AnimState", 0);
		}
		if(fadeBool){
			StartCoroutine (fadeing());
		}
	}
	IEnumerator fadeing(){
		//delay fadeing then set fadeBool to fase and turn platform off
		yield return new WaitForSeconds(fadeDelay);
		fadeBool=false;
		gameObject.SetActive (false);
	}
	private void OnCollisionEnter2D (Collision2D target)
	{
		//when player touchs the platform set fade bool to true
		if (target.transform.name == "Player") {
			fadeBool = true;
		}

	}
}
