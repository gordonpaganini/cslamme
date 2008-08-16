//-----------------------------------------------------------------------
// This file was part of the Microsoft Robotics Studio Code Samples.
// 
// Copyright (C) Microsoft Corporation.  All rights reserved.
// Portions Copyright by Trevor Taylor.
//
//  $File: Dashboard.cs $ $Revision: 8 $
//
// Modifications by Trevor Taylor
// Faculty of IT
// Queensland University of Technology
//
// Version 1
// Incorporate changes to allow saving of settings so you don't have
// to re-enter connection and logging parameters every time you run
// the program.
//
// Version 2
// Add an "option bag" to hold various option settings that can then
// be saved into the state (config) file.
//
// Version 3
// Add initial x,y location for the window so that it will always
// start up in the same place and not wander around the screen!
// Minor changes to the way the dead zone was handled to make the
// robot speed changes smoother.
// Allow the scale factors to be negative (but not zero!). This
// might seem strange, but it allows the axes to be flipped on the
// "joystick" control for those people who want to invert them.
//
// Version 4
// Updated for the November 2006 CTP
// I just can't give up my Dashboard! I hate having to re-enter
// the connection details every time I use the Simple Dashboard,
// and my version is more compact.
// Only a couple of minor changes were required and no new
// functionality was added except for an About Box.
//
// Version 5 (for V1.0 of MSRS)
// Joystick has changed to GameController which meant that several
// areas of the code had to be updated. Had to change the references
// as well.
// Removed reference to the simulated Lynx arm because it no longer
// exists. (Not sure why it was there in the first place.)
// Minor changes in OnLogSettingHandler().
//
// Version 6 - 24-Jan-2007
// Updated with code supplied by Ben Axelrod to colour-code any
// obstacles directly in front of the robot in the LRF display
//
// Version 7 - May-2007
// Added the ability to display a map for the LRF instead of the
// simulated 3D view. Then I found out that Ben had done this too!
// Added buttons to support DriveDistance and RotateDegrees
// (Actually intended for testing, not serious use)
//
// Version 8 - Jun-2007 (May CTP of V1.5)
// Added WebCam Viewer, which I have wanted to do for months!
// It was a real pain in the neck due to bugs in the simulated
// webcam, but I finally got it working. It even works with a
// real webcam!
//
// Jul-2007:
// Verified with released version of V1.5
//
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Microsoft.Dss.Core.Attributes;

using W3C.Soap;
using Microsoft.Ccr.Core;
// TT Dec-2006 - Adaptors => Adapters
// Change reference as well
using Microsoft.Ccr.Adapters.WinForms;
using Microsoft.Dss.Core;

using Microsoft.Dss.ServiceModel.Dssp;
using Microsoft.Dss.ServiceModel.DsspServiceBase;
using Microsoft.Dss.Services.Serializer;
using Microsoft.Robotics.Simulation.Physics.Proxy;
using Microsoft.Robotics.Simulation.Proxy;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using arm = Microsoft.Robotics.Services.ArticulatedArm.Proxy;
using cs = Microsoft.Dss.Services.Constructor;
using drive = Microsoft.Robotics.Services.Drive.Proxy;
using ds = Microsoft.Dss.Services.Directory;
using fs = Microsoft.Dss.Services.FileStore;
// TT - Changed in Oct CTP
//using joystick = Microsoft.Robotics.Services.Samples.Drivers.Joystick.Proxy;
//using sicklrf = Microsoft.Robotics.Services.Samples.Drivers.SickLRF.Proxy;
// TT - Changed again for V1.0
// Delete reference to Joystick and replace with GameController
//using joystick = Microsoft.Robotics.Services.Sample.Joystick.Proxy;
using game = Microsoft.Robotics.Services.GameController.Proxy;
using sicklrf = Microsoft.Robotics.Services.Sensors.SickLRF.Proxy;
using submgr = Microsoft.Dss.Services.SubscriptionManager;
using dssp = Microsoft.Dss.ServiceModel.Dssp;

using Microsoft.Robotics.PhysicalModel.Proxy;
using System.ComponentModel;

// TT - Add a webcam
// Darn! The WebCamOperations are not exposed in V1.0!
using webcam = Microsoft.Robotics.Services.WebCam;
using cam = Microsoft.Robotics.Services.WebCam.Proxy;

// TT - Added to support webcam
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;


namespace Microsoft.Robotics.Services.Dashboard
{

