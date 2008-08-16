//-----------------------------------------------------------------------
//  This file is part of the Microsoft Robotics Studio Code Samples.
//
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//
//  $File: SimulatedDifferentialDrive.cs $ $Revision: 1 $
//
// TT Jun-2007:
// Split out from the Microsoft code base so that RotateDegrees
// and DriveDistance could be implemented
// NOTE: This is a HACK! Microsoft updated the Simulated Differential
// Drive with these methods in V1.5, but the new code has some problems.
// Therefore I continue to use my code.
//
// TT Jul-2007:
// Added code to obtain the pose of the robot from the simulation
// entity so that it can be used in the Explorer for mapping. The
// pose is copied to the Wheel pose because there is no pose field
// on the Differential Drive itself. This is probably an oversight
// and I have reported it to Microsoft. Getting the pose this way
// is cheating, but it is only for teaching purposes.
//
//-----------------------------------------------------------------------

using Microsoft.Ccr.Core;
using Microsoft.Dss.Core;
using Microsoft.Dss.Core.Attributes;
using Microsoft.Dss.ServiceModel.Dssp;
using Microsoft.Dss.ServiceModel.DsspServiceBase;
using submgr = Microsoft.Dss.Services.SubscriptionManager;
using System;
using System.Collections.Generic;
using System.Xml;
using diffdrive = Microsoft.Robotics.Services.Drive.Proxy;

using simtypes = Microsoft.Robotics.Simulation;
using simengine = Microsoft.Robotics.Simulation.Engine;
using physics = Microsoft.Robotics.Simulation.Physics;
using System.ComponentModel;
using Microsoft.Dss.Core.DsspHttp;

// For Quaternion
using Microsoft.Robotics.PhysicalModel.Proxy;
//using Microsoft.Xna.Framework;

namespace Microsoft.Robotics.Services.Simulation.Drive
{
    [DisplayName("Simulated Generic Differential Drive TT")]
    [Description("Provides access to a simulated differential drive service.\n(Uses the Generic Differential Drive contract.)")]
    [AlternateContract(diffdrive.Contract.Identifier)]
    [Contract(Contract.Identifier)]
    [DssCategory(simtypes.PublishedCategories.SimulationService)]
    public class SimulatedDifferentialDriveService : Microsoft.Dss.ServiceModel.DsspServiceBase.DsspServiceBase
    {
        #region Simulation Variables
        simengine.SimulationEnginePort _simEngine;
        // TT - Need to use a different entity name to avoid conflicts
        // simengine.DifferentialDriveEntity _entity;
        simengine.TTDifferentialDriveEntity _entity;
        simengine.SimulationEnginePort _notificationTarget;
        #endregion

        [Partner("SubMgr", Contract = submgr.Contract.Identifier, CreationPolicy = PartnerCreationPolicy.CreateAlways)]
        submgr.SubscriptionManagerPort _subMgrPort = new submgr.SubscriptionManagerPort();
        string _subMgrUri = string.Empty;

        [InitialStatePartner(Optional = true)]
        private diffdrive.DriveDifferentialTwoWheelState _state = new diffdrive.DriveDifferentialTwoWheelState();

        [ServicePort("/SimulatedDifferentialDrive", AllowMultipleInstances=true)]
        private diffdrive.DriveOperations _mainPort = new diffdrive.DriveOperations();
        public SimulatedDifferentialDriveService(DsspServiceCreationPort creationPort) : 
                base(creationPort)
        {
			// Do nothing
        }
        
