//------------------------------------------------------------------------------
// Intro.cs
//
// Sample MSRS program that illustrates a simple wandering behaviour
// using a simulated robot. The robot wanders at random until a bumper
// notification is received. Then it stops, reverses direction for a
// short period, turns a random amount and then starts driving again.
//
// Written by Trevor Taylor, Queensland University of Technology
// This code is freely available
//
// IMPORTANT NOTE: Please read the readme.txt for information
// on how to install the program. The Maze Simulator is required
// to run this program and should therefore be installed first.
//
// Released 19-Sep-2006
// Updated for the September 2006 CTP
//
// Released 7-Oct-2006
// Updated for the October 2006 CTP
// No changes required!
// (Apart from running Migration tool, and re-adding reference
// to RoboticsCommon.Proxy.)
// Changed the Manifest to use the updated Dashboard (which is
// no longer called SimpleDashboard due to divergence of the
// code bases.)
//
// Updated for the November 2006 CTP
// Remove and re-add the reference to Robotics.Common.Proxy
// Only one minor change required to the code
//
// Updated for V1.0 release December 2006
//
// Added a hack to allow use of the Lego NXT instead of the Pioneer 3DX.
// The Lego robot only has a front bumper, so it must always move forwards.
// However, the Lego robot falls over a lot so it is not much use.
// (My real Lego robot does not do this so much, but it all depends on
// the speed.)
// To switch between the Lego and Pioneer, you need to edit the config
// file for the Maze Simulator and change the RobotType property to
// either LegoNXT or Pioneer3DX. 
//
// Moved several constants to the State so that they are visible and it
// is possible to use a config file with a State Partner.
//
// Jul-2007 - Updated for the V1.5 release
// Only one small change was required to save the config file to the
// correct directory. (Change in behaviour in V1.5)
// Added a new State field and made an attempt to solve the problem
// where the robot sometimes stops wandering. I could not find the
// problem with it stopping -- the state says that it is moving!
//
// Viewing the state is extremely slow using a browser. Probably because
// the simulator is sucking up all of the CPU time.
//
// Fixed a bug in the StopNow() routine.
//
// There appears to be a bug in V1.5 in the collision detection.
// The front of the robot actually moves inside walls! This can
// cause it to be explosively expelled, with the result that it
// often falls over.
//
//------------------------------------------------------------------------------
using Microsoft.Ccr.Core;
using Microsoft.Dss.Core;
using Microsoft.Dss.Core.Attributes;
using Microsoft.Dss.ServiceModel.Dssp;
using Microsoft.Dss.ServiceModel.DsspServiceBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Permissions;
using xml = System.Xml;

// Additional namespaces after creation with dssnewservice
//
// Robotics Tutorial 1 Step 1 -- Add reference
// Add a reference to RoboticsCommon.proxy which provides
// generic interfaces. Don't add references to the actual
// hardware here! The partnership will be set up later in
// the manifest.
using bumper = Microsoft.Robotics.Services.ContactSensor.Proxy;

// Robotics Tutorial 2 Step 1 -- Add reference
// The reference already exists, just insert this using statement.
// Does not work though. Should use a drive. See below.
using motor = Microsoft.Robotics.Services.Motor.Proxy;

// Robotics Tutorial 3 Step 1 -- Add reference
// This is a generic drive service. It can therefore work with
// and service that implements a DifferentialDrive.
using drive = Microsoft.Robotics.Services.Drive.Proxy;


namespace Robotics.Intro
{
    
    [DisplayName("Intro")]
    [Description("The Intro Service - Wander using bumpers")]
    [Contract(Contract.Identifier)]

    public class IntroService : DsspServiceBase
    {
        // TT Dec-2006 - Add an initial state partner to get the config
        // TT Jul-2007 - Change in behaviour for V1.5
        public const string InitialStateUri = ServicePaths.MountPoint + @"/Apps/QUT/Config/Intro.Config.xml";

