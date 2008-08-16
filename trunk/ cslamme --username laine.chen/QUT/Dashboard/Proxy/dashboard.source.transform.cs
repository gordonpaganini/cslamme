using System;
using Microsoft.Dss.Core.Attributes;
using Microsoft.Dss.Core.Transforms;

#if NET_CF20
[assembly: ServiceDeclaration(DssServiceDeclaration.Transform, SourceAssemblyKey = @"cf.dashboard.y2006.m10, version=1.8.0.0, culture=neutral, publickeytoken=afde062daa7bb8cf")]
#else
[assembly: ServiceDeclaration(DssServiceDeclaration.Transform, SourceAssemblyKey = @"dashboard.y2006.m10, version=1.8.0.0, culture=neutral, publickeytoken=afde062daa7bb8cf")]
#endif
#if !URT_MINCLR
[assembly: System.Security.SecurityTransparent]
[assembly: System.Security.AllowPartiallyTrustedCallers]
#endif

namespace Dss.Transforms.TransformDashboard
{

    public class Transforms: TransformBase
    {

        public static object Transform_Microsoft_Robotics_Services_Dashboard_Proxy_StateType_TO_Microsoft_Robotics_Services_Dashboard_StateType(object transformFrom)
        {
            Microsoft.Robotics.Services.Dashboard.StateType target = new Microsoft.Robotics.Services.Dashboard.StateType();
            Microsoft.Robotics.Services.Dashboard.Proxy.StateType from = transformFrom as Microsoft.Robotics.Services.Dashboard.Proxy.StateType;
            target.Log = from.Log;
            target.LogFile = from.LogFile;
            target.Machine = from.Machine;
            target.Port = from.Port;
            target.Options = (from.Options == null) ? null : (Microsoft.Robotics.Services.Dashboard.GUIOptions)Transform_Microsoft_Robotics_Services_Dashboard_Proxy_GUIOptions_TO_Microsoft_Robotics_Services_Dashboard_GUIOptions(from.Options);
            return target;
        }


        public static object Transform_Microsoft_Robotics_Services_Dashboard_StateType_TO_Microsoft_Robotics_Services_Dashboard_Proxy_StateType(object transformFrom)
        {
            Microsoft.Robotics.Services.Dashboard.Proxy.StateType target = new Microsoft.Robotics.Services.Dashboard.Proxy.StateType();
            Microsoft.Robotics.Services.Dashboard.StateType from = transformFrom as Microsoft.Robotics.Services.Dashboard.StateType;
            target.Log = from.Log;
            target.LogFile = from.LogFile;
            target.Machine = from.Machine;
            target.Port = from.Port;
            target.Options = (from.Options == null) ? null : (Microsoft.Robotics.Services.Dashboard.Proxy.GUIOptions)Transform_Microsoft_Robotics_Services_Dashboard_GUIOptions_TO_Microsoft_Robotics_Services_Dashboard_Proxy_GUIOptions(from.Options);
            return target;
        }


        public static object Transform_Microsoft_Robotics_Services_Dashboard_Proxy_GUIOptions_TO_Microsoft_Robotics_Services_Dashboard_GUIOptions(object transformFrom)
        {
            Microsoft.Robotics.Services.Dashboard.GUIOptions target = new Microsoft.Robotics.Services.Dashboard.GUIOptions();
            Microsoft.Robotics.Services.Dashboard.Proxy.GUIOptions from = transformFrom as Microsoft.Robotics.Services.Dashboard.Proxy.GUIOptions;
            target.WindowStartX = from.WindowStartX;
            target.WindowStartY = from.WindowStartY;
            target.DeadZoneX = from.DeadZoneX;
            target.DeadZoneY = from.DeadZoneY;
            target.TranslateScaleFactor = from.TranslateScaleFactor;
            target.RotateScaleFactor = from.RotateScaleFactor;
            target.ShowLRF = from.ShowLRF;
            target.ShowArm = from.ShowArm;
            target.RobotWidth = from.RobotWidth;
            target.DisplayMap = from.DisplayMap;
            target.MaxLRFRange = from.MaxLRFRange;
            target.MotionSpeed = from.MotionSpeed;
            target.DriveDistance = from.DriveDistance;
            target.RotateAngle = from.RotateAngle;
            target.CameraInterval = from.CameraInterval;
            return target;
        }


        public static object Transform_Microsoft_Robotics_Services_Dashboard_GUIOptions_TO_Microsoft_Robotics_Services_Dashboard_Proxy_GUIOptions(object transformFrom)
        {
            Microsoft.Robotics.Services.Dashboard.Proxy.GUIOptions target = new Microsoft.Robotics.Services.Dashboard.Proxy.GUIOptions();
            Microsoft.Robotics.Services.Dashboard.GUIOptions from = transformFrom as Microsoft.Robotics.Services.Dashboard.GUIOptions;
            target.WindowStartX = from.WindowStartX;
            target.WindowStartY = from.WindowStartY;
            target.DeadZoneX = from.DeadZoneX;
            target.DeadZoneY = from.DeadZoneY;
            target.TranslateScaleFactor = from.TranslateScaleFactor;
            target.RotateScaleFactor = from.RotateScaleFactor;
            target.ShowLRF = from.ShowLRF;
            target.ShowArm = from.ShowArm;
            target.RobotWidth = from.RobotWidth;
            target.DisplayMap = from.DisplayMap;
            target.MaxLRFRange = from.MaxLRFRange;
            target.MotionSpeed = from.MotionSpeed;
            target.DriveDistance = from.DriveDistance;
            target.RotateAngle = from.RotateAngle;
            target.CameraInterval = from.CameraInterval;
            return target;
        }

        static Transforms()
        {
            Register();
        }
        public static void Register()
        {
            AddProxyTransform(typeof(Microsoft.Robotics.Services.Dashboard.Proxy.StateType), Transform_Microsoft_Robotics_Services_Dashboard_Proxy_StateType_TO_Microsoft_Robotics_Services_Dashboard_StateType);
            AddSourceTransform(typeof(Microsoft.Robotics.Services.Dashboard.StateType), Transform_Microsoft_Robotics_Services_Dashboard_StateType_TO_Microsoft_Robotics_Services_Dashboard_Proxy_StateType);
            AddProxyTransform(typeof(Microsoft.Robotics.Services.Dashboard.Proxy.GUIOptions), Transform_Microsoft_Robotics_Services_Dashboard_Proxy_GUIOptions_TO_Microsoft_Robotics_Services_Dashboard_GUIOptions);
            AddSourceTransform(typeof(Microsoft.Robotics.Services.Dashboard.GUIOptions), Transform_Microsoft_Robotics_Services_Dashboard_GUIOptions_TO_Microsoft_Robotics_Services_Dashboard_Proxy_GUIOptions);
        }
    }
}

