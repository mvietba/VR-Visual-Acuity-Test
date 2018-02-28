# VR-Visual-Acuity-Test
This is a solution to the 2nd assignment from the course **CS-E4002 Virtual and Augmented Reality**,  Aalto University.

Student: **Viet Ba, Mai**.

Mail: <firstname_without_space>.<lastname>@aalto.fi

Developed with Unity3D version 2017.3.0f3 Personal on Windows 10.

## Free Unity Assets used:
* VR setup: SteamVR
* Furnitures & materials: Props for the Classroom

## Test Setup
* Chart scaled to A4 size (0.21 x 0.297 units in Unity) - according to http://visionsource.com/patients/free-eye-chart-download/ A4 is sufficient for 10 feet (3m) distance.
* Distance between the chart and a red cube indicating where the player should stand is 3 units in Unity (1 unit was mapped to 1 meter).
* Instructions are displayed on a white board placed on the right side of the Tumbling E chart.

## Test procedure
Test procedure and "Tumbling E" chart from: http://www.blog.contactlensking.com/Tumbling-E-Eye-Chart.php
* Stand behin the red log on the floor.
* Repeat for each eye:
	* Close an eye during each test.
	* Indicate orientation of each "E" from top to bottom, left to right. In game, the current letter is also always underlined with a green line to easily keep track of letters in question.
	* Test ends once over 50% of answers are incorrect or when all letters on the chart are read.

## Controllers
* Touch pad press (any of the controllers) - to continue to next instruction or to confirm choice of direction during the tests.
* Directions in which letter E's "legs" are pointing were indicated with:
	* Trigger button - right (right controller) and down (left controller),
	* Grip button - left (right controller) and up (left controller).
	
	<!--- Project's Github repository: https://github.com/mvietba/VR-Visual-Acuity-Test--->