    /// <summary>
    /// Dashboard Service
    /// </summary>
    [DisplayName("Dashboard")]
    [Description("Service with a WinForm UI for interacting with DSS sensor and actuator services")]
    [Contract(Contract.Identifier)]
    class DashboardService : DsspServiceBase
    {
        // TT - Added for config file
        // Jul-2007 - Need to specify the directory in V1.5
        private const string InitialStateUri = ServicePaths.MountPoint + @"/Apps/QUT/Config/Dashboard.Config.xml";

        // shared access to state is protected by the interleave pattern
        // when we activate the handlers
        // TT - Added the InitialStatePartner attribute and changed
        // _state to be null
        [InitialStatePartner(Optional = true, ServiceUri = InitialStateUri)]
        StateType _state = null;

        [ServicePort("/dashboard", AllowMultipleInstances = true)]
        DashboardOperations _mainPort = new DashboardOperations();

        // TT Dec-2006 - Updated for V1.0
        [Partner("GameController", Contract = game.Contract.Identifier, CreationPolicy = PartnerCreationPolicy.UseExistingOrCreate)]
        game.GameControllerOperations _gameControllerPort = new game.GameControllerOperations();
        game.GameControllerOperations _gameControllerNotify = new game.GameControllerOperations();
        Port<Shutdown> _gameControllerShutdown = new Port<Shutdown>();

        DriveControl _driveControl;
        DriveControlEvents _eventsPort = new DriveControlEvents();

        #region Startup
        /// <summary>
        /// DashboardService Default DSS Constuctor
        /// </summary>
        /// <param name="pCreate"></param>
        public DashboardService(DsspServiceCreationPort pCreate) : base(pCreate)
        {

        }

        /// <summary>
        /// Entry Point for the Dashboard Service
        /// </summary>
        protected override void Start()
        {
            // TT - Added code to create a default State if no
            // config file exists
            if (_state == null)
            {
                _state = new StateType();
                _state.Log = false;
                _state.LogFile = "";
                _state.Machine = "";
                _state.Port = 0;
            }

            // TT - Version 2 - The options "bag"
            // This is tacky, but we need to set the default values
            // in case there is no existing config.xml file
            if (_state.Options == null)
            {
                _state.Options = new GUIOptions();
                _state.Options.DeadZoneX = 80;
                _state.Options.DeadZoneY = 80;
                _state.Options.TranslateScaleFactor = 1.0;
                _state.Options.RotateScaleFactor = 0.5;
                _state.Options.ShowLRF = false;
                _state.Options.ShowArm = false;
                _state.Options.DisplayMap = false;
                // Updated in later versions with more options
                // These values are in mm
                _state.Options.RobotWidth = 300;
                _state.Options.MaxLRFRange = 8192;
                _state.Options.DriveDistance = 300;
                // Speed is in mm/sec???
                _state.Options.MotionSpeed = 100;
                // Angle is in degrees
                _state.Options.RotateAngle = 45;
                // Camera update interval in milliseconds
                // Note that this is only required for the
                // simulated webcam because it does not provide
                // updates when you subscribe
                _state.Options.CameraInterval = 250;
            }
            if (_state.Options.CameraInterval < 100)
                _state.Options.CameraInterval = 100;

            // Handlers that need write or exclusive access to state go under
            // the exclusive group. Handlers that need read or shared access, and can be
            // concurrent to other readers, go to the concurrent group.
            // Other internal ports can be included in interleave so you can coordinate
            // intermediate computation with top level handlers.
            Activate(Arbiter.Interleave(
                new TeardownReceiverGroup
                (
                    Arbiter.Receive<DsspDefaultDrop>(false, _mainPort, DropHandler)
                ),
                new ExclusiveReceiverGroup
                (
                    Arbiter.ReceiveWithIterator<Replace>(true, _mainPort, ReplaceHandler),
                    Arbiter.ReceiveWithIterator<OnLoad>(true, _eventsPort, OnLoadHandler),
                    Arbiter.Receive<OnClosed>(true, _eventsPort, OnClosedHandler),
                    Arbiter.ReceiveWithIterator<OnChangeJoystick>(true, _eventsPort, OnChangeJoystickHandler),
                    Arbiter.Receive<OnLogSetting>(true, _eventsPort, OnLogSettingHandler),
                    // TT - Added this handler for Connection parameters
                    Arbiter.Receive<OnConnectSetting>(true, _eventsPort, OnConnectSettingHandler),
                    // TT - Added this handler for Options
                    Arbiter.Receive<OnOptionSettings>(true, _eventsPort, OnOptionSettingsHandler),
                    // TT - Added this handler for Webcam
                    Arbiter.ReceiveWithIterator<OnConnectWebCam>(true, _eventsPort, OnConnectWebCamHandler),
                    Arbiter.ReceiveWithIterator<cam.UpdateFrame>(true, _webCamNotify, CameraUpdateFrameHandler)
                ),
                new ConcurrentReceiverGroup
                (
                    Arbiter.Receive<DsspDefaultLookup>(true,_mainPort,DefaultLookupHandler),
                    Arbiter.ReceiveWithIterator<Get>(true, _mainPort, GetHandler),
                    
                    // TT Dec-2006 - Updated for V1.0
                    Arbiter.ReceiveWithIterator<game.Replace>(true, _gameControllerNotify, JoystickReplaceHandler),
                    Arbiter.ReceiveWithIterator<sicklrf.Replace>(true, _laserNotify, OnLaserReplaceHandler),
                    Arbiter.ReceiveWithIterator<OnConnect>(true, _eventsPort, OnConnectHandler),
                    
                    Arbiter.ReceiveWithIterator<drive.Update>(true, _driveNotify, OnDriveUpdateNotificationHandler),
                    Arbiter.ReceiveWithIterator<OnConnectMotor>(true, _eventsPort, OnConnectMotorHandler),
                    Arbiter.ReceiveWithIterator<OnMove>(true, _eventsPort, OnMoveHandler),
                    // TT May-2007 - Added Rotate and Translate
                    Arbiter.ReceiveWithIterator<OnRotate>(true, _eventsPort, OnRotateHandler),
                    Arbiter.ReceiveWithIterator<OnTranslate>(true, _eventsPort, OnTranslateHandler),
                    Arbiter.ReceiveWithIterator<OnEStop>(true, _eventsPort, OnEStopHandler),
                    
                    Arbiter.ReceiveWithIterator<OnStartService>(true, _eventsPort, OnStartServiceHandler),
                    Arbiter.ReceiveWithIterator<OnConnectSickLRF>(true, _eventsPort, OnConnectSickLRFHandler),
                    Arbiter.Receive<OnDisconnectSickLRF>(true, _eventsPort, OnDisconnectSickLRFHandler),

                    Arbiter.ReceiveWithIterator<OnConnectArticulatedArm>(true, _eventsPort, OnConnectArticulatedArmHandler),
                    Arbiter.ReceiveWithIterator<OnApplyJointParameters>(true, _eventsPort, OnApplyJointParametersHandler)
                )
            ));

            DirectoryInsert();

            WinFormsServicePort.Post(new RunForm(CreateForm));
        }

