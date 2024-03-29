//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Ccr.Core;
using Microsoft.Dss.ServiceModel.Dssp;
using System;
using System.Collections.Generic;
using Microsoft.Dss.Core.Attributes;
using System.Xml.Serialization;
using W3C.Soap;
using compression = System.IO.Compression;
using contractmodel = Microsoft.Dss.Services.ContractModel;
using io = System.IO;
using pxengine = Microsoft.Robotics.Simulation.Engine.Proxy;
using pxmazesimulator = Robotics.MazeSimulator.Proxy;
using reflection = System.Reflection;

[assembly: ContractNamespace(pxmazesimulator.Contract.Identifier, ClrNamespace="Robotics.MazeSimulator.Proxy")]


namespace Robotics.MazeSimulator.Proxy
{
    
    /// <summary>
    /// Contract
    /// </summary>
    [XmlTypeAttribute(IncludeInSchema=false)]
    public sealed class Contract
    {
        /// <summary>
        /// Namespace
        /// </summary>
        public const string Identifier = "http://schemas.tempuri.org/2006/08/mazesimulator.html";
        /// The Dss Service dssModel Contract(s)
        public static List<contractmodel.ServiceSummary> ServiceModel()
        {
            List<contractmodel.ServiceSummary> services = null;
            io.Stream stream = null;
            try
            {
                string Resource = @"Robotics.MazeSimulator.Resources.DssModel.dss";
                stream = reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(Resource);
                compression.GZipStream compressionStream = new compression.GZipStream(stream, compression.CompressionMode.Decompress, true);
                XmlSerializer serializer = new XmlSerializer(typeof(List<contractmodel.ServiceSummary>));
                services = (List<contractmodel.ServiceSummary>)serializer.Deserialize(compressionStream);
                compressionStream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving Dss Service Model: ", ex.Message);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                    stream = null;
                }
            }
            return services;

        }
    }
    /// <summary>
    /// Maze Simulator State
    /// </summary>
    [DataContract()]
    [XmlRootAttribute("MazeSimulatorState", Namespace="http://schemas.tempuri.org/2006/08/mazesimulator.html")]
    public class MazeSimulatorState : System.ICloneable
    {
        public void CopyTo(MazeSimulatorState target)
        {
        }
        public virtual object Clone()
        {
            MazeSimulatorState newobj = new MazeSimulatorState();
            CopyTo(newobj);
            return newobj;

        }
    }
    /// <summary>
    /// Image Update Request
    /// </summary>
    [DataContract()]
    [XmlRootAttribute("ImageUpdateRequest", Namespace="http://schemas.tempuri.org/2006/08/mazesimulator.html")]
    public class ImageUpdateRequest : System.ICloneable
    {
        private System.DateTime _timeStamp;
        /// <summary>
        /// Time Stamp
        /// </summary>
        [DataMember()]
        public System.DateTime TimeStamp
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
        public void CopyTo(ImageUpdateRequest target)
        {
            target.TimeStamp = this.TimeStamp;
        }
        public virtual object Clone()
        {
            ImageUpdateRequest newobj = new ImageUpdateRequest();
            CopyTo(newobj);
            return newobj;

        }
    }
    /// <summary>
    /// Camera Entity
    /// </summary>
    [DataContract()]
    [XmlRootAttribute("CameraEntity", Namespace="http://schemas.tempuri.org/2006/08/mazesimulator.html")]
    public class CameraEntity : pxengine.VisualEntity
    {
        private bool _isPhysicsVisible;
        /// <summary>
        /// Is Physics Visible
        /// </summary>
        [DataMember()]
        public bool IsPhysicsVisible
        {
            get
            {
                return this._isPhysicsVisible;
            }
            set
            {
                this._isPhysicsVisible = value;
            }
        }
        public void CopyTo(CameraEntity target)
        {
            base.CopyTo(target);
            target.IsPhysicsVisible = this.IsPhysicsVisible;
        }
        public override object Clone()
        {
            CameraEntity newobj = new CameraEntity();
            CopyTo(newobj);
            return newobj;

        }
    }
    /// <summary>
    /// Maze Simulator Operations
    /// </summary>
    [XmlTypeAttribute(IncludeInSchema=false)]
    public class MazeSimulatorOperations : PortSet<DsspDefaultLookup, DsspDefaultDrop, Get, Replace, ImageUpdate>
    {
        // Post DsspDefaultLookup and return the response port.
        public virtual PortSet<LookupResponse,Fault> DsspDefaultLookup(LookupRequestType body)
        {
            DsspDefaultLookup op = new DsspDefaultLookup();
            op.Body = body ?? new LookupRequestType();
            this.Post(op);
            return op.ResponsePort;

        }
        // Post DsspDefaultLookup and return the response port.
        public virtual PortSet<LookupResponse,Fault> DsspDefaultLookup()
        {
            DsspDefaultLookup op = new DsspDefaultLookup();
            op.Body = new LookupRequestType();
            this.Post(op);
            return op.ResponsePort;

        }
        // Post DsspDefaultDrop and return the response port.
        public virtual PortSet<DefaultDropResponseType,Fault> DsspDefaultDrop(DropRequestType body)
        {
            DsspDefaultDrop op = new DsspDefaultDrop();
            op.Body = body ?? new DropRequestType();
            this.Post(op);
            return op.ResponsePort;

        }
        // Post DsspDefaultDrop and return the response port.
        public virtual PortSet<DefaultDropResponseType,Fault> DsspDefaultDrop()
        {
            DsspDefaultDrop op = new DsspDefaultDrop();
            op.Body = new DropRequestType();
            this.Post(op);
            return op.ResponsePort;

        }
        // Post Get and return the response port.
        public virtual PortSet<MazeSimulatorState,Fault> Get(GetRequestType body)
        {
            Get op = new Get();
            op.Body = body ?? new GetRequestType();
            this.Post(op);
            return op.ResponsePort;

        }
        // Post Replace and return the response port.
        public virtual PortSet<DefaultReplaceResponseType,Fault> Replace(MazeSimulatorState body)
        {
            Replace op = new Replace();
            op.Body = body ?? new MazeSimulatorState();
            this.Post(op);
            return op.ResponsePort;

        }
        // Post ImageUpdate and return the response port.
        public virtual PortSet<DefaultUpdateResponseType,Fault> ImageUpdate(ImageUpdateRequest body)
        {
            ImageUpdate op = new ImageUpdate();
            op.Body = body ?? new ImageUpdateRequest();
            this.Post(op);
            return op.ResponsePort;

        }
    }
    /// <summary>
    /// Get
    /// </summary>
    [XmlTypeAttribute(IncludeInSchema=false)]
    public class Get : Get<GetRequestType, PortSet<MazeSimulatorState, Fault>>
    {
        public Get()
        {
        }
        public Get(Microsoft.Dss.ServiceModel.Dssp.GetRequestType body) : 
                base(body)
        {
        }
        public Get(Microsoft.Dss.ServiceModel.Dssp.GetRequestType body, Microsoft.Ccr.Core.PortSet<MazeSimulatorState,W3C.Soap.Fault> responsePort) : 
                base(body, responsePort)
        {
        }
    }
    /// <summary>
    /// Replace
    /// </summary>
    [XmlTypeAttribute(IncludeInSchema=false)]
    public class Replace : Replace<MazeSimulatorState, PortSet<DefaultReplaceResponseType, Fault>>
    {
        public Replace()
        {
        }
        public Replace(MazeSimulatorState body) : 
                base(body)
        {
        }
        public Replace(MazeSimulatorState body, Microsoft.Ccr.Core.PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultReplaceResponseType,W3C.Soap.Fault> responsePort) : 
                base(body, responsePort)
        {
        }
    }
    /// <summary>
    /// Image Update
    /// </summary>
    [XmlTypeAttribute(IncludeInSchema=false)]
    public class ImageUpdate : Update<ImageUpdateRequest, PortSet<DefaultUpdateResponseType, Fault>>
    {
        public ImageUpdate()
        {
        }
        public ImageUpdate(ImageUpdateRequest body) : 
                base(body)
        {
        }
        public ImageUpdate(ImageUpdateRequest body, Microsoft.Ccr.Core.PortSet<Microsoft.Dss.ServiceModel.Dssp.DefaultUpdateResponseType,W3C.Soap.Fault> responsePort) : 
                base(body, responsePort)
        {
        }
    }
}