        // Add an InitialStatePartner so that the config file will be read
        // NOTE: Creating a new instance of the state here will NOT
        // work if there is no config file because InitialStatePartner
        // will replace it with null!!! See the code in Start().
        [InitialStatePartner(Optional = true, ServiceUri = InitialStateUri)]

        private IntroState _state;

        [ServicePort("/intro", AllowMultipleInstances=false)]
        private IntroOperations _mainPort = new IntroOperations();

        // Robotics Tutorial 1 Step 2 -- Add a partner
        // See also the details in the manifest.
        // Note that the policy says UseExisting.
        // We will be creating the Simulation first, so this service
        // should already exist.
        [Partner("bumper", Contract = bumper.Contract.Identifier,
             CreationPolicy = PartnerCreationPolicy.UseExisting)]
        private bumper.ContactSensorArrayOperations _bumperPort = new bumper.ContactSensorArrayOperations();

        // Robotics Tutorial 2 Step 2 -- Add a partner
        //[Partner("motor", Contract = motor.Contract.Identifier,
        //CreationPolicy = PartnerCreationPolicy.UseExisting)] 
        //private motor.MotorOperations _motorPort = new motor.MotorOperations();

        // Robotics Tutorial 3 Step 1 -- Add partners
        // A bumper partner already exists above
        [Partner("Drive",
           Contract = drive.Contract.Identifier,
            CreationPolicy = PartnerCreationPolicy.UseExisting)]
        drive.DriveOperations _drivePort = new drive.DriveOperations();

        /// <summary>
        /// Default Service Constructor
        /// </summary>
        public IntroService(DsspServiceCreationPort creationPort) : 
                base(creationPort)
        {

        }

        /// <summary>
        /// Service Start
        /// </summary>
        protected override void Start()
        {
            // TT Dec-2006 - Setup for initial state
            // The state might already have been created using
            // the Initial State Partner above. If so, then we
            // don't want to create a new one!
            if (_state == null)
            {
                _state = new IntroState();
                // Do any other initialization here for the default
                // settings that you might want ...
            }

            // There should be some code in here to validate the settings
            // from the config file just in case the user entered some
            // invalid values ...

            // Now save the State
            // This creates a new file the first time it is run.
            // Later, it re-reads the existing file, but by then
            // the file has been populated with the default values.
            SaveState(_state);

            // Listen on the main port for requests and call the appropriate handler.
            ActivateDsspOperationHandlers();

            // Robotics Tutorial Step 3 -- Service Startup Initialization
            // Start() is a required method that was created by
            // dssnewservice. We need to modify it.
            // Start listening for bumpers
            // See the method code below
            SubscribeToBumpers();

            // Publish the service to the local Node Directory
            DirectoryInsert();

			// display HTTP service Uri
			LogInfo(LogGroups.Console, "Service uri: ");
        }


        // Robotics Tutorial 1 Step 4 -- Subscribing to services
        // Robotics Tutorial 2 Step 2 -- Same code
        // Robotics Tutorial 3 Step 2 -- Similar
        /// <summary>
        /// Subscribe to the Bumpers service
        /// </summary>
        // Create the bumper notification port
        bumper.ContactSensorArrayOperations bumperNotificationPort = new bumper.ContactSensorArrayOperations();
        void SubscribeToBumpers()
        {

            // Subscribe to the bumper service, receive notifications on the bumperNotificationPort
            _bumperPort.Subscribe(bumperNotificationPort);

            // Start listening for updates from the bumper service
//            Activate(
//                Arbiter.Receive<bumper.Update>
//                    (true, bumperNotificationPort, BumperHandler));
            Activate(
                Arbiter.Interleave(
                    new TeardownReceiverGroup(),
                    new ExclusiveReceiverGroup(
                        Arbiter.Receive<bumper.Update>
                            (true, bumperNotificationPort, BumperHandler)
                    ),
                    new ConcurrentReceiverGroup()
                )
            );
        }