        protected override void Start()
        {
            // Find our simulation entity that represents the "hardware" or real-world service.
            // To hook up with simulation entities we do the following steps
            // 1) have a manifest or some other service create us, specifying a partner named SimulationEntity
            // 2) in the simulation service (us) issue a subscribe to the simulation engine looking for
            //    an instance of that simulation entity. We use the Entity.State.Name for the match so it must be
            //    exactly the same. See SimulationTutorial2 for the creation process
            // 3) Listen for a notification telling us the entity is available
            // 4) cache reference to entity and communicate with it issuing low level commands.

            _simEngine = simengine.SimulationEngine.GlobalInstancePort;
            _notificationTarget = new simengine.SimulationEnginePort();

            if (_state == null)
                CreateDefaultState();

            // PartnerType.Service is the entity instance name. 
            _simEngine.Subscribe(ServiceInfo.PartnerList, _notificationTarget);

            // dont start listening to DSSP operations, other than drop, until notification of entity
            Activate(new Interleave(
                new TeardownReceiverGroup
                (
                    Arbiter.Receive<simengine.InsertSimulationEntity>(false, _notificationTarget, InsertEntityNotificationHandlerFirstTime),
                    Arbiter.Receive<DsspDefaultDrop>(false, _mainPort, DefaultDropHandler)
                ),
                new ExclusiveReceiverGroup(),
                new ConcurrentReceiverGroup()
            ));
        }

        void CreateDefaultState()
        {
            _state = new diffdrive.DriveDifferentialTwoWheelState();
            _state.LeftWheel = new Microsoft.Robotics.Services.Motor.Proxy.WheeledMotorState();
            _state.RightWheel = new Microsoft.Robotics.Services.Motor.Proxy.WheeledMotorState();
            _state.LeftWheel.MotorState = new Microsoft.Robotics.Services.Motor.Proxy.MotorState();
            _state.RightWheel.MotorState = new Microsoft.Robotics.Services.Motor.Proxy.MotorState();
        }

        void UpdateStateFromSimulation()
        {
            if (_entity != null)
            {
                _state.TimeStamp = DateTime.Now;
                _state.LeftWheel.MotorState.CurrentPower = _entity.LeftWheel.Wheel.MotorTorque;
                _state.RightWheel.MotorState.CurrentPower = _entity.RightWheel.Wheel.MotorTorque;

                // This is a pain in the neck! You can't dive directly into the
                // fields inside the pose in the state. You have to construct an
                // entire pose and then replace it.
                Pose p = new Pose();
                Vector3 posn = new Vector3(_entity.Position.X, _entity.Position.Y, _entity.Position.Z);
                // We need to create a quaternion for the orientation
                Quaternion q = new Quaternion();

                // Rotations are about the Y axis because we are moving in 2D
                // which happens to be the X-Z plane. The Y axis is (0,1,0).
                //
                // See http://www.euclideanspace.com/maths/algebra/realNormedAlgebra/quaternions/index.htm
                // http://www.euclideanspace.com/maths/geometry/rotations/conversions/quaternionToAngle/index.htm
                //
                // The quaternion in terms of axis-angle is:
                // q = cos(a/2) + i ( x * sin(a/2)) + j (y * sin(a/2)) + k ( z * sin(a/2))
                // where:
                // a = angle of rotation,
                // x,y,z = vector representing axis of rotation.

                // Figure out the orientation angle in Radians
                Double angle = _entity.Rotation.Y * Math.PI / 180;
                // Now create the quaternion
                q.X = 0;
                q.Y = (float) Math.Sin(angle/2);
                q.Z = 0;
                q.W = (float) Math.Cos(angle/2);
                // Finally, insert the values into the pose
                p.Position = posn;
                p.Orientation = q;

                // NOTE: This is NOT correct!!! I am too lazy to figure out
                // the actual pose of the wheels. All I really wanted was to
                // set the pose for the Differential Drive, but there is no
                // pose defined in the State. Maybe in the next release???
                // So what I do is set the pose on both the wheels. This has
                // no effect on the simulation because the pose is not used.
                // I could just set one wheel, but that might be confusing.
                // The actual X and Z coordinates of the robot will be the
                // average of the coords of the two wheels in the real case,
                // so setting them the same means that you can still calculate
                // the average and it will be OK. The orientation of the wheels
                // should both be the same, or there are big problems with the robot!!!
                _state.LeftWheel.MotorState.Pose = p;
                _state.RightWheel.MotorState.Pose = p;
                
            }
        }