        #endregion

        #region WinForms interaction

        System.Windows.Forms.Form CreateForm()
        {
            // TT - Modify this call to pass the state to the Form
            return new DriveControl(_eventsPort, _state);
        }       

        #endregion

        #region DSS Handlers

        /// <summary>
        /// Get Handler returns Dashboard State.
        /// </summary>
        /// <remarks>
        /// We declare this handler as an iterator so we can easily do
        /// sequential, logically blocking receives, without the need
        /// of nested Activate calls
        /// </remarks>
        /// <param name="get"></param>
        IEnumerator<ITask> GetHandler(Get get)
        {
            get.ResponsePort.Post(_state);
            yield break;
        }

        /// <summary>
        /// Replace Handler sets Dashboard State
        /// </summary>
        /// <param name="replace"></param>
        IEnumerator<ITask> ReplaceHandler(Replace replace)
        {
            _state = replace.Body;
            replace.ResponsePort.Post(dssp.DefaultReplaceResponseType.Instance);
            yield break;
        }

        /// <summary>
        /// Drop Handler shuts down Dashboard
        /// </summary>
        /// <param name="drop"></param>
        void DropHandler(DsspDefaultDrop drop)
        {
            SpawnIterator(drop, DropIterator);
        }

        IEnumerator<ITask> DropIterator(DsspDefaultDrop drop)
        {
            LogInfo("Starting Drop");

            // Close the WebCam Form
            if (_cameraForm != null)
            {
                WebCamForm cam = _cameraForm;
                _cameraForm = null;

                WinFormsServicePort.FormInvoke(
                    delegate()
                    {
                        if (!cam.IsDisposed)
                        {
                            cam.Dispose();
                        }
                    }
                );
            }

            // Close the Dashboard Form
            if (_driveControl != null)
            {
                DriveControl drive = _driveControl;
                _driveControl = null;

                WinFormsServicePort.FormInvoke(
                    delegate()
                    {
                        if (!drive.IsDisposed)
                        {
                            drive.Dispose();
                        }
                    }
                );
            }


            if (_laserShutdown != null)
            {
                yield return PerformShutdown(ref _laserShutdown);
            }

            if (_motorShutdown != null)
            {
                yield return PerformShutdown(ref _motorShutdown);
            }

            base.DefaultDropHandler(drop);
        }

