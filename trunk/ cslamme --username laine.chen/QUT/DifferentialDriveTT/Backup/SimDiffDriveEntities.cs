//-----------------------------------------------------------------------
//  This file was part of the Microsoft Robotics Studio Code Samples.
//
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//
//  $File: SimDiffDriveEntities.cs $ $Revision: 1 $
//
// TT May-2007:
// Split out of Entities.cs so that the Differential Drive could be
// changed to support RotateDegrees and DriveDistance.
// Needed to add reference to Microsoft.Xna.Framework.
// Changed the names of the classes so they would not conflict with
// those already defined in Entities.cs.
//
// NOTE: This Solution is a replacement for the existing Simulated
// Differential Drive. It has been split off as a new entity to
// avoid conflicts. However, it is basically the same code.
// Unfortunately, the design of the Simulator means that many of the
// entities are built-in and cannot be changed. I believe this is a
// poor design and that the entity code belongs with the corresponding
// service, like it is here. This makes it easier to separate changes.
// This file also contains definitions for the Pioneer3DX and LegoNXT
// robots because they need to use the new Differential Drive entity.
//
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using xna = Microsoft.Xna.Framework;
using xnagrfx = Microsoft.Xna.Framework.Graphics;
using xnaprof = Microsoft.Robotics.Simulation.MeshLoader;
using Microsoft.Dss.Core.Attributes;
using Microsoft.Dss.Core;
using Microsoft.Ccr.Core;
using Microsoft.Robotics.Simulation.Physics;
using Microsoft.Robotics.PhysicalModel;

using System.IO;
// TT - Required for Object Editing
using System.Drawing.Imaging;
using System.Drawing;
//using System.Windows.Forms;


namespace Microsoft.Robotics.Simulation.Engine
{

