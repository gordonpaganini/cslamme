QUT Apps Readme

This file contains information about the QUT Apps for MSRS,
including installation instructions. It is for the official
release of Version 1.5.


Quick Start Instructions

Download the ZIP file and unzip it into your MSRS directory.
Note that this is assumed to be:
C:\Microsoft Robotics Studio (1.5)

When you unzip the file, it creates five projects in the
Apps\QUT directory under your MSRS installation:
Dashboard
DifferentialDriveTT
ExplorerSim
Intro
MazeSimulator

Some batch files and shortcuts are copied into the MSRS
root directory. The contents of the MSRS Code Pages are
also included, so you can view them without having to go
to the web -- simply open Apps\QUT\index.htm

Now open a MSRS DOS Command Prompt window and at the DOS
prompt type the following command:

RebuildQUTApps

(DOS commands are not case-sensitive, but it looks better
in mixed upper and lower case. There are no spaces in the
command -- it is the name of a batch file.)


IMPORTANT NOTE: The rebuild will not work if your copy
of MSRS is not installed on the C: drive in the default
location. In this case, you can try to update the solution
files by "migrating" the projects using the command:

DssProjectMigration Apps\QUT

If this does not work, then you will need to change the
following Project Property settings in each of the projects:
Output Path in Build
Post-Build Events in Build Events
Start External Program and Working Directory in Debug
Reference Paths

All you probably need to do is change C: to your drive
letter, unless you also installed into it with a different
directory name, and then it is more complicated.

The RebuildQUTApps.cmd batch file will recompile the
code for all of the services. It also copies texture files
into the store\media directory. You can re-run this batch
file as often as you want, but you will see error messages
after the first time when it tries to copy the textures.
These errors can be ignored.

If you want to compile the projects yourself, then open
each of the projects in turn in the following order and
do a rebuild:
Apps\QUT\DifferentialDriveTT\SimulatedDifferentialDriveTT.sln
Apps\QUT\Dashboard\Dashboard.sln
Apps\QUT\MazeSimulator\MazeSimulator.sln
Apps\QUT\Intro\Intro.sln
Apps\QUT\ExplorerSim\ExplorerSim.sln


Running the Programs

There are batch files for running each of the programs
so that you don't have to enter long command lines.
When the rebuild has completed, type the following at
the MSRS DOS prompt:

RunExplorerSim

Alternatively, you can run the Intro program with:

RunIntro

You can also run the Maze Simulator without starting the
Explorer by typing:

RunMazeSimulator

I have supplied three shortcuts that can be used instead
of the .bat files. However, if your copy of MSRS is NOT
installed on the C: drive (it automatically selected that
drive for me when I installed it), or it is not in the
default folder you will have to edit the properties of
the shortcuts and change the "Target" and "Start In"
properties to use the correct directory.


Comments and suggestions are welcome!


Trevor Taylor
Faculty of IT, QUT
July 2007 