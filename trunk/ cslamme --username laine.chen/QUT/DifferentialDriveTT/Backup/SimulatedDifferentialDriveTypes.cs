//-----------------------------------------------------------------------
//  This file is part of the Microsoft Robotics Studio Code Samples.
//
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//
//  $File: SimulatedDifferentialDriveTypes.cs $ $Revision: 1 $
//
// TT Jun-2007:
// Split out from the Microsoft code base
//
//-----------------------------------------------------------------------

using Microsoft.Ccr.Core;
using Microsoft.Dss.Core.Attributes;
using Microsoft.Dss.ServiceModel.Dssp;
using System;
using System.Collections.Generic;

using W3C.Soap;
using diffdrive = Microsoft.Robotics.Services.Drive.Proxy;

namespace Microsoft.Robotics.Services.Simulation.Drive
{
    
    public static class Contract
    {
        public const string Identifier = "http://schemas.microsoft.com/robotics/simulation/services/2007/06/simulateddifferentialdrivett.html";
    }

}
