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
using System.ComponentModel;
using System.Xml.Serialization;
using compression = System.IO.Compression;
using constructor = Microsoft.Dss.Services.Constructor;
using contractmanager = Microsoft.Dss.Services.ContractManager;
using contractmodel = Microsoft.Dss.Services.ContractModel;
using io = System.IO;
using pxengine = Microsoft.Robotics.Simulation.Engine.Proxy;
using pxphysics = Microsoft.Robotics.Simulation.Physics.Proxy;
using reflection = System.Reflection;


namespace Cranium.Simulation.Sensors.Proxy
{
    
    
    /// <summary>
    /// SimulatedSonar Contract
    /// </summary>
    [XmlTypeAttribute(IncludeInSchema=false)]
    public sealed class Contract
    {
        
        /// The Unique Contract Identifier for the SimulatedSonar service
        public const String Identifier = "http://www.conscious-robots.com/2007/07/simulatedsonar.html";
        
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
    /// Sonar Entity
    /// </summary>
    [DataContract()]
    [XmlRootAttribute("SonarEntity", Namespace="http://www.conscious-robots.com/2007/07/simulatedsonar.html")]
    public class SonarEntity : pxengine.VisualEntity
    {
        
        private pxphysics.BoxShape _sonarBox;
        
        /// <summary>
        /// Sonar Box
        /// </summary>
        [DataMember()]
        [Description("The geometry representation of the sonar.")]
        public pxphysics.BoxShape SonarBox
        {
            get
            {
                return this._sonarBox;
            }
            set
            {
                this._sonarBox = value;
            }
        }
        
        /// <summary>
        /// Copy To Sonar Entity
        /// </summary>
        public override void CopyTo(IDssSerializable target)
        {
            SonarEntity typedTarget = target as SonarEntity;

            if (typedTarget == null)
                throw new ArgumentException("CopyTo({0}) requires type {0}", this.GetType().FullName);
            base.CopyTo(typedTarget);
            typedTarget.SonarBox = (this.SonarBox == null) ? null : (Microsoft.Robotics.Simulation.Physics.Proxy.BoxShape)((Microsoft.Dss.Core.IDssSerializable)this.SonarBox).Clone();
        }
        
        /// <summary>
        /// Clone Sonar Entity
        /// </summary>
        public override object Clone()
        {
            SonarEntity target = new SonarEntity();

            base.CopyTo(target);
            target.SonarBox = (this.SonarBox == null) ? null : (Microsoft.Robotics.Simulation.Physics.Proxy.BoxShape)((Microsoft.Dss.Core.IDssSerializable)this.SonarBox).Clone();
            return target;

        }
        
        /// <summary>
        /// Serialize Serialize
        /// </summary>
        public override void Serialize(System.IO.BinaryWriter writer)
        {
            base.Serialize(writer);
            if (SonarBox == null) writer.Write((byte)0);
            else
            {
                // null flag
                writer.Write((byte)1);

                ((Microsoft.Dss.Core.IDssSerializable)SonarBox).Serialize(writer);
            }

        }
        
        /// <summary>
        /// Deserialize Deserialize
        /// </summary>
        public override object Deserialize(System.IO.BinaryReader reader)
        {
            base.Deserialize(reader);
            if (reader.ReadByte() == 0) {}
            else
            {
                SonarBox = (Microsoft.Robotics.Simulation.Physics.Proxy.BoxShape)((Microsoft.Dss.Core.IDssSerializable)new Microsoft.Robotics.Simulation.Physics.Proxy.BoxShape()).Deserialize(reader);
            } //nullable

            return this;

        }
    }
}