        /*
        public double ConvertQuaternion(Quaternion q)
        {
            AxisAngle a = new AxisAngle();
            a = Quaternion.ToAxisAngle(q);

            if (float.IsNaN(a.Angle))
                return 0;
            else if (Math.Sign(a.Axis.Y) < 0)
                return 2.0 * Math.PI - a.Angle;

            return a.Angle;
        }
        */

        void InsertEntityNotificationHandlerFirstTime(simengine.InsertSimulationEntity ins)
        {
            InsertEntityNotificationHandler(ins);

            base.Start();

            // Listen on the main port for requests and call the appropriate handler.
            MainPortInterleave.CombineWith(
                new Interleave(
                    new TeardownReceiverGroup(),
                    new ExclusiveReceiverGroup(
                        Arbiter.Receive<simengine.InsertSimulationEntity>(true, _notificationTarget, InsertEntityNotificationHandler),
                        Arbiter.Receive<simengine.DeleteSimulationEntity>(true, _notificationTarget, DeleteEntityNotificationHandler)
                    ),
                    new ConcurrentReceiverGroup()
                )
            );
        }

        void InsertEntityNotificationHandler(simengine.InsertSimulationEntity ins)
        {
            // TT - Unique entity class required
            // _entity = (simengine.DifferentialDriveEntity)ins.Body;
            _entity = (simengine.TTDifferentialDriveEntity)ins.Body;
            _entity.ServiceContract = Contract.Identifier;

            // create default state based on the physics entity
            if (_entity.ChassisShape != null)
                _state.DistanceBetweenWheels = _entity.ChassisShape.BoxState.Dimensions.X;

            _state.LeftWheel.MotorState.PowerScalingFactor = _entity.MotorTorqueScaling;
            _state.RightWheel.MotorState.PowerScalingFactor = _entity.MotorTorqueScaling;
        }

        void DeleteEntityNotificationHandler(simengine.DeleteSimulationEntity del)
        {
            _entity = null;
        }


        [ServiceHandler(ServiceHandlerBehavior.Concurrent)]
        public IEnumerator<ITask> GetHandler(HttpGet get)
        {
            UpdateStateFromSimulation();
            get.ResponsePort.Post(new HttpResponseType(_state));
            yield break;
        }

        [ServiceHandler(ServiceHandlerBehavior.Concurrent)]
        public IEnumerator<ITask> GetHandler(diffdrive.Get get)
        {
            UpdateStateFromSimulation();
            get.ResponsePort.Post(_state);
            yield break;
        }

        #region Subscribe Handling
        [ServiceHandler(ServiceHandlerBehavior.Concurrent)]
        public IEnumerator<ITask> SubscribeHandler(diffdrive.Subscribe subscribe)
        {
            Activate(Arbiter.Choice(
                SubscribeHelper(_subMgrPort, subscribe.Body, subscribe.ResponsePort),
                delegate(SuccessResult success)
                {
                    _subMgrPort.Post(new submgr.Submit(
                        subscribe.Body.Subscriber, DsspActions.UpdateRequest, _state, null));
                },
                delegate(Exception ex) { LogError(ex); }
            ));

            yield break;
        }

        [ServiceHandler(ServiceHandlerBehavior.Concurrent)]
        public IEnumerator<ITask> ReliableSubscribeHandler(diffdrive.ReliableSubscribe subscribe)
        {
            Activate(Arbiter.Choice(
                SubscribeHelper(_subMgrPort, subscribe.Body, subscribe.ResponsePort),
                delegate(SuccessResult success)
                {
                    _subMgrPort.Post(new submgr.Submit(
                        subscribe.Body.Subscriber, DsspActions.UpdateRequest, _state, null));
                },
                delegate(Exception ex) { LogError(ex); }
            ));
            yield break;
        }
        #endregion