    #region Robot platforms
    /// <summary>
    /// Models a differential drive motor base with two active wheels and one caster
    /// </summary>
    [DataContract]
    [CLSCompliant(true)]
        // TT Jun-2007 - This will not compile because GenericObjectEditor
        // is not accessible due to its protection level.
        // In any case, it does not affect the operation of the entity,
        // so we can simple ignore it.
    [EditorAttribute(typeof(GenericObjectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        // TT - Notice the new name for the entity so it does not clash
        // with the existing DifferentialDriveEntity
    [Category("DifferentialDrive")]
    [BrowsableAttribute(false)] // prevent from being displayed in NewEntity dialog
    public class TTDifferentialDriveEntity : VisualEntity
    {
        #region State
        /// <summary>
        /// Chassis mass in kilograms
        /// </summary>
        public float MASS;

        // the default settings are approximating a Pioneer 3-DX activMedia robot
        /// <summary>
        /// Chassis dimensions
        /// </summary>
        protected Vector3 CHASSIS_DIMENSIONS;
        /// <summary>
        /// Left front wheel position
        /// </summary>
        protected Vector3 LEFT_FRONT_WHEEL_POSITION;
        /// <summary>
        /// Right front wheel position
        /// </summary>
        protected Vector3 RIGHT_FRONT_WHEEL_POSITION;
        /// <summary>
        /// Caster wheel position
        /// </summary>
        protected Vector3 CASTER_WHEEL_POSITION;

        /// <summary>
        /// Distance from ground of chassis
        /// </summary>
        protected float CHASSIS_CLEARANCE;
        /// <summary>
        /// Mass of front wheels
        /// </summary>
        protected float FRONT_WHEEL_MASS;
        /// <summary>
        /// Radius of front wheels
        /// </summary>
        protected float FRONT_WHEEL_RADIUS;
        /// <summary>
        /// Caster wheel radius
        /// </summary>
        protected float CASTER_WHEEL_RADIUS; 
        /// <summary>
        /// Front wheels width
        /// </summary>
        protected float FRONT_WHEEL_WIDTH; 
        /// <summary>
        /// Caster wheel width
        /// </summary>
        protected float CASTER_WHEEL_WIDTH; 
        /// <summary>
        /// distance of the axle from the center of robot
        /// </summary>
        protected float FRONT_AXLE_DEPTH_OFFSET; 

        string _wheelMesh;

        /// <summary>
        /// Mesh file for front wheels
        /// </summary>
        public string WheelMesh
        {
            get { return _wheelMesh; }
            set { _wheelMesh = value; }
        }

        bool _isEnabled;

        /// <summary>
        /// True if drive mechanism is enabled
        /// </summary>
        [DataMember]
        [Description("True if the drive mechanism is enabled.")]
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; }
        }

        float _motorTorqueScaling;

        /// <summary>
        /// Scaling factor to apply to motor torque requests
        /// </summary>
        [DataMember]
        [Description("Scaling factor to apply to motor torgue requests.")]
        public float MotorTorqueScaling
        {
            get { return _motorTorqueScaling; }
            set { _motorTorqueScaling = value; }
        }

        WheelEntity _rightWheel;

        /// <summary>
        /// Right wheel child entity
        /// </summary>
        [DataMember]
        [Description("Right wheel child entity.")]
        public WheelEntity RightWheel
        {
            get { return _rightWheel; }
            set { _rightWheel = value; }
        }
        WheelEntity _leftWheel;

        /// <summary>
        /// Left wheel child entity
        /// </summary>
        [DataMember]
        [Description("Left wheel child entity.")]
        public WheelEntity LeftWheel
        {
            get { return _leftWheel; }
            set { _leftWheel = value; }
        }

        BoxShape _chassisShape;

        /// <summary>
        /// Chassis physics shapes
        /// </summary>
        [DataMember]
        [Description("Chassis physics shapes.")]
        public BoxShape ChassisShape
        {
            get { return _chassisShape; }
            set { _chassisShape = value; }
        }

        SphereShape _casterWheelShape;
        /// <summary>
        /// Caster wheel physics shape
        /// </summary>
        [DataMember]
        [Description("Caster wheel physics shape.")]
        public SphereShape CasterWheelShape
        {
            get { return _casterWheelShape; }
            set { _casterWheelShape = value; }
        }

        /////////////////////////////////////////////////////////////
        // TT May-2007
        // DefaultPower is used when the power is specified
        // as zero because otherwise nothing would happen!
        // Note that the value here is quite critical for the Explorer
        // example service because it does not set the power.
        // The DefaultPower should be something small.
        double DefaultPower = 0.1;

        // TT May-2007
        // Data for performing rotations
        bool IsRotating;
        double TurnStartDegrees;
        double TurnAngle;

        // TT May-2007
        // Data for performing translations
        bool IsTranslating;
        double TranslateStartX;
        double TranslateStartZ;
        double TranslateDistanceSquared;

        /////////////////////////////////////////////////////////////

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public TTDifferentialDriveEntity() { }  // TT - Notice the name change

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="device"></param>
        /// <param name="physicsEngine"></param>
        public override void Initialize(xnagrfx.GraphicsDevice device, PhysicsEngine physicsEngine)
        {
            // TT May-2007
            // Could be initialized in the declarations above,
            // but here it is anyway
            IsRotating = false;
            IsTranslating = false;
            TurnStartDegrees = 0;
            TranslateStartX = 0;
            TranslateStartZ = 0;
            TranslateDistanceSquared = 0;

            try
            {
                InitError = string.Empty;
                ProgrammaticallyBuildModel(device, physicsEngine);
                _leftWheel.Parent = this;
                _rightWheel.Parent = this;
                _leftWheel.Initialize(device, physicsEngine);
                _rightWheel.Initialize(device, PhysicsEngine);
                // TT May-2007
                // Set the flag so that the pose is always updated
                //this.Flags |= VisualEntityProperties.DoCompletePhysicsShapeUpdate;
                base.Initialize(device, physicsEngine);
            }
            catch (Exception ex)
            {
                // clean up
                if (PhysicsEntity != null)
                    PhysicsEngine.DeleteEntity(PhysicsEntity);

                HasBeenInitialized = false;
                InitError = ex.ToString();
            }
        }

        /// <summary>
        /// Builds the simulated robotic entity using local fields for positionm size, orientation
        /// </summary>
        /// <param name="device"></param>
        /// <param name="physicsEngine"></param>
        public void ProgrammaticallyBuildModel(xnagrfx.GraphicsDevice device, PhysicsEngine physicsEngine)
        {
            if (_casterWheelShape == null)
            {
                // add caster wheel as a basic sphere shape
                CasterWheelShape = new SphereShape(
                    new SphereShapeProperties("rear wheel", 0.001f,
                    new Pose(CASTER_WHEEL_POSITION), CASTER_WHEEL_RADIUS));
                CasterWheelShape.State.Name = "Caster wheel";

                // a fixed caster wheel has high friction when moving laterely, but low friction when it moves along the
                // body axis its aligned with. We use anisotropic friction to model this
                CasterWheelShape.State.Material = new MaterialProperties("small friction with anisotropy", 0.5f, 0.5f, 1);
                CasterWheelShape.State.Material.Advanced = new MaterialAdvancedProperties();
                CasterWheelShape.State.Material.Advanced.AnisotropicDynamicFriction = 0.3f;
                CasterWheelShape.State.Material.Advanced.AnisotropicStaticFriction = 0.4f;
                CasterWheelShape.State.Material.Advanced.AnisotropyDirection = new Vector3(0, 0, 1);
            }

            base.State.PhysicsPrimitives.Add(_casterWheelShape);

            if (_chassisShape != null)
                base.State.PhysicsPrimitives.Add(_chassisShape);
            
            base.CreateAndInsertPhysicsEntity(physicsEngine);
            // increase physics fidelity
            base.PhysicsEntity.SolverIterationCount = 64;

            // if we were created from xml the wheel entities would already be instantiated
            if (_leftWheel != null && _rightWheel != null)
                return;

            // front left wheel
            WheelShapeProperties w = new WheelShapeProperties("front left wheel", FRONT_WHEEL_MASS, FRONT_WHEEL_RADIUS);
            // Set this flag on both wheels if you want to use axle speed instead of torque
            w.Flags |= WheelShapeBehavior.OverrideAxleSpeed;
            w.InnerRadius = 0.7f * w.Radius;
            w.LocalPose = new Pose(LEFT_FRONT_WHEEL_POSITION);
            _leftWheel = new WheelEntity(w);
            _leftWheel.State.Name = State.Name + ":" + "Left wheel";
            _leftWheel.State.Assets.Mesh = _wheelMesh;
            _leftWheel.Parent = this;
            //_leftWheel.WheelShape.WheelState.Material = new MaterialProperties("wheel", 0.5f, 0f, 1f);
            // wheels must have zero friction material.The wheel model will do friction differently

            // front right wheel
            w = new WheelShapeProperties("front right wheel", FRONT_WHEEL_MASS, FRONT_WHEEL_RADIUS);
            w.Flags |= WheelShapeBehavior.OverrideAxleSpeed;
            w.InnerRadius = 0.7f * w.Radius;
            w.LocalPose = new Pose(RIGHT_FRONT_WHEEL_POSITION);
            _rightWheel = new WheelEntity(w);
            _rightWheel.State.Name = State.Name + ":" + "Right wheel";
            _rightWheel.State.Assets.Mesh = _wheelMesh;
            _rightWheel.Parent = this;
            //_rightWheel.WheelShape.WheelState.Material = _leftWheel.WheelShape.WheelState.Material;
        }

        /*
        // TT - Not present in V1.5
        /// <summary>
        /// Add entity to our list of children
        /// </summary>
        /// <param name="child">Child entity</param>
        public override void InsertEntity(VisualEntity child)
        {
            Children.Add(child);
            child.Parent = this;
        }
         */

        /// <summary>
        /// Special dispose to handle embedded entities 
        /// </summary>
        public override void Dispose()
        {
            if (_leftWheel != null)
                _leftWheel.Dispose();

            if (_rightWheel != null)
                _rightWheel.Dispose();

            base.Dispose();
        }

        /// <summary>
        /// Updates pose for our entity. We override default implementation
        /// since we control our own rendering when no file mesh is supplied, which means
        /// we dont need world transform updates
        /// </summary>
        /// <param name="update"></param>
        public override void Update(FrameUpdate update)
        {
            float left = _leftWheel.Wheel.AxleSpeed + _leftTargetVelocity;
            float right = _rightWheel.Wheel.AxleSpeed + _rightTargetVelocity;

            if (Math.Abs(left) > 0.1)
            {
                if (left > 0)
                {
                    _leftWheel.Wheel.AxleSpeed -= SPEED_DELTA;
                }
                else
                {
                    _leftWheel.Wheel.AxleSpeed += SPEED_DELTA;
                }
            }

            if (Math.Abs(right) > 0.1)
            {
                if (right > 0)
                {
                    _rightWheel.Wheel.AxleSpeed -= SPEED_DELTA;
                }
                else
                {
                    _rightWheel.Wheel.AxleSpeed += SPEED_DELTA;
                }
            }

            // update state for us and all the shapes that make up the rigid body
            PhysicsEntity.UpdateState(true);

            /////////////////////////////////////////////////////////////
            // TT May-2007
            // Handle RotateDegrees
            if (IsRotating)
            {
                double current;
                double diff;
                // Get the current heading
                current = this.Rotation.Y;
                // This is tricky because the angle wraps around
                // so it is always in the range 0-360.
                // This is probably unnecessary because the Simulator
                // does it for us, but just to be sure ...
                while (current > 360)
                    current -= 360;
                while (current < 0)
                    current += 360;

                // Figure out how far we have turned
                // NOTE: You cannot simply compare the current heading
                // with a target angle because the simulation moves in
                // steps and might skip over the target angle.
                diff = current - TurnStartDegrees;
                if (TurnAngle > 0)
                {
                    if (diff < 0)
                        diff += 360;
                    if (diff >= TurnAngle)
                        IsRotating = false;
                }
                else
                {
                    if (diff > 0)
                        diff -= 360;
                    if (diff <= TurnAngle)
                        IsRotating = false;
                }
                if (!IsRotating)
                {
                    SetMotorTorque(0, 0);
                    SetVelocity(0);     // This is overkill, but AllStop does it!
                    // This is cheating! Eliminates inertia
                    _rightWheel.Wheel.AxleSpeed = 0;
                    _leftWheel.Wheel.AxleSpeed = 0;
                    IsRotating = false;
                }
            }

            // TT May-2007
            // Handle DriveDistance
            if (IsTranslating)
            {
                double dist;
                // Calculate the SQUARED distance so far
                // This avoids taking a square root every time
                dist = (this.Position.X - TranslateStartX) * (this.Position.X - TranslateStartX) +
                       (this.Position.Z - TranslateStartZ) * (this.Position.Z - TranslateStartZ);
                // Check if we have reached the end of the travel
                if (dist >= TranslateDistanceSquared)
                {
                    SetMotorTorque(0, 0);
                    SetVelocity(0);     // This is overkill, but AllStop does it!
                    // This is cheating! Eliminates inertia
                    _rightWheel.Wheel.AxleSpeed = 0;
                    _leftWheel.Wheel.AxleSpeed = 0;
                    IsTranslating = false;
                }
            }

            /////////////////////////////////////////////////////////////

            // update entities in fields
            _leftWheel.Update(update);
            _rightWheel.Update(update);
            
            // sim engine will update children

            if (State.Assets.Mesh != null)
            {
                base.Update(update);
            }
        }

        /*
        // TT - Changed in V1.5 with different parameters
        /// <summary>
        /// Render entities stored as fields
        /// </summary>
        /// <param name="device"></param>
        /// <param name="transforms"></param>
        /// <param name="currentCamera"></param>
        public override void Render(xnagrfx.GraphicsDevice device, MatrixTransforms transforms,
            Microsoft.Robotics.Simulation.Engine.CameraEntity currentCamera)
        {
            _leftWheel.Render(device, transforms, currentCamera);
            _rightWheel.Render(device, transforms, currentCamera);
            base.Render(device, transforms, currentCamera);
        }
        */

        /// <summary>
        /// Render entities stored as fields
        /// </summary>
        public override void Render(RenderMode renderMode, MatrixTransforms transforms, CameraEntity currentCamera)
        {
            _leftWheel.Render(renderMode, transforms, currentCamera);
            _rightWheel.Render(renderMode, transforms, currentCamera);

            base.Render(renderMode, transforms, currentCamera);
        }


        #region Motor Base Control
        const float SPEED_DELTA = 0.5f;

        /// <summary>
        /// Current heading, in radians, of robot base
        /// </summary>
        public float CurrentHeading
        {
            get
            {
                // return the axis angle of the quaternion
                xna.Quaternion xq = TypeConversion.ToXNA(State.Pose.Orientation);
                return (float)(2 * Math.Acos(xq.W));
            }
        }

        /// <summary>
        /// Sets motor torque on the active wheels
        /// </summary>
        /// <param name="leftWheel"></param>
        /// <param name="rightWheel"></param>
        public void SetMotorTorque(float leftWheel, float rightWheel)
        {
            SetAxleVelocity(leftWheel * _motorTorqueScaling, rightWheel * _motorTorqueScaling);
        }

        float _leftTargetVelocity;
        float _rightTargetVelocity;

        /// <summary>
        /// Sets angular velocity (radians/sec) on both wheels
        /// </summary>
        /// <param name="value"></param>
        public void SetVelocity(float value)
        {
            SetVelocity(value, value);
        }

        /// <summary>
        /// Sets angular velocity on the wheels
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public void SetVelocity(float left, float right)
        {
            if (_leftWheel == null || _rightWheel == null)
                return;

            left = ValidateWheelVelocity(left);
            right = ValidateWheelVelocity(right);

            // v is in m/sec - convert to an axle speed
            //  2Pi(V/2PiR) = V/R
            SetAxleVelocity(left / _leftWheel.Wheel.State.Radius,
                right / _rightWheel.Wheel.State.Radius);
        }

        // This routine actually sets the speed of the robot
        private void SetAxleVelocity(float left, float right)
        {
            _leftTargetVelocity = left;
            _rightTargetVelocity = right;
            // TT May-2007
            // IMPORTANT NOTE
            // Clear the flags for the prescribed motions.
            // This is done here so that any method that sets the
            // speed will override an existing motion.
            // It relies on the fact that all other methods of setting
            // the wheel speed eventually come here.
            IsRotating = false;
            IsTranslating = false;
        }

        const float MAX_VELOCITY = 20.0f;
        const float MIN_VELOCITY = -MAX_VELOCITY;

        float ValidateWheelVelocity(float value)
        {
            if (value > MAX_VELOCITY)
                return MAX_VELOCITY;
            if (value < MIN_VELOCITY)
                return MIN_VELOCITY;

            return value;
        }

        /////////////////////////////////////////////////////////////
        // TT May-2007
        // Initiate a turn for a specified angle and at a given power.
        // This supports the RotateDegrees method for the drive.
        public void StartTurn(double angle, double power)
        {
            float pow;
            // Do nothing if angle is zero because we are already there!
            if (angle == 0)
                return;

            // Remember the angle
            // We could add a random factor here to simulate
            // real world errors
            TurnAngle = angle;

            // What if the power is zero?
            // Set it to the default power setting or nothing will happen!
            // NOTE: There is a scale factor applied to power settings
            // so the DefaultPower is quite small
            if (power <= 0)
                pow = (float) DefaultPower;
            else
                pow = (float) power;

            // Get the starting angle and normalise it to 0-360
            TurnStartDegrees = this.Rotation.Y;
            while (TurnStartDegrees > 360)
                TurnStartDegrees -= 360;
            while (TurnStartDegrees < 0)
                TurnStartDegrees += 360;

            // Calculate the ending angle
            //TurnEndDegrees = TurnStartDegrees + angle;
            // Normalise the angle to +/-180
            // NOTE: This means that the maximum turn is 360 degrees
            // in theory, but in practice this will not work because
            // the robot will stop immediately!
            //while (TurnEndDegrees > 180)
            //    TurnEndDegrees -= 360;
            //while (TurnEndDegrees < -180)
            //    TurnEndDegrees += 360;
            if (angle > 0)
                SetMotorTorque(-pow, pow);
            else
                SetMotorTorque(pow, -pow);

            // NOTE: Set this AFTER setting the motor speeds!
            // This is necessary because changing the speeds
            // causes the motion flags to be reset
            IsRotating = true;
        }

        // TT May-2007
        // Initiate a forward/backward move for a specified distance
        // and at a given power.
        // Required to support DriveDistance method for the drive.
        public void StartTranslate(double distance, double power)
        {
            float pow;
            // Do nothing if distance is zero because we are already there!
            if (distance == 0)
                return;

            // Make sure that power is not zero or the robot won't move
            // NOTE: There is a scale factor applied to power settings
            // so the DefaultPower is quite small
            if (power <= 0)
                pow = (float)DefaultPower;
            else
                pow = (float)power;

            // Get the starting position
            TranslateStartX = this.Position.X;
            TranslateStartZ = this.Position.Z;

            // Remember the distance SQUARED
            // Avoids taking a square root later and also handles
            // negative distances!
            // We could add a random factor here to simulate real
            // world errors
            TranslateDistanceSquared = distance * distance;

            // Start the motors
            // Note that the translation can be forwards OR backwards
            if (distance > 0)
                SetMotorTorque(pow, pow);
            else
                SetMotorTorque(-pow, -pow);

            // NOTE: Set this flag AFTER setting the motor speeds
            // because setting the speeds resets the motion flags
            IsTranslating = true;
        }
        /////////////////////////////////////////////////////////////

        #endregion
    }

    /// <summary>
    /// MobileRobots Pioneer3DX implementation of the differential entity. It just specifies different physical properties in
    /// its custom constructor, otherwise uses the base class as is.
    /// </summary>
    [DataContract]
    [CLSCompliant(true)]
    // TT Jun 2007 - A new entity is required because it uses a new
    // version of the Simulated Differential Drive
    public class TTPioneer3DX : TTDifferentialDriveEntity
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public TTPioneer3DX() { }       // TT - Flow-on effect of name change

        /// <summary>
        /// Initialization constructor
        /// </summary>
        /// <param name="initialPos"></param>
        public TTPioneer3DX(Vector3 initialPos)
        {
            MASS = 9;
            // the default settings are approximating a Pioneer 3-DX activMedia robot
            CHASSIS_DIMENSIONS = new Vector3(0.393f, 0.18f, 0.40f);
            CHASSIS_CLEARANCE = 0.05f;
            FRONT_WHEEL_RADIUS = 0.08f;
            CASTER_WHEEL_RADIUS = 0.025f; // = CHASSIS_CLEARANCE / 2; // to keep things simple we make caster a bit bigger
            FRONT_WHEEL_WIDTH = 4.74f;  //not used
            CASTER_WHEEL_WIDTH = 0.02f; //not used
            FRONT_AXLE_DEPTH_OFFSET = -0.05f; // distance of the axle from the center of robot

            base.State.Name = "MotorBaseWithThreeWheels";
            base.State.MassDensity.Mass = MASS;
            base.State.Pose.Position = initialPos;

            // reference point for all shapes is the projection of
            // the center of mass onto the ground plane 
            // (basically the spot under the center of mass, at Y = 0, or ground level)

            // chassis position
            BoxShapeProperties motorBaseDesc = new BoxShapeProperties("chassis", MASS,
                new Pose(new Vector3(
                0, // Chassis center is also the robot center, so use zero for the X axis offset
                CHASSIS_CLEARANCE + CHASSIS_DIMENSIONS.Y / 2, // chassis is off the ground and its center is DIM.Y/2 above the clearance
                0)), // no offset in the z/depth axis, since again, its center is the robot center
                CHASSIS_DIMENSIONS);

            motorBaseDesc.Material = new MaterialProperties("high friction", 0.0f, 1.0f, 20.0f);
            motorBaseDesc.Name = "Chassis";
            ChassisShape = new BoxShape(motorBaseDesc);

            // rear wheel is also called the caster
            CASTER_WHEEL_POSITION = new Vector3(0, // center of chassis
                CASTER_WHEEL_RADIUS, // distance from ground
                CHASSIS_DIMENSIONS.Z / 2 - CASTER_WHEEL_RADIUS); // all the way at the back of the robot

            // NOTE: right/left is from the perspective of the robot, looking forward

            FRONT_WHEEL_MASS = 0.10f;

            RIGHT_FRONT_WHEEL_POSITION = new Vector3(
                CHASSIS_DIMENSIONS.X / 2 + 0.01f,// left of center
                FRONT_WHEEL_RADIUS,// distance from ground of axle
                FRONT_AXLE_DEPTH_OFFSET); // distance from center, on the z-axis

            LEFT_FRONT_WHEEL_POSITION = new Vector3(
                -CHASSIS_DIMENSIONS.X / 2 - 0.01f,// right of center
                FRONT_WHEEL_RADIUS,// distance from ground of axle
                FRONT_AXLE_DEPTH_OFFSET); // distance from center, on the z-axis

            MotorTorqueScaling = 20;
        }
    }

