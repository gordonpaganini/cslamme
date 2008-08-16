using System;
using Microsoft.Dss.Core.Attributes;
using Microsoft.Dss.Core.Transforms;

#if NET_CF20
[assembly: ServiceDeclaration(DssServiceDeclaration.Transform, SourceAssemblyKey = @"cf.mazesimulatorra.y2006.m08, version=1.8.0.0, culture=neutral, publickeytoken=afde062daa7bb8cf")]
#else
[assembly: ServiceDeclaration(DssServiceDeclaration.Transform, SourceAssemblyKey = @"mazesimulatorra.y2006.m08, version=1.8.0.0, culture=neutral, publickeytoken=afde062daa7bb8cf")]
#endif
#if !URT_MINCLR
[assembly: System.Security.SecurityTransparent]
[assembly: System.Security.AllowPartiallyTrustedCallers]
#endif

namespace Dss.Transforms.TransformMazeSimulatorRA
{

    public class Transforms: TransformBase
    {

        public static object Transform_Cranium_Simulation_Worlds_Proxy_MazeSimulatorState_TO_Cranium_Simulation_Worlds_MazeSimulatorState(object transformFrom)
        {
            Cranium.Simulation.Worlds.MazeSimulatorState target = new Cranium.Simulation.Worlds.MazeSimulatorState();
            Cranium.Simulation.Worlds.Proxy.MazeSimulatorState from = transformFrom as Cranium.Simulation.Worlds.Proxy.MazeSimulatorState;
            target.Maze = from.Maze;
            target.GroundTexture = from.GroundTexture;

            // copy System.String[] target.WallTextures = from.WallTextures
            if (from.WallTextures != null)
            {
                target.WallTextures = new System.String[from.WallTextures.GetLength(0)];

                from.WallTextures.CopyTo(target.WallTextures, 0);
            }

            // copy Microsoft.Robotics.PhysicalModel.Vector3[] target.WallColors = from.WallColors
            if (from.WallColors != null)
            {
                target.WallColors = new Microsoft.Robotics.PhysicalModel.Vector3[from.WallColors.GetLength(0)];

                for (int d0 = 0; d0 < from.WallColors.GetLength(0); d0++)
                    target.WallColors[d0] = (Microsoft.Robotics.PhysicalModel.Vector3)Transform_Microsoft_Robotics_PhysicalModel_Proxy_Vector3_TO_Microsoft_Robotics_PhysicalModel_Vector3(from.WallColors[d0]);
            }

            // copy System.Single[] target.HeightMap = from.HeightMap
            if (from.HeightMap != null)
            {
                target.HeightMap = new System.Single[from.HeightMap.GetLength(0)];

                from.HeightMap.CopyTo(target.HeightMap, 0);
            }

            // copy System.Single[] target.MassMap = from.MassMap
            if (from.MassMap != null)
            {
                target.MassMap = new System.Single[from.MassMap.GetLength(0)];

                from.MassMap.CopyTo(target.MassMap, 0);
            }

            // copy System.Boolean[] target.UseSphere = from.UseSphere
            if (from.UseSphere != null)
            {
                target.UseSphere = new System.Boolean[from.UseSphere.GetLength(0)];

                from.UseSphere.CopyTo(target.UseSphere, 0);
            }
            target.WallBoxSize = from.WallBoxSize;
            target.GridSpacing = from.GridSpacing;
            target.HeightScale = from.HeightScale;
            target.DefaultHeight = from.DefaultHeight;
            target.SphereScale = from.SphereScale;
            target.RobotStartCellRow = from.RobotStartCellRow;
            target.RobotStartCellCol = from.RobotStartCellCol;
            target.RobotType = from.RobotType;
            target.UseLRF = from.UseLRF;
            target.UseSonar = from.UseSonar;
            return target;
        }


        public static object Transform_Cranium_Simulation_Worlds_MazeSimulatorState_TO_Cranium_Simulation_Worlds_Proxy_MazeSimulatorState(object transformFrom)
        {
            Cranium.Simulation.Worlds.Proxy.MazeSimulatorState target = new Cranium.Simulation.Worlds.Proxy.MazeSimulatorState();
            Cranium.Simulation.Worlds.MazeSimulatorState from = transformFrom as Cranium.Simulation.Worlds.MazeSimulatorState;
            target.Maze = from.Maze;
            target.GroundTexture = from.GroundTexture;

