//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1434
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Ccr.Core;
using Microsoft.Dss.Core;
using Microsoft.Dss.Core.Attributes;
using Microsoft.Dss.ServiceModel.Dssp;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using W3C.Soap;
using compression = System.IO.Compression;
using constructor = Microsoft.Dss.Services.Constructor;
using contractmanager = Microsoft.Dss.Services.ContractManager;
using contractmodel = Microsoft.Dss.Services.ContractModel;
using io = System.IO;
using pxcontactsensor = Microsoft.Robotics.Services.ContactSensor.Proxy;
using pxdrive = Microsoft.Robotics.Services.Drive.Proxy;
using pxexplorersim = Microsoft.Robotics.Services.ExplorerSim.Proxy;
using pxsicklrf = Microsoft.Robotics.Services.Sensors.SickLRF.Proxy;
using reflection = System.Reflection;


namespace Microsoft.Robotics.Services.ExplorerSim.Proxy
{
    
    
    /// <summary>
    /// ExplorerSim Contract
    /// </summary>
    [XmlTypeAttribute(IncludeInSchema=false)]
    public sealed class Contract
    {
        
        /// The Unique Contract Identifier for the ExplorerSim service
        public const String Identifier = "http://schemas.microsoft.com/robotics/2007/06/explorersim.html";
        
        /// The Dss Service dssModel Contract(s)
        public static List<contractmodel.ServiceSummary> ServiceModel()
        {
            contractmanager.ServiceSummaryLoader loader = new contractmanager.ServiceSummaryLoader();
            return loader.GetServiceSummaries(typeof(Contract).Assembly);

        }
        
        /// <summary>
        /// Creates an instance of the service associated with this contract
        /// </summary>
        /// <param name="contructorServicePort">Contractor Service that will create the instance</param>
        /// <param name="partners">Optional list of service partners for new service instance</param>
        /// <returns>Result PortSet for retrieving service creation response</returns>
        public static DsspResponsePort<CreateResponse> CreateService(constructor.ConstructorPort contructorServicePort, params PartnerType[] partners)
        {
            DsspResponsePort<CreateResponse> result = new DsspResponsePort<CreateResponse>();
            ServiceInfoType si = new ServiceInfoType(Contract.Identifier, null);
            if (partners != null)
            {
                si.PartnerList = new List<PartnerType>(partners);
            }
            Microsoft.Dss.Services.Constructor.Create create =
                new Microsoft.Dss.Services.Constructor.Create(si, result);
            contructorServicePort.Post(create);
            return result;

        }
        
        /// <summary>
        /// Creates an instance of the service associated with this contract
        /// </summary>
        /// <param name="contructorServicePort">Contractor Service that will create the instance</param>
        /// <returns>Result PortSet for retrieving service creation response</returns>
        public static DsspResponsePort<CreateResponse> CreateService(constructor.ConstructorPort contructorServicePort)
        {
            return Contract.CreateService(contructorServicePort, null);
        }
    }
    
    /// <summary>
    /// State
    /// </summary>
    [DataContract()]
    [XmlRootAttribute("State", Namespace="http://schemas.microsoft.com/robotics/2007/06/explorersim.html")]
    public class State : ICloneable, IDssSerializable
    {
        
        private pxdrive.DriveDifferentialTwoWheelState _driveState;
        
        private Int32 _countdown;
        
        private LogicalState _logicalState;
        
        private Int32 _newHeading;
        
        private Int32 _velocity;
        
        private pxsicklrf.State _south;
        
        private Boolean _mapped;
        
        private DateTime _mostRecentLaser;
        
        private Single _x;
        
        private Single _y;
        
        private Single _theta;
        
        private Boolean _drawMap;
        
        private MapMode _drawingMode;
        
        private Double _mapWidth;
        
        private Double _mapHeight;
        
        private Double _mapResolution;
        
        private Double _mapMaxRange;
        
        private Byte _bayesVacant;
        
        private Byte _bayesObstacle;
        
