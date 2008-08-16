using System;
using Microsoft.Dss.Core.Attributes;
using Microsoft.Dss.Core.Transforms;

[assembly: ServiceDeclaration(DssServiceDeclaration.Transform, SourceAssemblyKey = @"SimpleDashboard.Y2006.M01, Version=0.0.0.0, Culture=neutral, PublicKeyToken=13114c674b48c6d6")]


namespace Dss.Transforms.TransformSimpleDashboard
{

    public class Transforms: TransformBase
    {

        public static object Transform_Microsoft_Robotics_Services_SimpleDashboard_Proxy_StateType_Microsoft_Robotics_Services_SimpleDashboard_StateType(object transformObj)
        {
            Microsoft.Robotics.Services.SimpleDashboard.StateType target = new Microsoft.Robotics.Services.SimpleDashboard.StateType();
            Microsoft.Robotics.Services.SimpleDashboard.Proxy.StateType from = transformObj as Microsoft.Robotics.Services.SimpleDashboard.Proxy.StateType;
            target.Log = from.Log;
            target.LogFile = from.LogFile;
            target.Machine = from.Machine;
            target.Port = from.Port;
            target.Options = (from.Options == null) ? null : (Microsoft.Robotics.Services.SimpleDashboard.GUIOptions)Transform_Microsoft_Robotics_Services_SimpleDashboard_Proxy_GUIOptions_Microsoft_Robotics_Services_SimpleDashboard_GUIOptions(from.Options);
            return target;
        }


        public static object Transform_Microsoft_Robotics_Services_SimpleDashboard_StateType_Microsoft_Robotics_Services_SimpleDashboard_Proxy_StateType(object transformObj)
        {
            Microsoft.Robotics.Services.SimpleDashboard.Proxy.StateType target = new Microsoft.Robotics.Services.SimpleDashboard.Proxy.StateType();
            Microsoft.Robotics.Services.SimpleDashboard.StateType from = transformObj as Microsoft.Robotics.Services.SimpleDashboard.StateType;
            target.Log = from.Log;
            target.LogFile = from.LogFile;
            target.Machine = from.Machine;
            target.Port = from.Port;
            target.Options = (from.Options == null) ? null : (Microsoft.Robotics.Services.SimpleDashboard.Proxy.GUIOptions)Transform_Microsoft_Robotics_Services_SimpleDashboard_GUIOptions_Microsoft_Robotics_Services_SimpleDashboard_Proxy_GUIOptions(from.Options);
            return target;
        }


        public static object Transform_Microsoft_Robotics_Services_SimpleDashboard_Proxy_GUIOptions_Microsoft_Robotics_Services_SimpleDashboard_GUIOptions(object transformObj)
        {
            Microsoft.Robotics.Services.SimpleDashboard.GUIOptions target = new Microsoft.Robotics.Services.SimpleDashboard.GUIOptions();
            Microsoft.Robotics.Services.SimpleDashboard.Proxy.GUIOptions from = transformObj as Microsoft.Robotics.Services.SimpleDashboard.Proxy.GUIOptions;
            target.DeadZoneX = from.DeadZoneX;
            target.DeadZoneY = from.DeadZoneY;
            target.TranslateScaleFactor = from.TranslateScaleFactor;
            target.RotateScaleFactor = from.RotateScaleFactor;
            target.ShowLRF = from.ShowLRF;
            target.ShowArm = from.ShowArm;
            return target;
        }


        public static object Transform_Microsoft_Robotics_Services_SimpleDashboard_GUIOptions_Microsoft_Robotics_Services_SimpleDashboard_Proxy_GUIOptions(object transformObj)
        {
            Microsoft.Robotics.Services.SimpleDashboard.Proxy.GUIOptions target = new Microsoft.Robotics.Services.SimpleDashboard.Proxy.GUIOptions();
            Microsoft.Robotics.Services.SimpleDashboard.GUIOptions from = transformObj as Microsoft.Robotics.Services.SimpleDashboard.GUIOptions;
            target.DeadZoneX = from.DeadZoneX;
            target.DeadZoneY = from.DeadZoneY;
            target.TranslateScaleFactor = from.TranslateScaleFactor;
            target.RotateScaleFactor = from.RotateScaleFactor;
            target.ShowLRF = from.ShowLRF;
            target.ShowArm = from.ShowArm;
            return target;
        }

        static Transforms()
        {
            AddProxyTransform(typeof(Microsoft.Robotics.Services.SimpleDashboard.Proxy.StateType), Transform_Microsoft_Robotics_Services_SimpleDashboard_Proxy_StateType_Microsoft_Robotics_Services_SimpleDashboard_StateType);
            AddSourceTransform(typeof(Microsoft.Robotics.Services.SimpleDashboard.StateType), Transform_Microsoft_Robotics_Services_SimpleDashboard_StateType_Microsoft_Robotics_Services_SimpleDashboard_Proxy_StateType);
            AddProxyTransform(typeof(Microsoft.Robotics.Services.SimpleDashboard.Proxy.GUIOptions), Transform_Microsoft_Robotics_Services_SimpleDashboard_Proxy_GUIOptions_Microsoft_Robotics_Services_SimpleDashboard_GUIOptions);
            AddSourceTransform(typeof(Microsoft.Robotics.Services.SimpleDashboard.GUIOptions), Transform_Microsoft_Robotics_Services_SimpleDashboard_GUIOptions_Microsoft_Robotics_Services_SimpleDashboard_Proxy_GUIOptions);
        }
    }
}