        /// <summary>
        /// Get Handler
        /// </summary>
        /// <param name="get"></param>
        /// <returns></returns>
        [ServiceHandler(ServiceHandlerBehavior.Concurrent)]
        public virtual IEnumerator<ITask> GetHandler(Get get)
        {
            get.ResponsePort.Post(_state);
            yield break;
        }
        /// <summary>
        /// Replace Handler
        /// </summary>
        /// <param name="replace"></param>
        /// <returns></returns>
        [ServiceHandler(ServiceHandlerBehavior.Exclusive)]
        public virtual IEnumerator<ITask> ReplaceHandler(Replace replace)
        {
            _state = replace.Body;
            replace.ResponsePort.Post(DefaultReplaceResponseType.Instance);
            yield break;
        }

        // Robotics Tutorial 1 Step 5 -- Create a handler for the subscription
        // The Robotics Tutorial says to add this at the end
        // of the file, but I don't know why because it compiles
        // wherever you put it ...

        // There seems to be a major problem with the approach in
        // Robotics Tutorial 3. It results in the robot jerking up
        // against the wall because of a backlog of queued messages.

        /// <summary>
        /// Handle Bumper Notifications
        /// </summary>
        /// <param name="notification"></param>
        void BumperHandler(bumper.Update notification)
        {
            string message;
            string bumperName;
            DateTime thisTimestamp;
            TimeSpan timediff;
            // Find out which bumper this is
            // TT - Nov CTP
//            int num = notification.Body.Identifier;
            int num = notification.Body.HardwareIdentifier;
 
            // Robotics Tutorial 3:
            //contactsensor.ContactSensor s = updateNotification.Body;

            if (string.IsNullOrEmpty(notification.Body.Name))
                bumperName = "";
            else
                bumperName = notification.Body.Name.ToLowerInvariant();

            if (!notification.Body.Pressed)
            {
                message = "Bumper " + num.ToString() + " (" + bumperName + ") was released.";
                LogInfo(LogGroups.Console, message);
                return;
            }
            else
            {
                message = "Ouch! Bumper " + num.ToString() + " (" + bumperName + ") was pressed.";
                LogInfo(LogGroups.Console, message);
                StopNow();
            }

            // OK, we have a bump!
            // What if it is the OPPOSITE bumper?
            // This should be handled better.
            // In particular, there are instances where both front
            // AND back bumpers are triggered! It would be a better
            // idea to remember the direction of motion and always
            // back up when a bumper notification is received.

            // Get the current time
            thisTimestamp = System.DateTime.Now;
            // Make sure that we have waited long enough for the last
            // motion to complete. This is a fudge that effectively
            // renders the robot blind for a short period of time.
            // Not really a good solution if there is a chance that
            // the opposite bumper will be triggered legitimately.
            // It is sometimes referred to as a "dead zone" and is
            // similar to what is used in simple "bang bang" or
            // "on/off" control to avoid the continuous oscillations.
            if (thisTimestamp < _state.nextTimestamp)
            {
                int count = 0;
                bumper.Replace testBump = null;
                bumper.Replace testBump2 = null;
                int skip = bumperNotificationPort.P3.ItemCount;
                // We don't want any more bump notifications while we
                // are processing the current one.
                // This code for skipping notifications uses a pattern
                // from the Traxster motor.cs. However, the types of
                // messages involved are different so it is not just a
                // copy and paste :-(
                // Note that the queue can easily get over a thousand
                // messages in a short space of time!
                for (int i = 0; i < skip; i++)
                {
                    testBump = (bumper.Replace) bumperNotificationPort.P3.Test();
                    if (testBump != null)
                    {
                        count++;
                        // reply and pretend everything went well
                        testBump.ResponsePort.Post(DefaultReplaceResponseType.Instance);
                    }
                }
                if (count > 0)
                {
                    message = "Ignored " + num.ToString() + " - " + count.ToString() + " messages";
//                    LogInfo(LogGroups.Console, message);
                }
                // Return without doing anything
                return;
            }

            // Wait for the motion to complete for this amount
            // of time, i.e. ignore future bumps!!!
            // This is a fudge because we don't know for sure
            // how long any particular motion will take, but
            // it's the best we can do.
            _state.nextTimestamp = thisTimestamp.AddMilliseconds(3500);

            // From Robotics Tutorial 3
            // Look carefully at the code. At first glance, it seems
            // to call the same function for either bumper, but the
            // polarity parameter is different.
            if (bumperName.Contains("front"))
            {
                if (_state.insideBehavior <= 0)
                {
                    LogInfo(LogGroups.Console, ">>> Start -1");
                    // Set a flag so that multiple threads
                    // will not execute the behavior at the
                    // same time. This is possible, but the
                    // motor commands will get "interleaved"
                    // and the robot does some really strange
                    // things!
                    _state.insideBehavior++;
                    // Create a new iterator to execute the
                    // behavior
                    SpawnIterator<double>(-1, BackUpTurnAndMove);
                }
                return;
            }

            if (bumperName.Contains("rear"))
            {
                if (_state.insideBehavior <= 0)
                {
                    LogInfo(LogGroups.Console, ">>> Start +1");
                    // Set the synchronization flag
                    _state.insideBehavior++;
                    SpawnIterator<double>(1, BackUpTurnAndMove);
                }
                return;
            }

        }