        /// <summary>
        /// Drive State
        /// </summary>
        [DataMember()]
        public pxdrive.DriveDifferentialTwoWheelState DriveState
        {
            get
            {
                return this._driveState;
            }
            set
            {
                this._driveState = value;
            }
        }
        
        /// <summary>
        /// Countdown
        /// </summary>
        [DataMember()]
        public Int32 Countdown
        {
            get
            {
                return this._countdown;
            }
            set
            {
                this._countdown = value;
            }
        }
        
        /// <summary>
        /// Logical State
        /// </summary>
        [DataMember()]
        public LogicalState LogicalState
        {
            get
            {
                return this._logicalState;
            }
            set
            {
                this._logicalState = value;
            }
        }
        
        /// <summary>
        /// New Heading
        /// </summary>
        [DataMember()]
        public Int32 NewHeading
        {
            get
            {
                return this._newHeading;
            }
            set
            {
                this._newHeading = value;
            }
        }
        
        /// <summary>
        /// Velocity
        /// </summary>
        [DataMember()]
        public Int32 Velocity
        {
            get
            {
                return this._velocity;
            }
            set
            {
                this._velocity = value;
            }
        }
        
        /// <summary>
        /// South
        /// </summary>
        [DataMember()]
        public pxsicklrf.State South
        {
            get
            {
                return this._south;
            }
            set
            {
                this._south = value;
            }
        }
        
        /// <summary>
        /// Mapped
        /// </summary>
        [DataMember()]
        public Boolean Mapped
        {
            get
            {
                return this._mapped;
            }
            set
            {
                this._mapped = value;
            }
        }
        
        /// <summary>
        /// Most Recent Laser
        /// </summary>
        [DataMember()]
        public DateTime MostRecentLaser
        {
            get
            {
                return this._mostRecentLaser;
            }
            set
            {
                this._mostRecentLaser = value;
            }
        }
        
        /// <summary>
        /// X
        /// </summary>
        [DataMember()]
        public Single X
        {
            get
            {
                return this._x;
            }
            set
            {
                this._x = value;
            }
        }
        
        /// <summary>
        /// Y
        /// </summary>
        [DataMember()]
        public Single Y
        {
            get
            {
                return this._y;
            }
            set
            {
                this._y = value;
            }
        }
        
        /// <summary>
        /// Theta
        /// </summary>
        [DataMember()]
        public Single Theta
        {
            get
            {
                return this._theta;
            }
            set
            {
                this._theta = value;
            }
        }
        
        /// <summary>
        /// Draw Map
        /// </summary>
        [DataMember()]
        public Boolean DrawMap
        {
            get
            {
                return this._drawMap;
            }
            set
            {
                this._drawMap = value;
            }
        }
        
        /// <summary>
        /// Drawing Mode
        /// </summary>
        [DataMember()]
        public MapMode DrawingMode
        {
            get
            {
                return this._drawingMode;
            }
            set
            {
                this._drawingMode = value;
            }
        }
        
        /// <summary>
        /// Map Width
        /// </summary>
        [DataMember()]
        public Double MapWidth
        {
            get
            {
                return this._mapWidth;
            }
            set
            {
                this._mapWidth = value;
            }
        }
        
        /// <summary>
        /// Map Height
        /// </summary>
        [DataMember()]
        public Double MapHeight
        {
            get
            {
                return this._mapHeight;
            }
            set
            {
                this._mapHeight = value;
            }
        }
        
        /// <summary>
        /// Map Resolution
        /// </summary>
        [DataMember()]
        public Double MapResolution
        {
            get
            {
                return this._mapResolution;
            }
            set
            {
                this._mapResolution = value;
            }
        }
        
        /// <summary>
        /// Map Max Range
        /// </summary>
        [DataMember()]
        public Double MapMaxRange
        {
            get
            {
                return this._mapMaxRange;
            }
            set
            {
                this._mapMaxRange = value;
            }
        }
        
        /// <summary>
        /// Bayes Vacant
        /// </summary>
        [DataMember()]
        public Byte BayesVacant
        {
            get
            {
                return this._bayesVacant;
            }
            set
            {
                this._bayesVacant = value;
            }
        }
        