        Choice PerformShutdown(ref Port<Shutdown> port)
        {
            Shutdown shutdown = new Shutdown();
            port.Post(shutdown);
            port = null;

            return Arbiter.Choice(
                shutdown.ResultPort,
                delegate(SuccessResult success) { },
                delegate(Exception e)
                {
                    LogError(e);
                }
            );
        }

        #endregion

        #region Joystick Operations

        Choice EnumerateJoysticks()
        {
            return Arbiter.Choice(
                _gameControllerPort.GetControllers(new game.GetControllersRequest()),
                delegate(game.GetControllersResponse response)
                {
                    WinFormsServicePort.FormInvoke(
                        delegate()
                        {
                            _driveControl.ReplaceJoystickList(response.Controllers);
                        }
                    );
                },
                delegate(Fault fault)
                {
                    LogError(fault);
                }
            );
        }
        /*
        Choice EnumerateJoysticks()
        {
            return Arbiter.Choice(
                _joystickPort.GetControllers(new joystick.GetControllersRequest()),
                delegate(joystick.GetControllersResponse response)
                {
                    WinFormsServicePort.FormInvoke(
                        delegate()
                        {
                            _driveControl.ReplaceJoystickList(response.Controllers);
                        }
                    );
                },
                delegate(Fault fault)
                {
                    LogError(fault);
                }
            );
        }
        */
        // TT Dec-2006 - Updated for V1.0
        Choice SubscribeToJoystick()
        {
            return Arbiter.Choice(
                _gameControllerPort.Subscribe(_gameControllerNotify),
                delegate(SubscribeResponseType response) { },
                delegate(Fault fault) { LogError(fault); }
            );

        }

        // TT Dec-2006 - Updated for V1.0
        IEnumerator<ITask> JoystickReplaceHandler(game.Replace replace)
        {
            if (_driveControl != null)
            {
                WinFormsServicePort.FormInvoke(
                    delegate()
                    {
                        _driveControl.UpdateJoystickButtons(replace.Body.Buttons);
                        _driveControl.UpdateJoystickAxes(replace.Body.Axes);
                    }
                );
            }

            yield break;
        }

        IEnumerator<ITask> JoystickUpdateAxesHandler(game.UpdateAxes update)
        {
            if (_driveControl != null)
            {
                WinFormsServicePort.FormInvoke(
                    delegate()
                    {
                        _driveControl.UpdateJoystickAxes(update.Body);
                    }
                );
            }
            yield break;
        }

        IEnumerator<ITask> JoystickUpdateButtonsHandler(game.UpdateButtons update)
        {
            if (_driveControl != null)
            {
                WinFormsServicePort.FormInvoke(
                    delegate()
                    {
                        _driveControl.UpdateJoystickButtons(update.Body);
                    }
                );
            }
            yield break;
        }

        IEnumerator<ITask> OnChangeJoystickHandler(OnChangeJoystick onChangeJoystick)
        {
            if (onChangeJoystick.DriveControl == _driveControl)
            {
                // TT Dec-2006 - Copied from V1.0
//                yield return Arbiter.Choice(
//                    _joystickPort.ChangeController(onChangeJoystick.Joystick),
                Activate(Arbiter.Choice(
                    _gameControllerPort.ChangeController(onChangeJoystick.Joystick),
                    delegate(DefaultUpdateResponseType response)
                    {
                        LogInfo("Changed Joystick");
                    },
                    delegate(Fault f)
                    {
                        LogError(null, "Unable to change Joystick", f);
                    })
                );
            }
            // TT Dec-2006 - Copied from V1.0
            yield break;
        }

        #endregion

        #region Drive Control Event Handlers

        IEnumerator<ITask> OnLoadHandler(OnLoad onLoad)
        {
            _driveControl = onLoad.DriveControl;

            LogInfo("Loaded Form");

            yield return EnumerateJoysticks();

            yield return SubscribeToJoystick();
        }


        void OnClosedHandler(OnClosed onClosed)
        {
            if (onClosed.DriveControl == _driveControl)
            {
                LogInfo("Form Closed");

                _mainPort.Post(new DsspDefaultDrop(DropRequestType.Instance));
            }
        }

        // TT - New handler for Connection parameter setting/saving
        void OnConnectSettingHandler(OnConnectSetting onConnectSetting)
        {
            _state.Machine = onConnectSetting.Machine;
            _state.Port = onConnectSetting.Port;
            SaveState(_state);
        }

