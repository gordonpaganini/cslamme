using System;
using Microsoft.Dss.Core.Attributes;
using Microsoft.Dss.Core.Transforms;

#if NET_CF20
[assembly: ServiceDeclaration(DssServiceDeclaration.Transform, SourceAssemblyKey = @"cf.craniumdashboard.y2007.m9, version=1.9.0.0, culture=neutral, publickeytoken=afde062daa7bb8cf")]
#else
[assembly: ServiceDeclaration(DssServiceDeclaration.Transform, SourceAssemblyKey = @"craniumdashboard.y2007.m9, version=1.9.0.0, culture=neutral, publickeytoken=afde062daa7bb8cf")]
#endif
#if !URT_MINCLR
[assembly: System.Security.SecurityTransparent]
[assembly: System.Security.AllowPartiallyTrustedCallers]
#endif

namespace Dss.Transforms.TransformCraniumDashboard
{

    public class Transforms: TransformBase
    {

        public static object Transform_Cranium_Controls_Proxy_StateType_TO_Cranium_Controls_StateType(object transformFrom)
        {
            Cranium.Controls.StateType target = new Cranium.Controls.StateType();
            Cranium.Controls.Proxy.StateType from = transformFrom as Cranium.Controls.Proxy.StateType;
            target.Log = from.Log;
            target.LogFile = from.LogFile;
            target.Machine = from.Machine;
            target.Port = from.Port;
            target.Options = (from.Options == null) ? null : (Cranium.Controls.GUIOptions)Transform_Cranium_Controls_Proxy_GUIOptions_TO_Cranium_Controls_GUIOptions(from.Options);
            return target;
        }


        public static object Transform_Cranium_Controls_StateType_TO_Cranium_Controls_Proxy_StateType(object transformFrom)
        {
            Cranium.Controls.Proxy.StateType target = new Cranium.Controls.Proxy.StateType();
            Cranium.Controls.StateType from = transformFrom as Cranium.Controls.StateType;
            target.Log = from.Log;
            target.LogFile = from.LogFile;
            target.Machine = from.Machine;
            target.Port = from.Port;
            target.Options = (from.Options == null) ? null : (Cranium.Controls.Proxy.GUIOptions)Transform_Cranium_Controls_GUIOptions_TO_Cranium_Controls_Proxy_GUIOptions(from.Options);
            return target;
        }


        public static object Transform_Cranium_Controls_Proxy_GUIOptions_TO_Cranium_Controls_GUIOptions(object transformFrom)
        {
            Cranium.Controls.GUIOptions target = new Cranium.Controls.GUIOptions();
            Cranium.Controls.Proxy.GUIOptions from = transformFrom as Cranium.Controls.Proxy.GUIOptions;
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
            target.SonarRange = from.SonarRange;

            // copy System.Double[] target.SonarRadians = from.SonarRadians
            if (from.SonarRadians != null)
            {
                target.SonarRadians = new System.Double[from.SonarRadians.GetLength(0)];

                from.SonarRadians.CopyTo(target.SonarRadians, 0);
            }
            target.SonarTransducerAngularRange = from.SonarTransducerAngularRange;
            target.DisplaySonarMap = from.DisplaySonarMap;
            return target;
        }


        public static object Transform_Cranium_Controls_GUIOptions_TO_Cranium_Controls_Proxy_GUIOptions(object transformFrom)
        {
            Cranium.Controls.Proxy.GUIOptions target = new Cranium.Controls.Proxy.GUIOptions();
            Cranium.Controls.GUIOptions from = transformFrom as Cranium.Controls.GUIOptions;
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
            target.SonarRange = from.SonarRange;

            // copy System.Double[] target.SonarRadians = from.SonarRadians
            if (from.SonarRadians != null)
            {
                target.SonarRadians = new System.Double[from.SonarRadians.GetLength(0)];

                from.SonarRadians.CopyTo(target.SonarRadians, 0);
            }
            target.SonarTransducerAngularRange = from.SonarTransducerAngularRange;
            target.DisplaySonarMap = from.DisplaySonarMap;
            return target;
        }

        static Transforms()
        {
            Register();
        }
        public static void Register()
        {
            AddProxyTransform(typeof(Cranium.Controls.Proxy.StateType), Transform_Cranium_Controls_Proxy_StateType_TO_Cranium_Controls_StateType);
            AddSourceTransform(typeof(Cranium.Controls.StateType), Transform_Cranium_Controls_StateType_TO_Cranium_Controls_Proxy_StateType);
            AddProxyTransform(typeof(Cranium.Controls.Proxy.GUIOptions), Transform_Cranium_Controls_Proxy_GUIOptions_TO_Cranium_Controls_GUIOptions);
            AddSourceTransform(typeof(Cranium.Controls.GUIOptions), Transform_Cranium_Controls_GUIOptions_TO_Cranium_Controls_Proxy_GUIOptions);
        }
    }
}

