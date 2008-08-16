//-----------------------------------------------------------------------
//  This file is part of the Microsoft Robotics Studio Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//
//  $File: AssemblyInfo.cs $ $Revision: 4 $
//-----------------------------------------------------------------------

using System;
using System.Reflection;
using Microsoft.Dss.Core;
using Microsoft.Dss.Core.Attributes;

[assembly: ServiceDeclaration(DssServiceDeclaration.ServiceBehavior)]

// Fill in short description of the assembly
// TT Jun 2007 - Updated for About Box
[assembly: AssemblyTitle("Dashboard Service")]
[assembly: AssemblyProduct("Dashboard Service")]
[assembly: AssemblyVersion("1.8")]
[assembly: AssemblyCopyright("Portions written by Trevor Taylor (Jul 2007)")]
[assembly: AssemblyDescription("A modified version of the SimpleDashboard with additional features. Built for MSRS V1.5. This version is freely available.")]
[assembly: AssemblyCompany("Queensland University of Technology")]