            // copy System.String[] target.WallTextures = from.WallTextures
            if (from.WallTextures != null)
            {
                target.WallTextures = new System.String[from.WallTextures.GetLength(0)];

                from.WallTextures.CopyTo(target.WallTextures, 0);
            }

            // copy Microsoft.Robotics.PhysicalModel.Proxy.Vector3[] target.WallColors = from.WallColors
            if (from.WallColors != null)
            {
                target.WallColors = new Microsoft.Robotics.PhysicalModel.Proxy.Vector3[from.WallColors.GetLength(0)];

                for (int d0 = 0; d0 < from.WallColors.GetLength(0); d0++)
                    target.WallColors[d0] = (Microsoft.Robotics.PhysicalModel.Proxy.Vector3)Transform_Microsoft_Robotics_PhysicalModel_Vector3_TO_Microsoft_Robotics_PhysicalModel_Proxy_Vector3(from.WallColors[d0]);
            }

            // copy System.Single[] target.HeightMap = from.HeightMap
            if (from.HeightMap != null)
            {
                target.HeightMap = new System.Single[from.HeightMap.GetLength(0)];

                from.HeightMap.CopyTo(target.HeightMap, 0);
            }

            // copy System.Single[] target.MassMap = from.MassMap
            if (from.MassMap != null)
            {
                target.MassMap = new System.Single[from.MassMap.GetLength(0)];

                from.MassMap.CopyTo(target.MassMap, 0);
            }

            // copy System.Boolean[] target.UseSphere = from.UseSphere
            if (from.UseSphere != null)
            {
                target.UseSphere = new System.Boolean[from.UseSphere.GetLength(0)];

                from.UseSphere.CopyTo(target.UseSphere, 0);
            }
            target.WallBoxSize = from.WallBoxSize;
            target.GridSpacing = from.GridSpacing;
            target.HeightScale = from.HeightScale;
            target.DefaultHeight = from.DefaultHeight;
            target.SphereScale = from.SphereScale;
            target.RobotStartCellRow = from.RobotStartCellRow;
            target.RobotStartCellCol = from.RobotStartCellCol;
            target.RobotType = from.RobotType;
            target.UseLRF = from.UseLRF;
            target.UseSonar = from.UseSonar;
            return target;
        }


        public static object Transform_Microsoft_Robotics_PhysicalModel_Proxy_Vector3_TO_Microsoft_Robotics_PhysicalModel_Vector3(object transformFrom)
        {
            Microsoft.Robotics.PhysicalModel.Vector3 target = new Microsoft.Robotics.PhysicalModel.Vector3();
            Microsoft.Robotics.PhysicalModel.Proxy.Vector3 from = (Microsoft.Robotics.PhysicalModel.Proxy.Vector3)transformFrom;
            target.X = from.X;
            target.Y = from.Y;
            target.Z = from.Z;
            return target;
        }


        public static object Transform_Microsoft_Robotics_PhysicalModel_Vector3_TO_Microsoft_Robotics_PhysicalModel_Proxy_Vector3(object transformFrom)
        {
            Microsoft.Robotics.PhysicalModel.Proxy.Vector3 target = new Microsoft.Robotics.PhysicalModel.Proxy.Vector3();
            Microsoft.Robotics.PhysicalModel.Vector3 from = (Microsoft.Robotics.PhysicalModel.Vector3)transformFrom;
            target.X = from.X;
            target.Y = from.Y;
            target.Z = from.Z;
            return target;
        }

        static Transforms()
        {
            Register();
        }
        public static void Register()
        {
            AddProxyTransform(typeof(Cranium.Simulation.Worlds.Proxy.MazeSimulatorState), Transform_Cranium_Simulation_Worlds_Proxy_MazeSimulatorState_TO_Cranium_Simulation_Worlds_MazeSimulatorState);
            AddSourceTransform(typeof(Cranium.Simulation.Worlds.MazeSimulatorState), Transform_Cranium_Simulation_Worlds_MazeSimulatorState_TO_Cranium_Simulation_Worlds_Proxy_MazeSimulatorState);
            AddProxyTransform(typeof(Microsoft.Robotics.PhysicalModel.Proxy.Vector3), Transform_Microsoft_Robotics_PhysicalModel_Proxy_Vector3_TO_Microsoft_Robotics_PhysicalModel_Vector3);
            AddSourceTransform(typeof(Microsoft.Robotics.PhysicalModel.Vector3), Transform_Microsoft_Robotics_PhysicalModel_Vector3_TO_Microsoft_Robotics_PhysicalModel_Proxy_Vector3);
        }
    }
}