    /// <summary>
    /// Lego NXT variant of the motor base entity. It just specifies different physical properties in
    /// its custom constructor, otherwise uses the base class as is.
    /// </summary>
    [DataContract]
    [CLSCompliant(true)]
    // TT Jun-2007 - The Lego NXT entity was also updated, although
    // this probably does not match the real robot now
    public class TTLegoNXTTribot : TTDifferentialDriveEntity
    {
        /// <summary>
        /// Default constructor, used for creating the entity from an XML description
        /// </summary>
        public TTLegoNXTTribot() { }

        /// <summary>
        /// Custom constructor for building model from hardcoded values. Used to create entity programmatically
        /// </summary>
        /// <param name="initialPos"></param>
        public TTLegoNXTTribot(Vector3 initialPos)
        {
            MASS = 0.5f; //kg
            // the default settings approximate the Lego NXT baseline chassis
            CHASSIS_DIMENSIONS = new Vector3(0.105f, //meters wide
                                             0.12f,  //meters high
                                             0.14f); //meters long
            FRONT_WHEEL_MASS = 0.01f;
            CHASSIS_CLEARANCE = 0.015f;
            FRONT_WHEEL_RADIUS = 0.025f;
            CASTER_WHEEL_RADIUS = 0.0125f;
            FRONT_WHEEL_WIDTH = 0.028f;
            CASTER_WHEEL_WIDTH = 0.008f; //not currently used, but dim is accurate
            FRONT_AXLE_DEPTH_OFFSET = -0.005f; // distance of the axle from the center of robot

            base.State.Name = "LegoNXTTribot";
            base.State.MassDensity.Mass = MASS;
            base.State.Pose.Position = initialPos;

            // reference point for all shapes is the projection of
            // the center of mass onto the ground plane 
            // (basically the spot under the center of mass, at Y = 0, or ground level)

            // NOTE: right/left is from the perspective of the robot, looking forward
            // NOTE: X = width of robot (right to left), Y = height, Z = length

            // chassis position
            BoxShapeProperties motorBaseDesc = new BoxShapeProperties("NXT brick", MASS,
                new Pose(new Vector3(
                0, // Chassis center is also the robot center, so use zero for the X axis offset
                CHASSIS_CLEARANCE + CHASSIS_DIMENSIONS.Y / 2, // chassis is off the ground and its center is DIM.Y/2 above the clearance
                0.025f)), // minor offset in the z/depth axis
                CHASSIS_DIMENSIONS);

            motorBaseDesc.Material = new MaterialProperties("high friction", 0.0f, 1.0f, 20.0f);
            motorBaseDesc.Name = "Chassis";
            ChassisShape = new BoxShape(motorBaseDesc);

            // rear wheel is also called the caster
            CASTER_WHEEL_POSITION = new Vector3(0, // center of chassis
                CASTER_WHEEL_RADIUS, // distance from ground
                CHASSIS_DIMENSIONS.Z / 2 + 0.055f); // all the way at the back of the robot

            // Deleted the extra offset of  +- FRONT_WHEEL_WIDTH / 2
            RIGHT_FRONT_WHEEL_POSITION = new Vector3(
                +CHASSIS_DIMENSIONS.X / 2,// left of center
                FRONT_WHEEL_RADIUS,// distance from ground of axle
                FRONT_AXLE_DEPTH_OFFSET); // distance from center, on the z-axis

            LEFT_FRONT_WHEEL_POSITION = new Vector3(
                -CHASSIS_DIMENSIONS.X / 2,// right of center
                FRONT_WHEEL_RADIUS,// distance from ground of axle
                FRONT_AXLE_DEPTH_OFFSET); // distance from center, on the z-axis

            MotorTorqueScaling = 30;
        }
    }

    #endregion

}