        // TT - New handler for Option setting/saving
        void OnOptionSettingsHandler(OnOptionSettings Opt)
        {
            _state.Options = Opt.Options;
            SaveState(_state);
        }


        IEnumerator<ITask> OnConnectHandler(OnConnect onConnect)
        {
            if (onConnect.DriveControl == _driveControl)
            {
                UriBuilder builder = new UriBuilder(onConnect.Service);
                builder.Scheme = new Uri(ServiceInfo.Service).Scheme;

                ds.DirectoryPort port = ServiceForwarder<ds.DirectoryPort>(builder.Uri);
                // TT Nov-2006 - Changed for new CTP
                // ds.Get get = new ds.Get(GetRequestType.Instance);
                ds.Get get = new ds.Get();

                port.Post(get);
                ServiceInfoType[] list = null;

                yield return Arbiter.Choice(get.ResponsePort,
                    delegate(ds.GetResponseType response)
                    {
                        list = response.RecordList;
                    },
                    delegate(Fault fault)
                    {
                        list = new ServiceInfoType[0];
                        LogError(fault);
                    }
                );

                WinFormsServicePort.FormInvoke(
                    delegate()
                    {
                        _driveControl.ReplaceDirectoryList(list);
                    }
                );
            }
        }

        IEnumerator<ITask> OnStartServiceHandler(OnStartService onStartService)
        {
            if (onStartService.DriveControl == _driveControl &&
                onStartService.Constructor != null)
            {
                cs.ConstructorPort port = ServiceForwarder<cs.ConstructorPort>(onStartService.Constructor);

                ServiceInfoType request = new ServiceInfoType(onStartService.Contract);
                cs.Create create = new cs.Create(request);

                port.Post(create);

                string service = null;

                yield return Arbiter.Choice(
                    create.ResponsePort,
                    delegate(CreateResponse response)
                    {
                        service = response.Service;
                    },
                    delegate(Fault fault)
                    {
                        LogError(fault);
                    }
                );


                if (service == null)
                {
                    yield break;
                }

                WinFormsServicePort.FormInvoke(
                    delegate()
                    {
                        _driveControl.StartedSickLRF();
                    }
                );
            }
        }

        #endregion

        #region Motor operations

        drive.DriveOperations _drivePort = null;
        drive.DriveOperations _driveNotify = new drive.DriveOperations();
        Port<Shutdown> _motorShutdown = null;

        IEnumerator<ITask> OnConnectMotorHandler(OnConnectMotor onConnectMotor)
        {
            if (onConnectMotor.DriveControl == _driveControl)
            {
                drive.EnableDriveRequest request = new drive.EnableDriveRequest();

                if (_drivePort != null)
                {
                    yield return Arbiter.Choice(
                        _drivePort.EnableDrive(request),
                        delegate(DefaultUpdateResponseType response) { },
                        delegate(Fault f)
                        {
                            LogError(f);
                        }
                    );

                    if (_motorShutdown != null)
                    {
                        yield return PerformShutdown(ref _motorShutdown);
                    }
                }

                _drivePort = ServiceForwarder<drive.DriveOperations>(onConnectMotor.Service);
                _motorShutdown = new Port<Shutdown>();

                request.Enable = true;

                yield return Arbiter.Choice(
                    _drivePort.EnableDrive(request),
                    delegate(DefaultUpdateResponseType response) { },
                    delegate(Fault f)
                    {
                        LogError(f);
                    }
                );

                drive.ReliableSubscribe subscribe = new drive.ReliableSubscribe(
                    new ReliableSubscribeRequestType(10)
                );
                subscribe.NotificationPort = _driveNotify;
                subscribe.NotificationShutdownPort = _motorShutdown;

                _drivePort.Post(subscribe);

                yield return Arbiter.Choice(
                    subscribe.ResponsePort,
                    delegate(SubscribeResponseType response)
                    {
                        LogInfo("Subscribed to " + onConnectMotor.Service);
                    },
                    delegate(Fault fault)
                    {
                        _motorShutdown = null;
                        LogError(fault);
                    }
                );
            }
        }

        IEnumerator<ITask> OnDriveUpdateNotificationHandler(drive.Update notification)
        {
            if (_driveControl != null)
            {
                WinFormsServicePort.FormInvoke(
                    delegate()
                    {
                        _driveControl.UpdateMotorData(notification.Body);
                    }
                );
            }

            LogObject(notification.Body);
            yield break;
        }

