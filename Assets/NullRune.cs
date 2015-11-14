using UnityEngine;
using System.Collections;

public class NullRune : VirtualRune {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	override public void Activate () {
		Debug.Log("Null Rune");
	}
}
