using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Buttons{
	Right,
	Left,
	Up,
	Down,
	A,
	B
}
public enum Condition{
	GreaterThen,
	LessThen
}
[System.Serializable]
public class InputAxisState{
	public string axisName;
	public float offValue;
	public Buttons button;
	public Condition condition;

	public bool value{

		get{ 
			var val = Input.GetAxis (axisName);

			switch (condition) {
			case Condition.GreaterThen:
				return val > offValue;
			case Condition.LessThen:
				return val < offValue;
			}
			return false;
		}
	}
}

public class InputManager : MonoBehaviour {

	public InputAxisState[] inputs;
	public InputState inputState;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (var input in inputs) {
			inputState.SetButtonValue (input.button, input.value);
		}
	}
}
