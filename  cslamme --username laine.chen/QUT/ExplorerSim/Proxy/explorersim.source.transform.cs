﻿using System;
using Microsoft.Dss.Core.Attributes;
using Microsoft.Dss.Core.Transforms;

#if NET_CF20
[assembly: ServiceDeclaration(DssServiceDeclaration.Transform, SourceAssemblyKey = @"cf.explorersim.y2007.m06, version=1.0.0.0, culture=neutral, publickeytoken=afde062daa7bb8cf")]
#else
[assembly: ServiceDeclaration(DssServiceDeclaration.Transform, SourceAssemblyKey = @"explorersim.y2007.m06, version=1.0.0.0, culture=neutral, publickeytoken=afde062daa7bb8cf")]
#endif
#if !URT_MINCLR
[assembly: System.Security.SecurityTransparent]
[assembly: System.Security.AllowPartiallyTrustedCallers]
#endif

namespace Dss.Transforms.TransformExplorerSim
{

    public class Transforms: TransformBase
    {

        public static object Transform_Microsoft_Robotics_Services_ExplorerSim_Proxy_State_TO_Microsoft_Robotics_Services_ExplorerSim_State(object transformFrom)
        {
            Microsoft.Robotics.Services.ExplorerSim.State target = new Microsoft.Robotics.Services.ExplorerSim.State();
            Microsoft.Robotics.Services.ExplorerSim.Proxy.State from = transformFrom as Microsoft.Robotics.Services.ExplorerSim.Proxy.State;
            target.DriveState = (from.DriveState == null) ? null : (Microsoft.Robotics.Services.Drive.Proxy.DriveDifferentialTwoWheelState)((Microsoft.Dss.Core.IDssSerializable)from.DriveState).Clone();
            target.Countdown = from.Countdown;
            target.LogicalState = (Microsoft.Robotics.Services.ExplorerSim.LogicalState)((System.Int32)from.LogicalState);
            target.NewHeading = from.NewHeading;
            target.Velocity = from.Velocity;
            target.South = (from.South == null) ? null : (Microsoft.Robotics.Services.Sensors.SickLRF.Proxy.State)((Microsoft.Dss.Core.IDssSerializable)from.South).Clone();
            target.Mapped = from.Mapped;
            target.MostRecentLaser = from.MostRecentLaser;
            target.X = from.X;
            target.Y = from.Y;
            target.Theta = from.Theta;
            target.DrawMap = from.DrawMap;
            target.DrawingMode = (Microsoft.Robotics.Services.ExplorerSim.MapMode)((System.Int32)from.DrawingMode);
            target.MapWidth = from.MapWidth;
            target.MapHeight = from.MapHeight;
            target.MapResolution = from.MapResolution;
            target.MapMaxRange = from.MapMaxRange;
            target.BayesVacant = from.BayesVacant;
            target.BayesObstacle = from.BayesObstacle;
            return target;
        }


        public static object Transform_Microsoft_Robotics_Services_ExplorerSim_State_TO_Microsoft_Robotics_Services_ExplorerSim_Proxy_State(object transformFrom)
        {
            Microsoft.Robotics.Services.ExplorerSim.Proxy.State target = new Microsoft.Robotics.Services.ExplorerSim.Proxy.State();
            Microsoft.Robotics.Services.ExplorerSim.State from = transformFrom as Microsoft.Robotics.Services.ExplorerSim.State;
            target.DriveState = (from.DriveState == null) ? null : (Microsoft.Robotics.Services.Drive.Proxy.DriveDifferentialTwoWheelState)((Microsoft.Dss.Core.IDssSerializable)from.DriveState).Clone();
            target.Countdown = from.Countdown;
            target.LogicalState = (Microsoft.Robotics.Services.ExplorerSim.Proxy.LogicalState)((System.Int32)from.LogicalState);
            target.NewHeading = from.NewHeading;
            target.Velocity = from.Velocity;
            target.South = (from.South == null) ? null : (Microsoft.Robotics.Services.Sensors.SickLRF.Proxy.State)((Microsoft.Dss.Core.IDssSerializable)from.South).Clone();
            target.Mapped = from.Mapped;
            target.MostRecentLaser = from.MostRecentLaser;
            target.X = from.X;
            target.Y = from.Y;
            target.Theta = from.Theta;
            target.DrawMap = from.DrawMap;
            target.DrawingMode = (Microsoft.Robotics.Services.ExplorerSim.Proxy.MapMode)((System.Int32)from.DrawingMode);
            target.MapWidth = from.MapWidth;
            target.MapHeight = from.MapHeight;
            target.MapResolution = from.MapResolution;
            target.MapMaxRange = from.MapMaxRange;
            target.BayesVacant = from.BayesVacant;
            target.BayesObstacle = from.BayesObstacle;
            return target;
        }