        // This scale factor is applied to power settings.
        // Perhaps it it so convert from mm to m/sec.
        // However, the main point is that actual power values are
        // quite small.
        double MOTOR_POWER_SCALE_FACTOR = 0.001;

        IEnumerator<ITask> OnMoveHandler(OnMove onMove)
        {
            if (onMove.DriveControl == _driveControl && _drivePort != null)
            {
                drive.SetDrivePowerRequest request = new drive.SetDrivePowerRequest();
                request.LeftWheelPower = (double)onMove.Left * MOTOR_POWER_SCALE_FACTOR;
                request.RightWheelPower = (double)onMove.Right * MOTOR_POWER_SCALE_FACTOR;

                yield return Arbiter.Choice(
                    _drivePort.SetDrivePower(request),
                    delegate(DefaultUpdateResponseType response) { },
                    delegate(Fault f)
                    {
                        LogError(f);
                    }
                );
            }
        }

        IEnumerator<ITask> OnRotateHandler(OnRotate onRotate)
        {
            if (onRotate.DriveControl == _driveControl && _drivePort != null)
            {
                drive.RotateDegreesRequest request = new drive.RotateDegreesRequest();
                request.Degrees = onRotate.Angle;
                request.Power = (double)onRotate.Power * MOTOR_POWER_SCALE_FACTOR;

                yield return Arbiter.Choice(
                    _drivePort.RotateDegrees(request),
                    delegate(DefaultUpdateResponseType response) { },
                    delegate(Fault f)
                    {
                        LogError(f);
                    }
                );
            }
        }

        IEnumerator<ITask> OnTranslateHandler(OnTranslate onTranslate)
        {
            if (onTranslate.DriveControl == _driveControl && _drivePort != null)
            {
                drive.DriveDistanceRequest request = new drive.DriveDistanceRequest();
                request.Distance = onTranslate.Distance;
                request.Power = (double)onTranslate.Power * MOTOR_POWER_SCALE_FACTOR;

                yield return Arbiter.Choice(
                    _drivePort.DriveDistance(request),
                    delegate(DefaultUpdateResponseType response) { },
                    delegate(Fault f)
                    {
                        LogError(f);
                    }
                );
            }
        }

        IEnumerator<ITask> OnEStopHandler(OnEStop onEStop)
        {
            if (onEStop.DriveControl == _driveControl && _drivePort != null)
            {
                LogInfo("Requesting EStop");
                drive.AllStopRequest request = new drive.AllStopRequest();

                yield return Arbiter.Choice(
                    _drivePort.AllStop(request),
                    delegate(DefaultUpdateResponseType response) { },
                    delegate(Fault f)
                    {
                        LogError(f);
                    }
                );
            }
        }

        #endregion

        #region Articulated Arm operations
        arm.ArticulatedArmOperations _articulatedArmPort;
        IEnumerator<ITask> OnConnectArticulatedArmHandler(OnConnectArticulatedArm onConnect)
        {
            arm.ArticulatedArmState armState = null;

            if (onConnect.DriveControl != _driveControl)
                yield break;

            _articulatedArmPort = ServiceForwarder<arm.ArticulatedArmOperations>(onConnect.Service);
            yield return Arbiter.Choice(
                _articulatedArmPort.Get(new GetRequestType()),
                delegate(arm.ArticulatedArmState state) { armState = state; },
                delegate(Fault f) { LogError(f); }
            );

            if (armState == null)
                yield break;

            WinFormsServicePort.FormInvoke(delegate()
            {
                _driveControl.ReplaceArticulatedArmJointList(armState);
            });

            yield break;
        }

        IEnumerator<ITask> OnApplyJointParametersHandler(OnApplyJointParameters onApply)
        {
            arm.SetJointTargetPoseRequest req = new arm.SetJointTargetPoseRequest();
            req.JointName = onApply.JointName;
            AxisAngle aa = new AxisAngle(
                new Vector3(1, 0, 0),
                (float)(Math.PI * 2 * ((double)onApply.Angle / 360)));

            req.TargetOrientation = aa;
                
            _articulatedArmPort.SetJointTargetPose(req);
            yield break;
        }

        #endregion

        #region Laser Range Finder operations

        sicklrf.SickLRFOperations _laserPort;
        sicklrf.SickLRFOperations _laserNotify = new sicklrf.SickLRFOperations();
        Port<Shutdown> _laserShutdown = null;

