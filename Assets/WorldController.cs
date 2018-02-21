using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class WorldController : MonoBehaviour {
	public Text txt;
	private bool testCompleted = false;
	public bool testStarted = false;
	public bool showInstructions = false;
	public bool leftTest = false;
	public bool rightTest = false;
	public bool testOngoing = false;
	private int[] rows;
	private int testAmount;
	public int testNo;
	//StreamWriter writer = new StreamWriter("C:\\Users\\gamer-aalto\\logs.txt", true);

	// Use this for initialization
	void Start () {
		testNo = 0;
		testAmount = 10;
		rows = new int[9] {1, 2, 3, 4, 5, 5, 7, 8, 8};

    }
	
	// Update is called once per frame
	//1 unit = 1 meter
	void Update () {
		if (!testCompleted) {
			if (testStarted) {
				if (!leftTest) {
					if (testNo == testAmount) {
						testNo = 0;
						leftTest = true;
					}
					if (!testOngoing) {
						txt.text = "Close your LEFT EYE and indicate orientation of letter E in:\n" + PickRandomLetter ();
						testOngoing = true;
					}
					
				}
				if (leftTest && !rightTest) {
					if (testNo == testAmount) {
						testNo = 0;
						rightTest = true;
					}
					if (!testOngoing) {
						if (testNo == 0)
							txt.text = "You have completed the test for left eye.\n" +
								"Close your RIGHT EYE and indicate orientation of letter E in:\n" + PickRandomLetter ();
						else
							txt.text = "Close your RIGHT EYE and indicate orientation of letter E in:\n" + PickRandomLetter ();
						testOngoing = true;
					}
				}
				if (leftTest && rightTest) {
					txt.text = "You completed the test! Read logs.txt to check the answers.";
					testCompleted = true;
				}

			} else {
				if (showInstructions) {
					txt.text = "Indicate orientation of letter E by pressing \n" +
					"0° - RIGHT controller's trigger button, \n" +
					"90° clockwise - RIGHT controller's grip button, \n" +
					"180° clockwise (upside-down) - LEFT controller's trigger button\n" +
					"270° - LEFT controller's grip button. \n" +
					"Press trigger button on any of the controllers to START.";
				}
			}
		}
	}

	string PickRandomLetter() {
		int col = Random.Range (1, 9);
		int row = Random.Range (1, rows [col]);
		string s =  "Column: " + col.ToString() + "Row: " + row.ToString();
		//writer.WriteLine (s);
        //writer.Close();
		return s;
	}
}