        /// <summary>
        /// Bayes Obstacle
        /// </summary>
        [DataMember()]
        public Byte BayesObstacle
        {
            get
            {
                return this._bayesObstacle;
            }
            set
            {
                this._bayesObstacle = value;
            }
        }
        
        /// <summary>
        /// Copy To State
        /// </summary>
        public virtual void CopyTo(IDssSerializable target)
        {
            State typedTarget = target as State;

            if (typedTarget == null)
                throw new ArgumentException("CopyTo({0}) requires type {0}", this.GetType().FullName);
            typedTarget.DriveState = (this.DriveState == null) ? null : (Microsoft.Robotics.Services.Drive.Proxy.DriveDifferentialTwoWheelState)((Microsoft.Dss.Core.IDssSerializable)this.DriveState).Clone();
            typedTarget.Countdown = this.Countdown;
            typedTarget.LogicalState = this.LogicalState;
            typedTarget.NewHeading = this.NewHeading;
            typedTarget.Velocity = this.Velocity;
            typedTarget.South = (this.South == null) ? null : (Microsoft.Robotics.Services.Sensors.SickLRF.Proxy.State)((Microsoft.Dss.Core.IDssSerializable)this.South).Clone();
            typedTarget.Mapped = this.Mapped;
            typedTarget.MostRecentLaser = this.MostRecentLaser;
            typedTarget.X = this.X;
            typedTarget.Y = this.Y;
            typedTarget.Theta = this.Theta;
            typedTarget.DrawMap = this.DrawMap;
            typedTarget.DrawingMode = this.DrawingMode;
            typedTarget.MapWidth = this.MapWidth;
            typedTarget.MapHeight = this.MapHeight;
            typedTarget.MapResolution = this.MapResolution;
            typedTarget.MapMaxRange = this.MapMaxRange;
            typedTarget.BayesVacant = this.BayesVacant;
            typedTarget.BayesObstacle = this.BayesObstacle;
        }
        
        /// <summary>
        /// Clone State
        /// </summary>
        public virtual object Clone()
        {
            State target = new State();

            target.DriveState = (this.DriveState == null) ? null : (Microsoft.Robotics.Services.Drive.Proxy.DriveDifferentialTwoWheelState)((Microsoft.Dss.Core.IDssSerializable)this.DriveState).Clone();
            target.Countdown = this.Countdown;
            target.LogicalState = this.LogicalState;
            target.NewHeading = this.NewHeading;
            target.Velocity = this.Velocity;
            target.South = (this.South == null) ? null : (Microsoft.Robotics.Services.Sensors.SickLRF.Proxy.State)((Microsoft.Dss.Core.IDssSerializable)this.South).Clone();
            target.Mapped = this.Mapped;
            target.MostRecentLaser = this.MostRecentLaser;
            target.X = this.X;
            target.Y = this.Y;
            target.Theta = this.Theta;
            target.DrawMap = this.DrawMap;
            target.DrawingMode = this.DrawingMode;
            target.MapWidth = this.MapWidth;
            target.MapHeight = this.MapHeight;
            target.MapResolution = this.MapResolution;
            target.MapMaxRange = this.MapMaxRange;
            target.BayesVacant = this.BayesVacant;
            target.BayesObstacle = this.BayesObstacle;
            return target;

        }
        
        /// <summary>
        /// Serialize Serialize
        /// </summary>
        public virtual void Serialize(System.IO.BinaryWriter writer)
        {
            if (DriveState == null) writer.Write((byte)0);
            else
            {
                // null flag
                writer.Write((byte)1);

                ((Microsoft.Dss.Core.IDssSerializable)DriveState).Serialize(writer);
            }

            writer.Write(Countdown);

            writer.Write((System.Int32)LogicalState);

            writer.Write(NewHeading);

            writer.Write(Velocity);

            if (South == null) writer.Write((byte)0);
            else
            {
                // null flag
                writer.Write((byte)1);

                ((Microsoft.Dss.Core.IDssSerializable)South).Serialize(writer);
            }

            writer.Write(Mapped);

            Microsoft.Dss.Services.Serializer.BinarySerializationHelper.SerializeDateTime(MostRecentLaser, writer);

            writer.Write(X);

            writer.Write(Y);

            writer.Write(Theta);

            writer.Write(DrawMap);

            writer.Write((System.Int32)DrawingMode);

            writer.Write(MapWidth);

            writer.Write(MapHeight);

            writer.Write(MapResolution);

            writer.Write(MapMaxRange);

            writer.Write(BayesVacant);

            writer.Write(BayesObstacle);

        }
        