        /// <summary>
        /// Rotate Degrees Handler
        /// </summary>
        /// <param name="rotate"></param>
        /// <returns></returns>
        [ServiceHandler(ServiceHandlerBehavior.Exclusive)]
        public IEnumerator<ITask> RotateHandler(diffdrive.RotateDegrees rotate)
        {
            // TT - Added code to support RotateDegrees
            // Don't waste time if the angle is zero
            if (rotate.Body.Degrees != 0)
                _entity.StartTurn(rotate.Body.Degrees, rotate.Body.Power);
            UpdateStateFromSimulation();
            rotate.ResponsePort.Post(new DefaultUpdateResponseType());
            yield break;
        }


        /// <summary>
        /// Drive Distance Handler
        /// </summary>
        /// <param name="driveDistance"></param>
        /// <returns></returns>
        [ServiceHandler(ServiceHandlerBehavior.Exclusive)]
        public IEnumerator<ITask> DriveDistanceHandler(diffdrive.DriveDistance driveDistance)
        {
            // TT - Added code to support DriveDistance
            // Don't waste time if the distance is zero
            if (driveDistance.Body.Distance != 0)
                _entity.StartTranslate(driveDistance.Body.Distance, driveDistance.Body.Power);
            UpdateStateFromSimulation();
            driveDistance.ResponsePort.Post(new DefaultUpdateResponseType());
            yield break;
        }


        [ServiceHandler(ServiceHandlerBehavior.Exclusive)]
        public IEnumerator<ITask> SetPowerHandler(diffdrive.SetDrivePower setPower)
        {
            if (_entity == null)
                throw new InvalidOperationException("Simulation entity not registered with service");

            // Call simulation entity method for setting wheel torque
            _entity.SetMotorTorque(
                (float)(setPower.Body.LeftWheelPower),
                (float)(setPower.Body.RightWheelPower));

            UpdateStateFromSimulation();
            setPower.ResponsePort.Post(DefaultUpdateResponseType.Instance);
            
            // send update notification for entire state
            _subMgrPort.Post(new submgr.Submit(_state, DsspActions.UpdateRequest));
            yield break;
        }

        [ServiceHandler(ServiceHandlerBehavior.Exclusive)]
        public IEnumerator<ITask> SetSpeedHandler(diffdrive.SetDriveSpeed setSpeed)
        {
            if (_entity == null)
                throw new InvalidOperationException("Simulation entity not registered with service");

            _entity.SetVelocity(
                (float)setSpeed.Body.LeftWheelSpeed, 
                (float)setSpeed.Body.RightWheelSpeed);

            UpdateStateFromSimulation();
            setSpeed.ResponsePort.Post(DefaultUpdateResponseType.Instance);

            // send update notification for entire state
            _subMgrPort.Post(new submgr.Submit(_state, DsspActions.UpdateRequest));
            yield break;
        }

        [ServiceHandler(ServiceHandlerBehavior.Concurrent)]
        public IEnumerator<ITask> EnableHandler(diffdrive.EnableDrive enable)
        {
            if (_entity == null)
                throw new InvalidOperationException("Simulation entity not registered with service");

            _state.IsEnabled = enable.Body.Enable;
            _entity.IsEnabled = _state.IsEnabled;

            UpdateStateFromSimulation();
            enable.ResponsePort.Post(DefaultUpdateResponseType.Instance);

            // send update for entire state
            _subMgrPort.Post(new submgr.Submit(_state, DsspActions.UpdateRequest));
            yield break;
        }

        [ServiceHandler(ServiceHandlerBehavior.Exclusive)]
        public IEnumerator<ITask> AllStopHandler(diffdrive.AllStop estop)
        {
            if (_entity == null)
                throw new InvalidOperationException("Simulation entity not registered with service");

            _entity.SetMotorTorque(0,0);
            _entity.SetVelocity(0);

            UpdateStateFromSimulation();
            estop.ResponsePort.Post(DefaultUpdateResponseType.Instance);

            // send update for entire state
            _subMgrPort.Post(new submgr.Submit(_state, DsspActions.UpdateRequest));
            yield break;
        }

    }
}
