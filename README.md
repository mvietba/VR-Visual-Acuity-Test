# VR-Visual-Acuity-Test
This is a solution to the 2nd assignment from the course **CS-E4002 Virtual and Augmented Reality**,  Aalto University.

Student: **Viet Ba, Mai**.

Mail: <firstname_without_space>.<lastname>@aalto.fi

Developed with Unity3D version 2017.3.0f3 Personal on Windows 10.

## Free Unity Assets used:
* VR setup: SteamVR
* Furnitures & materials: Props for the Classroom

## Tumbling E Procedure & Setup
Test procedure and "Tumbling E" chart from: http://www.blog.contactlensking.com/Tumbling-E-Eye-Chart.php
* Chart scaled to A4 size (0.21 x 0.297 units in Unity) - according to http://visionsource.com/patients/free-eye-chart-download/ A4 is sufficient for 10 feet (3m) distance.
* Distance between the chart and a red cube indicating where the player should stand is 3 units in Unity (10 feet).
* Repeat for each eye:
	* Request the person to indicate orientation of each "E" from top to bottom, left to right.
	* End test once 50% or more answers are incorrect or when all letters are read.