        /// <summary>
        /// Deserialize Deserialize
        /// </summary>
        public virtual object Deserialize(System.IO.BinaryReader reader)
        {
            if (reader.ReadByte() == 0) {}
            else
            {
                DriveState = (Microsoft.Robotics.Services.Drive.Proxy.DriveDifferentialTwoWheelState)((Microsoft.Dss.Core.IDssSerializable)new Microsoft.Robotics.Services.Drive.Proxy.DriveDifferentialTwoWheelState()).Deserialize(reader);
            } //nullable

            Countdown = reader.ReadInt32();

            LogicalState = (LogicalState)reader.ReadInt32();

            NewHeading = reader.ReadInt32();

            Velocity = reader.ReadInt32();

            if (reader.ReadByte() == 0) {}
            else
            {
                South = (Microsoft.Robotics.Services.Sensors.SickLRF.Proxy.State)((Microsoft.Dss.Core.IDssSerializable)new Microsoft.Robotics.Services.Sensors.SickLRF.Proxy.State()).Deserialize(reader);
            } //nullable

            Mapped = reader.ReadBoolean();

            MostRecentLaser = Microsoft.Dss.Services.Serializer.BinarySerializationHelper.DeserializeDateTime(reader);

            X = reader.ReadSingle();

            Y = reader.ReadSingle();

            Theta = reader.ReadSingle();

            DrawMap = reader.ReadBoolean();

            DrawingMode = (MapMode)reader.ReadInt32();

            MapWidth = reader.ReadDouble();

            MapHeight = reader.ReadDouble();

            MapResolution = reader.ReadDouble();

            MapMaxRange = reader.ReadDouble();

            BayesVacant = reader.ReadByte();

            BayesObstacle = reader.ReadByte();

            return this;

        }
    }
    
    /// <summary>
    /// Watch Dog Update Request
    /// </summary>
    [DataContract()]
    [XmlRootAttribute("WatchDogUpdateRequest", Namespace="http://schemas.microsoft.com/robotics/2007/06/explorersim.html")]
    public class WatchDogUpdateRequest : ICloneable, IDssSerializable
    {
        
        private DateTime _timeStamp;
        
        /// <summary>
        /// Time Stamp
        /// </summary>
        [DataMember()]
        public DateTime TimeStamp
        {
            get
            {
                return this._timeStamp;
            }
            set
            {
                this._timeStamp = value;
            }
        }
        
        /// <summary>
        /// Copy To Watch Dog Update Request
        /// </summary>
        public virtual void CopyTo(IDssSerializable target)
        {
            WatchDogUpdateRequest typedTarget = target as WatchDogUpdateRequest;

            if (typedTarget == null)
                throw new ArgumentException("CopyTo({0}) requires type {0}", this.GetType().FullName);
            typedTarget.TimeStamp = this.TimeStamp;
        }
        
        /// <summary>
        /// Clone Watch Dog Update Request
        /// </summary>
        public virtual object Clone()
        {
            WatchDogUpdateRequest target = new WatchDogUpdateRequest();

            target.TimeStamp = this.TimeStamp;
            return target;

        }
        
        /// <summary>
        /// Serialize Serialize
        /// </summary>
        public virtual void Serialize(System.IO.BinaryWriter writer)
        {
            Microsoft.Dss.Services.Serializer.BinarySerializationHelper.SerializeDateTime(TimeStamp, writer);

        }
        
