Modified Dashboard - Updated for MSRS V1.5

This code is a modified version of the SimpleDashboard that
is supplied with the Microsoft Robotics Studio.

It has several additional features:

1. It remembers settings!
2. You can customise the way that the "trackball" control works.
3. You can display the LRF in a top-down view.
4. It can display a WebCam window.
5. Motion Control buttons that use RotateDegrees and
DriveDistance to control the robot.

I have tested this code using a USB Joystick and it works OK.

It also works with a real web camera or a simulated camera.

The Motion Control buttons rely on functions that are new
in V1.5 for the Simulated Differential Drive. I provide my
own implementation of this service.


Saved Settings

Implicit values:
Window X and Y Position
Connection parameters
Log settings

The following are in the Options dialog:
Dead Zone X and Y
Translate Scale Factor
Rotate Scale Factor
Show LRF
Show Articulated Arm

New with V1.5:
Robot width in 3D LRF view
Display Map (top-down LRF view)
Max Range for LRF
Motion Control buttons with corresponding option settings



Known Problems

When you try to rotate the robot on the spot, you might find
that it starts to rotate in the wrong direction. This is a
"feature" of the way that the speeds are calculated for the
left and right motors. If this happens it will be because
you have moved the cursor below the horizontal line in the
trackball. Move up above the horizontal and it will fix
itself.

The File\Exit menu option closes the Dashboard window but does
not cause DssHost to exit. There is no clean method for doing
this in MSRS yet. (Refer to the Discussion Forum). This will be
corrected once V1.0 of MSRS has shipped.



Trevor Taylor
T.Taylor@qut.edu.au
July 2007