        // From Robotics Tutorial 3 Step 3 --
        // Issuing drive commands to turn and move
        // Need to make sure that we have all the necessary variables
        // declared above

        // Had to get this from the tutorial solution
        Random _randomGen = new Random();


        // Added so that I could confirm that the delays were happening
        // and get some idea how long to set for each step. Note that
        // the console appears to be a long way behind, so a flurry of
        // messages will appear, apparently without any delay. However,
        // the messages say otherwise ...
        DateTime startTime, endTime;
        TimeSpan diffTime;

        /// <summary>
        /// BackupTurnAndMove
        /// </summary>
        /// <param name="polarity">Indicates the direction to move (forward or backward)</param>
        /// <returns>Nothing</returns>
        // BackupTurnAndMove is called when the robot runs into something.
        // Note that there are front and back bumpers, so the "backup" motion
        // is actually a move forwards if it was the rear bumper that was hit.
        // It uses sequential processing with delays rather than a finite
        // state machine which would require more routines and be more
        // complicated.
        IEnumerator<ITask> BackUpTurnAndMove(double polarity)
        {
            string msg;
            // First STOP!
            // Let the physics engine take care of settling the robot
            // down after it's encounter with the wall!
            startTime = DateTime.Now;
            yield return Arbiter.Receive(false,
                Stop(),
                delegate(bool result) { });

            // wait for stop to complete
            yield return Arbiter.Receive(false, TimeoutPort(_state.StopTimeout), delegate(DateTime t) { });

            endTime = DateTime.Now;
            diffTime = endTime.Subtract(startTime);
            msg = "Waited " + diffTime.TotalMilliseconds + " ms";
            LogInfo(LogGroups.Console, msg);

            // Now backup a little
            startTime = DateTime.Now;
            yield return Arbiter.Receive(false,
                StartMove(_state.BackUpPower * polarity),
                delegate(bool result) { });

            // wait for backing up motion
            yield return Arbiter.Receive(false, TimeoutPort(_state.BackUpTimeout), delegate(DateTime t) { });

            endTime = DateTime.Now;
            diffTime = endTime.Subtract(startTime);
            msg = "Waited " + diffTime.TotalMilliseconds + " ms";
            LogInfo(LogGroups.Console, msg);

            // now Turn
            startTime = DateTime.Now;
            yield return Arbiter.Receive(false,
                StartTurn(),
                delegate(bool result) { });

            // wait for turn
            yield return Arbiter.Receive(false, TimeoutPort(_state.TurnTimeout), delegate(DateTime t) { });

            endTime = DateTime.Now;
            diffTime = endTime.Subtract(startTime);
            msg = "Waited " + diffTime.TotalMilliseconds + " ms";
            LogInfo(LogGroups.Console, msg);

            // now reverse direction and keep moving straight
            // TT Dec-2006 - For the Lego NXT, which only has a front
            // bumper, it is necessary to always move forwards. The
            // flag allows this by ignoring the polarity.
            double nextSpeed;
            if (_state.ForwardMovesOnly)
                nextSpeed = _randomGen.NextDouble();
            else
                nextSpeed = _randomGen.NextDouble() * polarity;

            yield return Arbiter.Receive(false,
                StartMove(nextSpeed),
                delegate(bool result) { });

            // wait - guarantee some minimum time to move so that
            // the robot will actually go somewhere
            yield return Arbiter.Receive(false, TimeoutPort(_state.MinimumDriveTimeout), delegate(DateTime t) { });

            // done
            LogInfo(LogGroups.Console, "<<< End\n");

            // Clear the flag to allow new bump messages
            _state.insideBehavior--;

            // Sometimes the robot will stop moving at this point.
            // This only happens if there is a particular combination of events.
            if (_state.MoveState == MoveStates.Stop)
            {
                yield return Arbiter.Receive(false,
                    StartMove(nextSpeed),
                    delegate(bool result) { });
            }

            yield break;
        }


