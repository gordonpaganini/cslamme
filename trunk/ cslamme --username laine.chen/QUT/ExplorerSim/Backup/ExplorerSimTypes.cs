//-----------------------------------------------------------------------
//  This file is part of the Explorer Simulation example 
//  Copyright (C) 2007 by Trevor Taylor, QUT.
//  This code is freely available for non-commercial use.
//
//  $File: ExplorerSimTypes.cs $ $Revision: 1 $
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;

using Microsoft.Ccr.Core;
using Microsoft.Dss.ServiceModel.Dssp;
using Microsoft.Dss.Core.Attributes;
using dssp = Microsoft.Dss.ServiceModel.Dssp;
using W3C.Soap;

using bumper = Microsoft.Robotics.Services.ContactSensor.Proxy;
using drive = Microsoft.Robotics.Services.Drive.Proxy;
using sicklrf = Microsoft.Robotics.Services.Sensors.SickLRF.Proxy;

namespace Microsoft.Robotics.Services.ExplorerSim
{

    /// <summary>
    /// DSS Contract for ExplorerSim
    /// </summary>
    static class Contract
    {
        /// <summary>
        /// The DSS Namespace for ExplorerSim
        /// </summary>
        public const string Identifier = "http://schemas.microsoft.com/robotics/2007/06/explorersim.html";
    }

    /// <summary>
    /// The ExplorerSim Operations Port
    /// </summary>
    class ExplorerSimOperations : PortSet<
        DsspDefaultLookup, 
        DsspDefaultDrop, 
        Get,
        BumperUpdate,
        BumpersUpdate,
        DriveUpdate,
        LaserRangeFinderUpdate,
        LaserRangeFinderResetUpdate,
        WatchDogUpdate
        >
    {
    }

    class BumperUpdate : Update<bumper.ContactSensor, PortSet<DefaultUpdateResponseType, Fault>>
    {
        public BumperUpdate(bumper.ContactSensor body)
            : base(body)
        { }

        public BumperUpdate()
        {}
    }

    class BumpersUpdate : Update<bumper.ContactSensorArrayState, PortSet<DefaultUpdateResponseType, Fault>>
    {
        public BumpersUpdate(bumper.ContactSensorArrayState body)
            : base(body)
        { }

        public BumpersUpdate()
        {}
    }

    class DriveUpdate : Update<drive.DriveDifferentialTwoWheelState, PortSet<DefaultUpdateResponseType, Fault>>
    {
        public DriveUpdate(drive.DriveDifferentialTwoWheelState body)
            : base(body)
        { }

        public DriveUpdate()
        {}
    }

    class LaserRangeFinderUpdate : Update<sicklrf.State, PortSet<DefaultUpdateResponseType, Fault>>
    {
        public LaserRangeFinderUpdate(sicklrf.State body)
            : base(body)
        { }

        public LaserRangeFinderUpdate()
        {}
    }

    class LaserRangeFinderResetUpdate : Update<sicklrf.ResetType, PortSet<DefaultUpdateResponseType, Fault>>
    {
        public LaserRangeFinderResetUpdate(sicklrf.ResetType body)
            : base(body)
        { }

        public LaserRangeFinderResetUpdate()
        {}
    }

    class WatchDogUpdate : Update<WatchDogUpdateRequest, PortSet<DefaultUpdateResponseType, Fault>>
    {
        public WatchDogUpdate(WatchDogUpdateRequest body)
            : base(body)
        { }

        public WatchDogUpdate()
        {}
    }

    [DataContract]
    public class WatchDogUpdateRequest
    {
        private DateTime _timeStamp;

        [DataMember]
        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }

        public WatchDogUpdateRequest(DateTime timeStamp)
        {
            TimeStamp = timeStamp;
        }

        public WatchDogUpdateRequest()
        { }
    }

    /// <summary>
    /// DSS Get Definition for ExplorerSim 
    /// </summary>
    class Get : Get<dssp.GetRequestType, PortSet<State, W3C.Soap.Fault>>
    {
    }
}
