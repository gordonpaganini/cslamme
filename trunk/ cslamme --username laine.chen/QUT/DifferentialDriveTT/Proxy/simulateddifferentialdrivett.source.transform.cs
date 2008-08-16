using System;
using Microsoft.Dss.Core.Attributes;
using Microsoft.Dss.Core.Transforms;

#if NET_CF20
[assembly: ServiceDeclaration(DssServiceDeclaration.Transform, SourceAssemblyKey = @"cf.simulateddifferentialdrivett.2007.m06, version=1.0.0.0, culture=neutral, publickeytoken=afde062daa7bb8cf")]
#else
[assembly: ServiceDeclaration(DssServiceDeclaration.Transform, SourceAssemblyKey = @"simulateddifferentialdrivett.2007.m06, version=1.0.0.0, culture=neutral, publickeytoken=afde062daa7bb8cf")]
#endif
#if !URT_MINCLR
[assembly: System.Security.SecurityTransparent]
[assembly: System.Security.AllowPartiallyTrustedCallers]
#endif

namespace Dss.Transforms.TransformSimulatedDifferentialDriveTT
{

    public class Transforms: TransformBase
    {
        static Transforms()
        {
            Register();
        }
        public static void Register()
        {
        }
    }
}