        IEnumerator<ITask> OnConnectSickLRFHandler(OnConnectSickLRF onConnectSickLRF)
        {
            if (onConnectSickLRF.DriveControl != _driveControl)
                yield break;
            _laserPort = ServiceForwarder<sicklrf.SickLRFOperations>(onConnectSickLRF.Service);
            _laserShutdown = new Port<Shutdown>();

            sicklrf.ReliableSubscribe subscribe = new sicklrf.ReliableSubscribe(
                new ReliableSubscribeRequestType(5)
            );
            subscribe.NotificationPort = _laserNotify;
            subscribe.NotificationShutdownPort = _laserShutdown;

            _laserPort.Post(subscribe);

            yield return Arbiter.Choice(
                subscribe.ResponsePort,
                delegate(SubscribeResponseType response)
                {
                    LogInfo("Subscribed to " + onConnectSickLRF.Service);
                },
                delegate(Fault fault)
                {
                    _laserShutdown = null;
                    LogError(fault);
                }
            );
        }

        IEnumerator<ITask> OnLaserReplaceHandler(sicklrf.Replace replace)
        {
            if (_driveControl != null)
            {
                WinFormsServicePort.FormInvoke(
                    delegate()
                    {
                        _driveControl.ReplaceLaserData(replace.Body);
                    }
                );
            }

            LogObject(replace.Body);
            yield break;
        }

        void OnDisconnectSickLRFHandler(OnDisconnectSickLRF onDisconnectSickLRF)
        {
            PerformShutdown(ref _laserShutdown);
        }

        #endregion

        #region Logging operations

        fs.FileStorePort _fileStorePort = null;
        object _fspLock = new object();

        void OnLogSettingHandler(OnLogSetting onLogSetting)
        {
            _state.Log = onLogSetting.Log;
            _state.LogFile = onLogSetting.File;
            // TT - Save the state on changes to Log settings
            SaveState(_state);

            if (_state.Log)
            {
                try
                {
                    Uri file = new Uri(_state.LogFile);

                    // TT Dec-2006 - Not required in V1.0
                    //fs.FileStoreConstructorPort fsConstructor = (fs.FileStoreConstructorPort)
                    //    Environment.InternalServicePortTable[Contracts.FileStoreConstructor];


                    fs.FileStoreCreate fsCreate = new fs.FileStoreCreate(file, new fs.FileStorePort());
                    // TT Dec-2006 - Update for V1.0
                    // fsConstructor.Post(fsCreate);
                    FileStoreConstructorPort.Post(fsCreate);
                    Activate(
                        Arbiter.Choice(
                            fsCreate.ResultPort,
                            delegate(fs.FileStorePort fsp)
                            {
                                LogInfo("Started Logging");
                                lock (_fspLock)
                                {
                                    _fileStorePort = fsp;
                                }
                            },
                            delegate(Exception ex)
                            {
                                WinFormsServicePort.FormInvoke(delegate()
                                    {
                                        _driveControl.ErrorLogging(ex);
                                    }
                                );

                            }
                        )
                    );
                }
                catch (Exception e)
                {
                    WinFormsServicePort.FormInvoke(delegate()
                        {
                            _driveControl.ErrorLogging(e);
                        }
                    );
                }
            }
            else if (_fileStorePort != null)
            {
                LogInfo("Stop Logging");
                lock(_fspLock)
                {
                    fs.FileStorePort fsp = _fileStorePort;

                    LogInfo("Flush Log");
                    fsp.Post(new fs.Flush());

                    Activate(
                        Arbiter.Receive(false, TimeoutPort(1000),
                            delegate(DateTime signal)
                            {
                                LogInfo("Stop Log");
                                fsp.Post(new Shutdown());
                            }
                        )
                    );
                    
                    _fileStorePort = null;
                }
            }
        }

        void LogObject(object data)
        {
            lock (_fspLock)
            {
                if (_state.Log &&
                    _fileStorePort != null)
                {
                    _fileStorePort.Post(new fs.WriteObject(data));
                }
            }
        }

        #endregion

        #region Camera

        cam.WebCamOperations _webCamPort;
        cam.WebCamOperations _webCamNotify = new cam.WebCamOperations();

        WebCamForm _cameraForm;