        Port<bool> StartTurn()
        {
            Port<bool> result = new Port<bool>();
            // start a turn
            SpawnIterator<Port<bool>>(result, RandomTurn);
            return result;
        }


        Port<bool> Stop()
        {
            Port<bool> result = new Port<bool>();
            // stop movement
            SpawnIterator<Port<bool>>(result, DoStop);
            return result;
        }


        Port<bool> StartMove(double powerLevel)
        {
            Port<bool> result = new Port<bool>();
            // start movement
            SpawnIterator<Port<bool>, double>(result, powerLevel, MoveStraight);
            return result;
        }


        /// <summary>
        /// RandomTurn
        /// </summary>
        /// <param name="done">Port to post success message to</param>
        /// <returns>Ture/False depending on whether SetDrivePower succeeded</returns>
        IEnumerator<ITask> RandomTurn(Port<bool> done)
        {
            // We turn by issuing motor commands, using reverse polarity for left and right
            // We could just issue a Rotate command but since its a higher level function
            // We cant assume (yet) all our implementations of differential drives support it
            // TT -- In fact, the simulated Pioneer does NOT support rotate even in the
            // September 2006 CTP.
            drive.SetDrivePowerRequest setPower = new drive.SetDrivePowerRequest();
            setPower.LeftWheelPower = ValidatePowerLevel(_randomGen.NextDouble());
            setPower.RightWheelPower = ValidatePowerLevel(-setPower.LeftWheelPower);

            string msg;
            msg = "Random Turn " + setPower.LeftWheelPower.ToString() + ", " + setPower.RightWheelPower.ToString();
            LogInfo(LogGroups.Console, msg);

            bool success = false;
            yield return
                Arbiter.Choice(
                   _drivePort.SetDrivePower(setPower),
                   delegate(DefaultUpdateResponseType rsp)
                   {
                       _state.DrivePowerLeft = setPower.LeftWheelPower;
                       _state.DrivePowerRight = setPower.RightWheelPower;
                       _state.MoveState = MoveStates.Turn;
                       success = true;
                   },
                   delegate(W3C.Soap.Fault failure)
                   {
                       // report error but report done anyway. we will attempt
                       // to do the next step in wander behavior even if turn failed
                       LogError("Failed setting drive power");
                   });

            done.Post(success);

            yield break;
        }

        // StopNow() is a quick stop that is called as soon as a
        // bumper press is detected. Unfortunately, inertia makes
        // the robot keep bumping up against the wall. This results
        // in a flood of messages. If there are to many to process,
        // there might still be some in the queue after the behavior
        // has finished, and the robot will stop even though it is
        // no longer in contact with the wall ... This leaves it
        // stranded and you have to start it again :-(
        void StopNow()
        {
            drive.AllStopRequest stopReq = new drive.AllStopRequest();
            string msg;
            msg = "Stop";
            LogInfo(LogGroups.Console, msg);

            // TT Jul-2007 - Oops! This Arbiter.Choice was not activated
            Arbiter.Activate(TaskQueue,
                Arbiter.Choice(
                   _drivePort.AllStop(stopReq),
                   delegate(DefaultUpdateResponseType success)
                   {
                       _state.DrivePowerLeft = 0;
                       _state.DrivePowerRight = 0;
                       _state.MoveState = MoveStates.Stop;
                   },
                   delegate(W3C.Soap.Fault failure)
                   {
                       LogError("Failed to Stop!");
                   }
                )
            );
        }


