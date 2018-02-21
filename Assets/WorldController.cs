using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldController : MonoBehaviour {
	public Text txt;
	// Use this for initialization
	void Start () {
		txt.text = "Hi! This is a visual acuity test!\n" +
			"To start off, please stand at the red bar marked on the floor.\n" +
			"Press trigger once you're done.";
	}
	
	// Update is called once per frame
	//1 unit = 1 meter
	void Update () {
		
	}
}
