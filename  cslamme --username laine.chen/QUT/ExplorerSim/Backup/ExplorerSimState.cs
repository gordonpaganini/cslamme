//-----------------------------------------------------------------------
//  This file is part of the Explorer Simulation example 
//  Copyright (C) 2007 by Trevor Taylor, QUT.
//  This code is freely available for non-commercial use.
//
//  $File: ExplorerSimState.cs $ $Revision: 1 $
//-----------------------------------------------------------------------

using Microsoft.Dss.Core.Attributes;

using System;
using System.Collections.Generic;

using sicklrf = Microsoft.Robotics.Services.Sensors.SickLRF.Proxy;
using drive = Microsoft.Robotics.Services.Drive.Proxy;

namespace Microsoft.Robotics.Services.ExplorerSim
{
    [DataContract]
    public class State
    {
        #region private fields
        private int _countdown;
        private LogicalState _logicalState;
        private int _newHeading;
        private int _velocity;
        private sicklrf.State _south;
        private bool _mapped;
        private DateTime _mostRecentLaser = DateTime.Now;
        private drive.DriveDifferentialTwoWheelState _driveState;

        // This is pose information extracted from the wheels of the
        // differential drive. It only works with the Simulated drive.
        private float _x, _y, _theta;
        // This flag is set when the Explorer is drawing a map using the
        // range data from the LRF
        private bool _drawMap = true;
        // This is a hack because the proxy cannot be generated with
        // user-defined enums :-(
        private MapMode _drawingMode = MapMode.Overwrite;
        // Map-related parameters
        // Map dimensions
        private double _mapWidth;
        private double _mapHeight;
        // Map resolution
        private double _mapRes;
        private double _mapMaxRange;

        // Parameters for Bayes Rule
        // These are effectively parameters of the Sensor Model
        // but because it is a laser the model is very simple
        private byte _bayesVacant;
        private byte _bayesObstacle;

        #endregion

        #region data members
        [DataMember(IsRequired=false)]
        public drive.DriveDifferentialTwoWheelState DriveState
        {
            get { return _driveState; }
            set { _driveState = value; }
        }

        [DataMember]
        public int Countdown
        {
            get { return _countdown; }
            set { _countdown = value; }
        }

        [DataMember]
        public LogicalState LogicalState
        {
            get { return _logicalState; }
            set { _logicalState = value; }
        }

        [DataMember]
        public int NewHeading
        {
            get { return _newHeading; }
            set { _newHeading = value; }
        }

        [DataMember]
        public int Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        [DataMember]
        public sicklrf.State South
        {
            get { return _south; }
            set { _south = value; }
        }

        [DataMember]
        public bool Mapped
        {
            get { return _mapped; }
            set { _mapped = value; }
        }
        
        [DataMember]
        public DateTime MostRecentLaser
        {
            get { return _mostRecentLaser; }
            set { _mostRecentLaser = value; }
        }

        [DataMember]
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        // TT - Local pose information
        [DataMember]
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        [DataMember]
        public float Theta
        {
            get { return _theta; }
            set { _theta = value; }
        }

        // TT - Flag to control map drawing
        [DataMember]
        public bool DrawMap
        {
            get { return _drawMap; }
            set { _drawMap = value; }
        }

        // The current drawing mode
        [DataMember]
        public MapMode DrawingMode
        {
            get { return _drawingMode; }
            set { _drawingMode = value; }
        }

        // Map parameters are in METERS (hence they are doubles)
        // A typical size for an office environment might be 24m x 18m.
        // NOTE: The map is scaled to fit the window when it is displayed,
        // but the aspect ratio is retained. By default the ratio is 4:3.
        // If you use values that are vastly different from this then
        // the map will appear squished in one dimension in order to
        // fit the other dimension.
        [DataMember]
        public double MapWidth
        {
            get { return _mapWidth; }
            set { _mapWidth = value; }
        }

        [DataMember]
        public double MapHeight
        {
            get { return _mapHeight; }
            set { _mapHeight = value; }
        }

        // Map resolution is the grid size in METERS.
        // The grid size should be determined based on the size of
        // the robot. As a rule of thumb, use a size that is about
        // one order of magnitude LESS than the diameter of the robot.
        // For example, if the robot is 30cm, then a reasonable grid
        // size is 5cm or 0.05 meters. You can make the grid much
        // smaller, but at the expense of increasing the computational
        // requirements. In any case, most LRFs are only accurate to
        // 1cm or 2cm so grids smaller than this do not make any sense!
        [DataMember]
        public double MapResolution
        {
            get { return _mapRes; }
            set { _mapRes = value; }
        }

        // Max Range is the maximum range of the LRF in METERS.
        // NOTE: This can actually be set to less than the real
        // max range of the LRF. That simply means that some of
        // the hits will not be used. However, as the robot moves
        // closer to the obstacles it will map them.
        // Typical values for real LRFs are 8.0, 20.0, 30.0, 80.0.
        [DataMember]
        public double MapMaxRange
        {
            get { return _mapMaxRange; }
            set { _mapMaxRange = value; }
        }

        // Parameters used with Bayes Rule when drawing the local map
        [DataMember]
        public byte BayesVacant
        {
            get { return _bayesVacant; }
            set { _bayesVacant = value; }
        }

        [DataMember]
        public byte BayesObstacle
        {
            get { return _bayesObstacle; }
            set { _bayesObstacle = value; }
        }

        #endregion

        #region internal helper accessors for meta states
        internal bool IsMapping
        {
            get
            {
                return 
                    LogicalState == LogicalState.RandomTurn ||
                    LogicalState == LogicalState.MapNorth ||
                    LogicalState == LogicalState.MapSouth ||
                    LogicalState == LogicalState.MapSurroundings;
            }
        }

        internal bool IsUnknown
        {
            get
            {
                return LogicalState == LogicalState.Unknown;
            }
        }

        internal bool IsMoving
        {
            get
            {
                return IsActive && !IsMapping;
            }
        }

        internal bool IsActive
        {
            get
            {
                return !IsUnknown;
            }
        }
        #endregion
    }

    [DataContract]
    public enum LogicalState
    {
        Unknown,
        RandomTurn,
        AdjustHeading,
        FreeForwards,
        MapSurroundings,
        MapNorth,
        MapSouth,
    }
}