        /// <summary>
        /// Deserialize Deserialize
        /// </summary>
        public virtual object Deserialize(System.IO.BinaryReader reader)
        {
            TimeStamp = Microsoft.Dss.Services.Serializer.BinarySerializationHelper.DeserializeDateTime(reader);

            return this;

        }
    }
    
    /// <summary>
    /// Logical State
    /// </summary>
    [DataContract()]
    [XmlRootAttribute("LogicalState", Namespace="http://schemas.microsoft.com/robotics/2007/06/explorersim.html")]
    public enum LogicalState
    {
        
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 0,
        
        /// <summary>
        /// Random Turn
        /// </summary>
        RandomTurn = 1,
        
        /// <summary>
        /// Adjust Heading
        /// </summary>
        AdjustHeading = 2,
        
        /// <summary>
        /// Free Forwards
        /// </summary>
        FreeForwards = 3,
        
        /// <summary>
        /// Map Surroundings
        /// </summary>
        MapSurroundings = 4,
        
        /// <summary>
        /// Map North
        /// </summary>
        MapNorth = 5,
        
        /// <summary>
        /// Map South
        /// </summary>
        MapSouth = 6,
    }
    
    /// <summary>
    /// Map Mode
    /// </summary>
    [DataContract()]
    [XmlRootAttribute("MapMode", Namespace="http://schemas.microsoft.com/robotics/2007/06/explorersim.html")]
    public enum MapMode
    {
        
        /// <summary>
        /// Overwrite
        /// </summary>
        Overwrite = 0,
        
        /// <summary>
        /// Counting
        /// </summary>
        Counting = 1,
        
        /// <summary>
        /// Bayes Rule
        /// </summary>
        BayesRule = 2,
    }
    
    /// <summary>
    /// Explorer Sim Operations
    /// </summary>
    [ServicePort()]
    [XmlTypeAttribute(IncludeInSchema=false)]
    public class ExplorerSimOperations : PortSet<Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup, Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop, Get, BumperUpdate, BumpersUpdate, DriveUpdate, LaserRangeFinderUpdate, LaserRangeFinderResetUpdate, WatchDogUpdate>
    {
        
        /// <summary>
        /// Required Lookup request body type
        /// </summary>
        public virtual PortSet<Microsoft.Dss.ServiceModel.Dssp.LookupResponse,Fault> DsspDefaultLookup()
        {
            Microsoft.Dss.ServiceModel.Dssp.LookupRequestType body = new Microsoft.Dss.ServiceModel.Dssp.LookupRequestType();
            Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup op = new Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup(body);
            this.Post(op);
            return op.ResponsePort;

        }
        
        /// <summary>
        /// Post Dssp Default Lookup and return the response port.
        /// </summary>
        public virtual PortSet<Microsoft.Dss.ServiceModel.Dssp.LookupResponse,Fault> DsspDefaultLookup(Microsoft.Dss.ServiceModel.Dssp.LookupRequestType body)
        {
            Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup op = new Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup();
            op.Body = body ?? new Microsoft.Dss.ServiceModel.Dssp.LookupRequestType();
            this.Post(op);
            return op.ResponsePort;

        }
        
        /// <summary>
        /// A request to drop the service.
        /// </summary>
        public virtual PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultDropResponseType,Fault> DsspDefaultDrop()
        {
            Microsoft.Dss.ServiceModel.Dssp.DropRequestType body = new Microsoft.Dss.ServiceModel.Dssp.DropRequestType();
            Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop op = new Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop(body);
            this.Post(op);
            return op.ResponsePort;

        }
        
        /// <summary>
        /// Post Dssp Default Drop and return the response port.
        /// </summary>
        public virtual PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultDropResponseType,Fault> DsspDefaultDrop(Microsoft.Dss.ServiceModel.Dssp.DropRequestType body)
        {
            Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop op = new Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop();
            op.Body = body ?? new Microsoft.Dss.ServiceModel.Dssp.DropRequestType();
            this.Post(op);
            return op.ResponsePort;

        }
        
        /// <summary>
        /// Required Get body type
        /// </summary>
        public virtual PortSet<State,Fault> Get()
        {
            Microsoft.Dss.ServiceModel.Dssp.GetRequestType body = new Microsoft.Dss.ServiceModel.Dssp.GetRequestType();
            Get op = new Get(body);
            this.Post(op);
            return op.ResponsePort;

        }
        