        public static object Transform_Microsoft_Robotics_Services_ExplorerSim_Proxy_WatchDogUpdateRequest_TO_Microsoft_Robotics_Services_ExplorerSim_WatchDogUpdateRequest(object transformFrom)
        {
            Microsoft.Robotics.Services.ExplorerSim.WatchDogUpdateRequest target = new Microsoft.Robotics.Services.ExplorerSim.WatchDogUpdateRequest();
            Microsoft.Robotics.Services.ExplorerSim.Proxy.WatchDogUpdateRequest from = transformFrom as Microsoft.Robotics.Services.ExplorerSim.Proxy.WatchDogUpdateRequest;
            target.TimeStamp = from.TimeStamp;
            return target;
        }


        public static object Transform_Microsoft_Robotics_Services_ExplorerSim_WatchDogUpdateRequest_TO_Microsoft_Robotics_Services_ExplorerSim_Proxy_WatchDogUpdateRequest(object transformFrom)
        {
            Microsoft.Robotics.Services.ExplorerSim.Proxy.WatchDogUpdateRequest target = new Microsoft.Robotics.Services.ExplorerSim.Proxy.WatchDogUpdateRequest();
            Microsoft.Robotics.Services.ExplorerSim.WatchDogUpdateRequest from = transformFrom as Microsoft.Robotics.Services.ExplorerSim.WatchDogUpdateRequest;
            target.TimeStamp = from.TimeStamp;
            return target;
        }


        public static object Transform_Microsoft_Robotics_Services_ExplorerSim_Proxy_LogicalState_TO_Microsoft_Robotics_Services_ExplorerSim_LogicalState(object transformFrom)
        {
            Microsoft.Robotics.Services.ExplorerSim.LogicalState target = new Microsoft.Robotics.Services.ExplorerSim.LogicalState();
            return target;
        }


        public static object Transform_Microsoft_Robotics_Services_ExplorerSim_LogicalState_TO_Microsoft_Robotics_Services_ExplorerSim_Proxy_LogicalState(object transformFrom)
        {
            Microsoft.Robotics.Services.ExplorerSim.Proxy.LogicalState target = new Microsoft.Robotics.Services.ExplorerSim.Proxy.LogicalState();
            return target;
        }


        public static object Transform_Microsoft_Robotics_Services_ExplorerSim_Proxy_MapMode_TO_Microsoft_Robotics_Services_ExplorerSim_MapMode(object transformFrom)
        {
            Microsoft.Robotics.Services.ExplorerSim.MapMode target = new Microsoft.Robotics.Services.ExplorerSim.MapMode();
            return target;
        }


        public static object Transform_Microsoft_Robotics_Services_ExplorerSim_MapMode_TO_Microsoft_Robotics_Services_ExplorerSim_Proxy_MapMode(object transformFrom)
        {
            Microsoft.Robotics.Services.ExplorerSim.Proxy.MapMode target = new Microsoft.Robotics.Services.ExplorerSim.Proxy.MapMode();
            return target;
        }

        static Transforms()
        {
            Register();
        }
        public static void Register()
        {
            AddProxyTransform(typeof(Microsoft.Robotics.Services.ExplorerSim.Proxy.State), Transform_Microsoft_Robotics_Services_ExplorerSim_Proxy_State_TO_Microsoft_Robotics_Services_ExplorerSim_State);
            AddSourceTransform(typeof(Microsoft.Robotics.Services.ExplorerSim.State), Transform_Microsoft_Robotics_Services_ExplorerSim_State_TO_Microsoft_Robotics_Services_ExplorerSim_Proxy_State);
            AddProxyTransform(typeof(Microsoft.Robotics.Services.ExplorerSim.Proxy.WatchDogUpdateRequest), Transform_Microsoft_Robotics_Services_ExplorerSim_Proxy_WatchDogUpdateRequest_TO_Microsoft_Robotics_Services_ExplorerSim_WatchDogUpdateRequest);
            AddSourceTransform(typeof(Microsoft.Robotics.Services.ExplorerSim.WatchDogUpdateRequest), Transform_Microsoft_Robotics_Services_ExplorerSim_WatchDogUpdateRequest_TO_Microsoft_Robotics_Services_ExplorerSim_Proxy_WatchDogUpdateRequest);
            AddProxyTransform(typeof(Microsoft.Robotics.Services.ExplorerSim.Proxy.LogicalState), Transform_Microsoft_Robotics_Services_ExplorerSim_Proxy_LogicalState_TO_Microsoft_Robotics_Services_ExplorerSim_LogicalState);
            AddSourceTransform(typeof(Microsoft.Robotics.Services.ExplorerSim.LogicalState), Transform_Microsoft_Robotics_Services_ExplorerSim_LogicalState_TO_Microsoft_Robotics_Services_ExplorerSim_Proxy_LogicalState);
            AddProxyTransform(typeof(Microsoft.Robotics.Services.ExplorerSim.Proxy.MapMode), Transform_Microsoft_Robotics_Services_ExplorerSim_Proxy_MapMode_TO_Microsoft_Robotics_Services_ExplorerSim_MapMode);
            AddSourceTransform(typeof(Microsoft.Robotics.Services.ExplorerSim.MapMode), Transform_Microsoft_Robotics_Services_ExplorerSim_MapMode_TO_Microsoft_Robotics_Services_ExplorerSim_Proxy_MapMode);
        }
    }
}

