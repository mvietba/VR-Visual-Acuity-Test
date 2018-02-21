using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftController : MonoBehaviour {
	private Valve.VR.EVRButtonId trigBtn = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

	private SteamVR_Controller.Device controller { 
		get { 
			return SteamVR_Controller.Input((int)trackedObj.index); 
		} 
	}
	private SteamVR_TrackedObject trackedObj;
	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller == null) {
			Debug.Log ("Null controller!");
		} else {
			if (controller.GetPress (trigBtn)) {
				Debug.Log ("Trigger Button pressed");
			}
		}
	}
}