        /// <summary>
        /// DoStop
        /// </summary>
        /// <param name="done">Port to post success message to</param>
        /// <returns>True/False depending on whether the AllStop worked</returns>
        IEnumerator<ITask> DoStop(Port<bool> done)
        {
            drive.AllStopRequest stopReq = new drive.AllStopRequest();
            string msg;
            msg = "Stop";
            LogInfo(LogGroups.Console, msg);

            yield return
                Arbiter.Choice(
                   _drivePort.AllStop(stopReq),
                   delegate(DefaultUpdateResponseType success)
                   {
                       _state.DrivePowerLeft = 0;
                       _state.DrivePowerRight = 0;
                       _state.MoveState = MoveStates.Stop;
                       done.Post(true);
                   },
                   delegate(W3C.Soap.Fault failure)
                   {
                       // report error but report done anyway. we will attempt
                       // to do the next step in wander behavior even if turn failed
                       LogError("Failed to Stop!");
                       done.Post(false);
                   });
        }


        /// <summary>
        /// MoveStraight
        /// </summary>
        /// <param name="done">Port to post success message to</param>
        /// <param name="powerLevel">Power level for the drive</param>
        /// <returns>True/False depending on whether SetDrivePower succeeded</returns>
        // IMPORTANT NOTE: MoveStraight() uses ValidatePowerLevel()
        // which sets a MINIMUM power level. In other words, you
        // can't stop the robot using MoveStraight!!!
        IEnumerator<ITask> MoveStraight(Port<bool> done, double powerLevel)
        {
            // Proxies dont currently have initialization constructors so we have to
            // explicitly set fields. This will be fixed post June 20th CTP
            drive.SetDrivePowerRequest setPower = new drive.SetDrivePowerRequest();
            setPower.LeftWheelPower = ValidatePowerLevel(powerLevel);
            setPower.RightWheelPower = ValidatePowerLevel(powerLevel);

            string msg;
            msg = "Move Straight " + setPower.LeftWheelPower.ToString() + ", " + setPower.RightWheelPower.ToString();
            LogInfo(LogGroups.Console, msg);

            yield return
                Arbiter.Choice(
                   _drivePort.SetDrivePower(setPower),
                   delegate(DefaultUpdateResponseType success)
                   {
                       _state.DrivePowerLeft = setPower.LeftWheelPower;
                       _state.DrivePowerRight = setPower.RightWheelPower;
                       _state.MoveState = MoveStates.MoveStraight;
                       done.Post(true);
                   },
                   delegate(W3C.Soap.Fault failure)
                   {
                       // report error but report done anyway. we will attempt
                       // to do the next step in wander behavior even if turn failed
                       LogError("Failed setting drive power in MoveStraight()");
                       done.Post(false);
                   });
        }

        // Had to get this from the tutorial solution also
        double ValidatePowerLevel(double powerLevel)
        {
            // we want to have a minimum power setting
            if (Math.Abs(powerLevel) < _state.MinimumPower)
            {
                // more readable to use if statement
                if (powerLevel < 0)
                    powerLevel = -(_state.MinimumPower);
                else
                    powerLevel = _state.MinimumPower;
            }
            // TT -- Also added a maximum
            // The robot is too powerful for it's own good and it
            // sometimes "climbs" walls and wedges itself, or crashes
            // so hard the it knocks itself over
            if (Math.Abs(powerLevel) > _state.MaximumPower)
            {
                // more readable to use if statement
                if (powerLevel < 0)
                    powerLevel = -(_state.MaximumPower);
                else
                    powerLevel = _state.MaximumPower;
            }
            return powerLevel;
        }

    }
}
