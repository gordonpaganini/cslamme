//-----------------------------------------------------------------------
//  This file was part of the Microsoft Robotics Studio Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//
//  $File: DashboardTypes.cs $ $Revision: 5 $
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Microsoft.Dss.Core.Attributes;

using Microsoft.Ccr.Core;
using Microsoft.Dss.ServiceModel.Dssp;

using dssp = Microsoft.Dss.ServiceModel.Dssp;

namespace Microsoft.Robotics.Services.Dashboard
{

    /// <summary>
    /// DSS Contract for Dashboard
    /// </summary>
    static class Contract
    {
        /// <summary>
        /// The DSS Namespace for Dashboard
        /// </summary>
        public const string Identifier = "http://schemas.microsoft.com/robotics/2006/10/dashboard.html";
    }

    /// <summary>
    /// The Dashboard Operations Port
    /// </summary>
    public class DashboardOperations : PortSet<DsspDefaultLookup, DsspDefaultDrop, Get, Replace>
    {
    }

    /// <summary>
    /// DSS Get Definition for Dashboard 
    /// </summary>
    public class Get : Get<dssp.GetRequestType, PortSet<StateType, W3C.Soap.Fault>>
    {
        /// <summary>
        /// Default DSS Get Constructor
        /// </summary>
        public Get()
        {
        }

        /// <summary>
        /// DSS GetRequestType Constructor
        /// </summary>
        /// <param name="body"></param>
        public Get(dssp.GetRequestType body)
            : base(body)
        {
        }

    }

    /// <summary>
    /// DSS Replace Definition for Dashboard 
    /// </summary>
    public class Replace : Replace<StateType, PortSet<dssp.DefaultReplaceResponseType, W3C.Soap.Fault>>
    {
        /// <summary>
        /// Default DSS Get Constructor
        /// </summary>
        public Replace()
        {
        }

        /// <summary>
        /// DSS Dashboard StateType Constructor
        /// </summary>
        /// <param name="body"></param>
        public Replace(StateType body)
            : base(body)
        {
        }       
    }

}
