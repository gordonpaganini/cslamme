
SimulatedSonar is distributed under the terms of GNU GPL (see license.txt).
CRANIUM (c) 2007. Raúl Arrabales Moreno. (raul at conscious-robots.com)


//------------------------------------------------------------------------------
// Part of MSRS Sample Code - Modified by Raul Arrabales - 27 Jul 07
//
// SIMULATED SONAR SERVICE
//
// CRANIUM - SIMULATED SONAR SENSOR
// This service provides access to a simulated P3DX frontal Sonar Array. 
// It uses the LRF raycasting to simulate Sonar transducers. 
//
// As suggested by Kyle - MSFT: 
// "you can make a reasonable simulated sonar sensor by doing something similar 
// to the simulated laser rangefinder.  Instead of casting hundreds of rays in a 
// scanline pattern like the laser rangefinder does, cast a handful of rays in a 
// cone that matches the aperture of the sonar sensor you want to simulate.  In 
// your code, look at the distance results returned by each ray and then set the 
// sonar return value to be the closest intersection.  
// 
// This code is provided AS IS. No warranty is provided for any purpose. 
// Use it at your own risk. 
// Please notify bugs, suggestions to: raul@conscious-robots.com
//
//  $File: SimulatedSonar.cs $ $Revision: update 4 $
//------------------------------------------------------------------------------



INSTRUCTIONS

This ZIP file contains the source code and Visual Studio project.
Extract files to MSRS 1.5 Home path. The directory Apps\UC3M\SimulatedSonar
will be created. It contains the source code for the simulated SONAR Service.




HISTORY

update5:
	(14th Nov 2007)
	Fixed a bug in the service state initialization and storage.

update4:

	(21st Sep 2007)
	SimulatedSonar Update 4 is available for download. Sonar transducer cone 
	aperture has been changed to 15 degrees to match the real angular aperture 
	of Pioneer 3 DX Sonar transducers. Therefore, total angular range of the 
	sonar ring is 195 degrees (180 plus two cone halves). Note that there are 
	blind spots between sonar transducers.

beta3: 
	(7th Aug 2007) A SonarChangeThreshold variable has been added with a 
	default value of 100.0. Subscriber services are only notified when the
	change in the readings is greater than this threshold. This reduces the
	number of notification received by the subscribers.

beta2:
	Removed SickLRF project from the SimulatedSonar solution. 
	Installation path changed to <MSRS>\Apps\UC3M\SimulatedSonar

beta1:
	First version. Still testing.