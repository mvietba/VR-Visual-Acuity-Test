using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	private WorldController worldController;
    private string dir = "";

    private SteamVR_TrackedController _controller;
    // Use this for initialization
    void Start () {
		worldController = GameObject.Find("PC").GetComponent<WorldController>();
        _controller = GetComponent<SteamVR_TrackedController>();
        Debug.Log(_controller);
        _controller.TriggerClicked += HandleTriggerClicked;
        _controller.PadClicked += HandlePadClicked;
        _controller.Gripped += HandleGripClicked;
    }

    private void HandlePadClicked(object sender, ClickedEventArgs e)
    {
        Debug.Log(dir);
        worldController.OnNextPressed(dir);
    }

    private void HandleTriggerClicked(object sender, ClickedEventArgs e)
    {
        if (worldController.testStarted)
        {
            if (this.name.Contains("left"))
                dir = "l";
            else if (this.name.Contains("right"))
                dir = "r";
        }
    }

    private void HandleGripClicked(object sender, ClickedEventArgs e)
    {
        if (worldController.testStarted)
        {
            if (this.name.Contains("left"))
                dir = "u";
            else if (this.name.Contains("right"))
                dir = "d";
        }
    }
}