        /// <summary>
        /// Post Get and return the response port.
        /// </summary>
        public virtual PortSet<State,Fault> Get(Microsoft.Dss.ServiceModel.Dssp.GetRequestType body)
        {
            Get op = new Get();
            op.Body = body ?? new Microsoft.Dss.ServiceModel.Dssp.GetRequestType();
            this.Post(op);
            return op.ResponsePort;

        }
        
        /// <summary>
        /// The state of the contact sensor.
        /// </summary>
        public virtual PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType,Fault> BumperUpdate()
        {
            pxcontactsensor.ContactSensor body = new pxcontactsensor.ContactSensor();
            BumperUpdate op = new BumperUpdate(body);
            this.Post(op);
            return op.ResponsePort;

        }
        
        /// <summary>
        /// Post Bumper Update and return the response port.
        /// </summary>
        public virtual PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType,Fault> BumperUpdate(pxcontactsensor.ContactSensor body)
        {
            BumperUpdate op = new BumperUpdate();
            op.Body = body ?? new pxcontactsensor.ContactSensor();
            this.Post(op);
            return op.ResponsePort;

        }
        
        /// <summary>
        /// The state of the set (array) of contact sensors.
        /// </summary>
        public virtual PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType,Fault> BumpersUpdate()
        {
            pxcontactsensor.ContactSensorArrayState body = new pxcontactsensor.ContactSensorArrayState();
            BumpersUpdate op = new BumpersUpdate(body);
            this.Post(op);
            return op.ResponsePort;

        }
        
        /// <summary>
        /// Post Bumpers Update and return the response port.
        /// </summary>
        public virtual PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType,Fault> BumpersUpdate(pxcontactsensor.ContactSensorArrayState body)
        {
            BumpersUpdate op = new BumpersUpdate();
            op.Body = body ?? new pxcontactsensor.ContactSensorArrayState();
            this.Post(op);
            return op.ResponsePort;

        }
        
        /// <summary>
        /// The state of the differential drive.
        /// </summary>
        public virtual PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType,Fault> DriveUpdate()
        {
            pxdrive.DriveDifferentialTwoWheelState body = new pxdrive.DriveDifferentialTwoWheelState();
            DriveUpdate op = new DriveUpdate(body);
            this.Post(op);
            return op.ResponsePort;

        }
        
        /// <summary>
        /// Post Drive Update and return the response port.
        /// </summary>
        public virtual PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType,Fault> DriveUpdate(pxdrive.DriveDifferentialTwoWheelState body)
        {
            DriveUpdate op = new DriveUpdate();
            op.Body = body ?? new pxdrive.DriveDifferentialTwoWheelState();
            this.Post(op);
            return op.ResponsePort;

        }
        
        /// <summary>
        /// Identifies the state of the Sick laser range finder (LRF).
        /// </summary>
        public virtual PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType,Fault> LaserRangeFinderUpdate()
        {
            pxsicklrf.State body = new pxsicklrf.State();
            LaserRangeFinderUpdate op = new LaserRangeFinderUpdate(body);
            this.Post(op);
            return op.ResponsePort;

        }
        
        /// <summary>
        /// Post Laser Range Finder Update and return the response port.
        /// </summary>
        public virtual PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType,Fault> LaserRangeFinderUpdate(pxsicklrf.State body)
        {
            LaserRangeFinderUpdate op = new LaserRangeFinderUpdate();
            op.Body = body ?? new pxsicklrf.State();
            this.Post(op);
            return op.ResponsePort;

        }
        
        /// <summary>
        /// Reset Type
        /// </summary>
        public virtual PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType,Fault> LaserRangeFinderResetUpdate()
        {
            pxsicklrf.ResetType body = new pxsicklrf.ResetType();
            LaserRangeFinderResetUpdate op = new LaserRangeFinderResetUpdate(body);
            this.Post(op);
            return op.ResponsePort;

        }
        
