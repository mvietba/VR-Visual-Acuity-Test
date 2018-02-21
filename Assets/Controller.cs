using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Controller : MonoBehaviour {
	private Valve.VR.EVRButtonId trigBtn = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	private Valve.VR.EVRButtonId gripBtn = Valve.VR.EVRButtonId.k_EButton_Grip;
	private WorldController worldController;
	//StreamWriter writer = new StreamWriter("C:\\Users\\gamer-aalto\\logs.txt", true);
	private SteamVR_Controller.Device controller { 
		get { 
			return SteamVR_Controller.Input((int)trackedObj.index); 
		} 
	}
	private SteamVR_TrackedObject trackedObj;
	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
		worldController = GameObject.Find("PC").GetComponent<WorldController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller == null) {
			Debug.Log ("Null controller!");

		} else {
			if (!worldController.testStarted) {
				if (controller.GetPress (trigBtn)) {

					if (worldController.showInstructions) {
						worldController.testStarted = true;
						return;
					}
					else {
						worldController.showInstructions = true;
                        return;
					}
				}

			} else {
                Debug.Log("Test started!");
				if (this.name.Contains ("left"))
					LeftControllerAction ();
				else if (this.name.Contains ("right"))
					RightControllerAction ();
				else
					Debug.Log ("Unrecognised controller!");
			}
		}
	}

	void LeftControllerAction()
	{
		if (controller.GetPress (trigBtn)) {
			UpdateTest ("180°");
		}
		if (controller.GetPress (gripBtn)) {
			UpdateTest ("270°");
		}

	}

	void RightControllerAction()
	{
		if (controller.GetPress (trigBtn)) {
			Debug.Log ("Right Trigger Button pressed");
			UpdateTest ("0°");

		}
		if (controller.GetPress (gripBtn)) {
			Debug.Log ("Right Grip Button pressed");
			UpdateTest ("90°");
		}
	}

	void UpdateTest(string orientation)
	{
		worldController.testOngoing = false;
		worldController.testNo += 1;
		//writer.WriteLine(orientation);
		//writer.Close ();

	}
}
