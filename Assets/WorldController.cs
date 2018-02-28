using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldController : MonoBehaviour {
	public Text txt;
	public Image instructionImg;
	private bool testCompleted = false;
    private int instructionsShown = 0;
    private bool leftTest = false;
    private bool rightTest = false;

	private int[] rows;
	private int[] cols;
	private string[] directions; //from top to bottom, left to right
	private string[] instructions;
	private string eye;
	private int incorrect = 0;
	public int testNo;
    public bool testStarted;
    public GameObject chartContainer;

    // Use this for initialization
    void Start () {

        testNo = 0;
        testStarted = false;

        instructionImg.enabled = false;
		eye = "LEFT";
        rows = new int[] {1,
                        2, 2,
                        3, 3, 3,
                        4, 4, 4, 4,
                        5, 5, 5, 5, 5,
                        6, 6, 6, 6, 6,
                        7, 7, 7, 7, 7, 7, 7,
                        8, 8, 8, 8, 8, 8, 8, 8,
                        9, 9, 9, 9, 9, 9, 9, 9};
        cols = new int[] {1,
                          1, 2,
                          1, 2, 3,
                          1, 2, 3, 4,
                          1, 2, 3, 4, 5,
                          1, 2, 3, 4, 5,
                          1, 2, 3, 4, 5, 6, 7,
                          1, 2, 3, 4, 5, 6, 7, 8,
                          1, 2, 3, 4, 5, 6, 7, 8};
        directions = new string[]{"r",
                                  "d", "r",
                                  "u", "r", "u",
                                  "r", "l", "d", "u",
                                  "r", "d", "l", "u", "d",
                                  "l", "d", "l", "u", "r",
                                  "l", "l", "d", "d", "d", "r", "u",
                                  "r", "d", "u", "r", "d", "u", "r", "d",
                                  "r", "d", "u", "l", "r", "d", "u", "r"};

        instructions = new string[] {
            "Indicate direction in which a letter E\'s \"legs\" are pointing at.\n" +
            "Do that for each letter from top to bottom, left to right.\n",           
            "You can change chosen direction if mis-clicked: \n"+
            "only the last indicated direction before pressing touchpad is registered.",
            "You will perform two set of tests for each eye, where one eye has to be closed.\n",
            "A test set ends either:\n" +
            "- When you reach the last letter in the chart\n" +
            "- If more than half of answers are incorrect.",
            "Get acquainted	with which buttons represent which directions from instructions shown next.\n" +
            "They will be always shown during the tests.",
            "For the first test set, please close your LEFT EYE.\n" +
            "Press touchpad to start the test."
            };
    }
	
	public void OnNextPressed(string dir = ""){
		if (!testCompleted) {
			if (testStarted) {
                // all instructions shown, test started
                //show current column and row in case the person gets lost

                Debug.Log(testNo);
                if (dir != "" || testNo == 0)
                {
                    txt.text = eye + " eye closed:\ntest " + (testNo + 1).ToString() + ", row: " + rows[testNo].ToString() + ", column: " + cols[testNo].ToString();
                    chartContainer.transform.Find("New Sprite (" + testNo.ToString() + ")").gameObject.SetActive(true);
                    if (testNo > 0)
                    {
                        int idx = testNo - 1; //text is updated for next test, but calculations are done for previous
                        chartContainer.transform.Find("New Sprite (" + idx.ToString() + ")").gameObject.SetActive(false);
                        chartContainer.transform.Find("New Sprite (" + testNo.ToString() + ")").gameObject.SetActive(true);

                        Debug.Log(dir + ", " + directions[idx]);
                        if (dir != directions[idx])
                            incorrect += 1;


                        Debug.Log(">> Incorrectness: " + ((float)incorrect / (float)testNo).ToString());
                        if (idx > directions.Length || (((float)incorrect / (float)testNo > 0.5) && idx > 1)) //let the person do at least 2 tests
                        {
                            chartContainer.transform.Find("New Sprite (" + testNo.ToString() + ")").gameObject.SetActive(false);

                            if (!leftTest)
                            {
                                leftTest = true;
                                txt.text = "You completed a test set for your  LEFT EYE with " + incorrect.ToString() + " incorrect answers.\n" +
                                            "Please close your RIGHT eye in the next test set.\n" +
                                            "Press touchpad to start the test.";
                                //restart
                                incorrect = 0;
                                testNo = 0;
                                return;
                            }
                            if (leftTest && !rightTest)
                            {
                                rightTest = true;
                                testCompleted = true;
                                txt.text = "You completed a test set for your RIGHT EYE with " + incorrect.ToString() + " incorrect answers.\n" +
                                            "The visual acuity test is completed.";
                            }

                        }
                    }
                    testNo += 1;

                }
                else
                    Debug.Log("Dir is empty!");
			}
			else { //there are still instructions to show
			
				txt.text = instructions[instructionsShown];
				instructionsShown += 1;
                if (instructionsShown == instructions.Length)
                {
                    txt.rectTransform.offsetMin = new Vector2(0, 65);
                    instructionImg.enabled = true;
                    testStarted = true;
                }
			}
		}
	}
}