        /// <summary>
        /// Post Laser Range Finder Reset Update and return the response port.
        /// </summary>
        public virtual PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType,Fault> LaserRangeFinderResetUpdate(pxsicklrf.ResetType body)
        {
            LaserRangeFinderResetUpdate op = new LaserRangeFinderResetUpdate();
            op.Body = body ?? new pxsicklrf.ResetType();
            this.Post(op);
            return op.ResponsePort;

        }
        
        /// <summary>
        /// Watch Dog Update Request
        /// </summary>
        public virtual PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType,Fault> WatchDogUpdate()
        {
            WatchDogUpdateRequest body = new WatchDogUpdateRequest();
            WatchDogUpdate op = new WatchDogUpdate(body);
            this.Post(op);
            return op.ResponsePort;

        }
        
        /// <summary>
        /// Post Watch Dog Update and return the response port.
        /// </summary>
        public virtual PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType,Fault> WatchDogUpdate(WatchDogUpdateRequest body)
        {
            WatchDogUpdate op = new WatchDogUpdate();
            op.Body = body ?? new WatchDogUpdateRequest();
            this.Post(op);
            return op.ResponsePort;

        }
    }
    
    /// <summary>
    /// Get
    /// </summary>
    [XmlTypeAttribute(IncludeInSchema=false)]
    public class Get : Microsoft.Dss.ServiceModel.Dssp.Get<Microsoft.Dss.ServiceModel.Dssp.GetRequestType, PortSet<State, Fault>>
    {
        
        /// <summary>
        /// Get
        /// </summary>
        public Get()
        {
        }
        
        /// <summary>
        /// Get
        /// </summary>
        public Get(Microsoft.Dss.ServiceModel.Dssp.GetRequestType body) : 
                base(body)
        {
        }
        
        /// <summary>
        /// Get
        /// </summary>
        public Get(Microsoft.Dss.ServiceModel.Dssp.GetRequestType body, Microsoft.Ccr.Core.PortSet<State,W3C.Soap.Fault> responsePort) : 
                base(body, responsePort)
        {
        }
    }
    
    /// <summary>
    /// Bumper Update
    /// </summary>
    [XmlTypeAttribute(IncludeInSchema=false)]
    public class BumperUpdate : Microsoft.Dss.ServiceModel.Dssp.Update<pxcontactsensor.ContactSensor, PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType, Fault>>
    {
        
        /// <summary>
        /// Bumper Update
        /// </summary>
        public BumperUpdate()
        {
        }
        
        /// <summary>
        /// Bumper Update
        /// </summary>
        public BumperUpdate(Microsoft.Robotics.Services.ContactSensor.Proxy.ContactSensor body) : 
                base(body)
        {
        }
        
        /// <summary>
        /// Bumper Update
        /// </summary>
        public BumperUpdate(Microsoft.Robotics.Services.ContactSensor.Proxy.ContactSensor body, Microsoft.Ccr.Core.PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType,W3C.Soap.Fault> responsePort) : 
                base(body, responsePort)
        {
        }
    }
    
    /// <summary>
    /// Bumpers Update
    /// </summary>
    [XmlTypeAttribute(IncludeInSchema=false)]
    public class BumpersUpdate : Microsoft.Dss.ServiceModel.Dssp.Update<pxcontactsensor.ContactSensorArrayState, PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType, Fault>>
    {
        
        /// <summary>
        /// Bumpers Update
        /// </summary>
        public BumpersUpdate()
        {
        }
        
        /// <summary>
        /// Bumpers Update
        /// </summary>
        public BumpersUpdate(Microsoft.Robotics.Services.ContactSensor.Proxy.ContactSensorArrayState body) : 
                base(body)
        {
        }
        
        /// <summary>
        /// Bumpers Update
        /// </summary>
        public BumpersUpdate(Microsoft.Robotics.Services.ContactSensor.Proxy.ContactSensorArrayState body, Microsoft.Ccr.Core.PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType,W3C.Soap.Fault> responsePort) : 
                base(body, responsePort)
        {
        }
    }
    