        // TT - New handler for connecting to WebCam
        IEnumerator<ITask> OnConnectWebCamHandler(OnConnectWebCam Opt)
        {
            //ServiceInfoType info = null;
            Fault fault = null;
            SubscribeResponseType s;
            String camera = Opt.Service;

            _webCamPort = ServiceForwarder<cam.WebCamOperations>(camera);

            //cam.Subscribe subscribe = new cam.Subscribe();
            //subscribe.NotificationPort = _webCamNotify;

            //_webCamPort.Post(subscribe);

            yield return Arbiter.Choice(
                _webCamPort.Subscribe(_webCamNotify),
//                subscribe.ResponsePort,
                delegate(SubscribeResponseType success)
                { s = success; },
                delegate(Fault f)
                {
                    fault = f;
                }
            );

            if (fault != null)
            {
                LogError(null, "Failed to subscribe to webcam", fault);
                yield break;
            }

            RunForm runForm = new RunForm(CreateWebCamForm);

            WinFormsServicePort.Post(runForm);

            yield return Arbiter.Choice(
                runForm.pResult,
                delegate(SuccessResult success) { },
                delegate(Exception e)
                {
                    fault = Fault.FromException(e);
                }
            );

            if (fault != null)
            {
                LogError(null, "Failed to Create WebCam window", fault);
                yield break;
            }
            // The following code falls over with a null pointer
            // exception inside MainPortInterleave.CombineWith.
            // Since I don't know why, I have added the message
            // to the interleave that is created at startup.
            // This is a bit tacky, but does not seem to do any harm.
            /*
            Interleave x = Arbiter.Interleave(
                    new TeardownReceiverGroup(),
                    new ExclusiveReceiverGroup(
                        Arbiter.ReceiveWithIterator<cam.UpdateFrame>(true, _webCamNotify, CameraUpdateFrameHandler)
                    ),
                    new ConcurrentReceiverGroup()
            );

            base.MainPortInterleave.CombineWith(x);
            */

            // There is a bug in the simulated webcam. It does not
            // automatically send UpdateFrame messages when you
            // subscribe. If this is a simulated camera, then set
            // up a timer to poke the webcam service and make it
            // send a frame.
            if (camera.ToLower().Contains("simul"))
            {
                Activate(
                    Arbiter.Receive(false, TimeoutPort(_state.Options.CameraInterval), CameraTimer)
                );
            }

            yield break;

        }

        // Timer for simulated cameras ONLY
        void CameraTimer(DateTime signal)
        {
            //LogInfo(LogGroups.Console, "Send UpdateFrame to webcam");
            cam.UpdateFrame request = new cam.UpdateFrame();
            _webCamPort.Post(request);
            Activate(
                Arbiter.Receive(false, TimeoutPort(_state.Options.CameraInterval), CameraTimer)
            );
        }


        // Create a form for the webcam
        Form CreateWebCamForm()
        {
            _cameraForm = new WebCamForm(_mainPort);
            return _cameraForm;
        }


        // Handler for new frames from the camera
        IEnumerator<ITask> CameraUpdateFrameHandler(cam.UpdateFrame update)
        {
            cam.QueryFrameResponse frame = null;
            Fault fault = null;

            //cam.QueryFrame query = new cam.QueryFrame();
            //_webCamPort.Post(query);

            yield return Arbiter.Choice(
                _webCamPort.QueryFrame(new cam.QueryFrameRequest()),
//                query.ResponsePort,
                delegate(cam.QueryFrameResponse success)
                {
                    frame = success;
                },
                delegate(Fault f)
                {
                    fault = f;
                }
            );

            if (fault != null)
            {
                LogError(null, "Failed to get frame from camera", fault);
                yield break;
            }

            Bitmap bmp = MakeBitmap(frame.Size.Width, frame.Size.Height, frame.Frame);
            DisplayImage(bmp);

            yield break;
        }


        Bitmap MakeBitmap(int width, int height, byte[] imageData)
        {
            // NOTE: This code implicitly assumes that the width is a multiple
            // of four bytes because Bitmaps have to be longword aligned.
            // We really should look at bmp.Stride to see if there is any padding.
            // However, the width and height come from the webcam and most cameras
            // have resolutions that are multiples of four.

            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData data = bmp.LockBits(
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb
            );

            Marshal.Copy(imageData, 0, data.Scan0, imageData.Length);

            bmp.UnlockBits(data);

            return bmp;
        }


        // Display an image in the WebCam Form
        bool DisplayImage(Bitmap bmp)
        {
            Fault fault = null;

            FormInvoke setImage = new FormInvoke(
                delegate()
                {
                    _cameraForm.CameraImage = bmp;
                }
            );

            WinFormsServicePort.Post(setImage);

            Arbiter.Choice(
                setImage.ResultPort,
                delegate(EmptyValue success) { },
                delegate(Exception e)
                {
                    fault = Fault.FromException(e);
                }
            );

            if (fault != null)
            {
                LogError(null, "Unable to set camera image on form", fault);
                return false;
            }
            else
            {
                // LogInfo("New camera frame");
                return true;
            }
        }

        #endregion

    }

}