    /// <summary>
    /// Drive Update
    /// </summary>
    [XmlTypeAttribute(IncludeInSchema=false)]
    public class DriveUpdate : Microsoft.Dss.ServiceModel.Dssp.Update<pxdrive.DriveDifferentialTwoWheelState, PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType, Fault>>
    {
        
        /// <summary>
        /// Drive Update
        /// </summary>
        public DriveUpdate()
        {
        }
        
        /// <summary>
        /// Drive Update
        /// </summary>
        public DriveUpdate(Microsoft.Robotics.Services.Drive.Proxy.DriveDifferentialTwoWheelState body) : 
                base(body)
        {
        }
        
        /// <summary>
        /// Drive Update
        /// </summary>
        public DriveUpdate(Microsoft.Robotics.Services.Drive.Proxy.DriveDifferentialTwoWheelState body, Microsoft.Ccr.Core.PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType,W3C.Soap.Fault> responsePort) : 
                base(body, responsePort)
        {
        }
    }
    
    /// <summary>
    /// Laser Range Finder Update
    /// </summary>
    [XmlTypeAttribute(IncludeInSchema=false)]
    public class LaserRangeFinderUpdate : Microsoft.Dss.ServiceModel.Dssp.Update<pxsicklrf.State, PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType, Fault>>
    {
        
        /// <summary>
        /// Laser Range Finder Update
        /// </summary>
        public LaserRangeFinderUpdate()
        {
        }
        
        /// <summary>
        /// Laser Range Finder Update
        /// </summary>
        public LaserRangeFinderUpdate(Microsoft.Robotics.Services.Sensors.SickLRF.Proxy.State body) : 
                base(body)
        {
        }
        
        /// <summary>
        /// Laser Range Finder Update
        /// </summary>
        public LaserRangeFinderUpdate(Microsoft.Robotics.Services.Sensors.SickLRF.Proxy.State body, Microsoft.Ccr.Core.PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType,W3C.Soap.Fault> responsePort) : 
                base(body, responsePort)
        {
        }
    }
    
    /// <summary>
    /// Laser Range Finder Reset Update
    /// </summary>
    [XmlTypeAttribute(IncludeInSchema=false)]
    public class LaserRangeFinderResetUpdate : Microsoft.Dss.ServiceModel.Dssp.Update<pxsicklrf.ResetType, PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType, Fault>>
    {
        
        /// <summary>
        /// Laser Range Finder Reset Update
        /// </summary>
        public LaserRangeFinderResetUpdate()
        {
        }
        
        /// <summary>
        /// Laser Range Finder Reset Update
        /// </summary>
        public LaserRangeFinderResetUpdate(Microsoft.Robotics.Services.Sensors.SickLRF.Proxy.ResetType body) : 
                base(body)
        {
        }
        
        /// <summary>
        /// Laser Range Finder Reset Update
        /// </summary>
        public LaserRangeFinderResetUpdate(Microsoft.Robotics.Services.Sensors.SickLRF.Proxy.ResetType body, Microsoft.Ccr.Core.PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType,W3C.Soap.Fault> responsePort) : 
                base(body, responsePort)
        {
        }
    }
    
    /// <summary>
    /// Watch Dog Update
    /// </summary>
    [XmlTypeAttribute(IncludeInSchema=false)]
    public class WatchDogUpdate : Microsoft.Dss.ServiceModel.Dssp.Update<WatchDogUpdateRequest, PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType, Fault>>
    {
        
        /// <summary>
        /// Watch Dog Update
        /// </summary>
        public WatchDogUpdate()
        {
        }
        
        /// <summary>
        /// Watch Dog Update
        /// </summary>
        public WatchDogUpdate(WatchDogUpdateRequest body) : 
                base(body)
        {
        }
        
        /// <summary>
        /// Watch Dog Update
        /// </summary>
        public WatchDogUpdate(WatchDogUpdateRequest body, Microsoft.Ccr.Core.PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType,W3C.Soap.Fault> responsePort) : 
                base(body, responsePort)
        {
        }
    }
}
