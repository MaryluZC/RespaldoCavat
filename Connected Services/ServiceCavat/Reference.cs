﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cavat.ServiceCavat {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="login", Namespace="http://schemas.datacontract.org/2004/07/wcfComun")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Cavat.ServiceCavat.cambioPass))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Cavat.ServiceCavat.Registro))]
    public partial class login : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int opck__BackingFieldField;
        
        private string paswdk__BackingFieldField;
        
        private string usuariok__BackingFieldField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<opc>k__BackingField", IsRequired=true)]
        public int opck__BackingField {
            get {
                return this.opck__BackingFieldField;
            }
            set {
                if ((this.opck__BackingFieldField.Equals(value) != true)) {
                    this.opck__BackingFieldField = value;
                    this.RaisePropertyChanged("opck__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<paswd>k__BackingField", IsRequired=true)]
        public string paswdk__BackingField {
            get {
                return this.paswdk__BackingFieldField;
            }
            set {
                if ((object.ReferenceEquals(this.paswdk__BackingFieldField, value) != true)) {
                    this.paswdk__BackingFieldField = value;
                    this.RaisePropertyChanged("paswdk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<usuario>k__BackingField", IsRequired=true)]
        public string usuariok__BackingField {
            get {
                return this.usuariok__BackingFieldField;
            }
            set {
                if ((object.ReferenceEquals(this.usuariok__BackingFieldField, value) != true)) {
                    this.usuariok__BackingFieldField = value;
                    this.RaisePropertyChanged("usuariok__BackingField");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="cambioPass", Namespace="http://schemas.datacontract.org/2004/07/wcfComun")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Cavat.ServiceCavat.Registro))]
    public partial class cambioPass : Cavat.ServiceCavat.login {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int cambioPswField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int cambioPsw {
            get {
                return this.cambioPswField;
            }
            set {
                if ((this.cambioPswField.Equals(value) != true)) {
                    this.cambioPswField = value;
                    this.RaisePropertyChanged("cambioPsw");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Registro", Namespace="http://schemas.datacontract.org/2004/07/wcfComun")]
    [System.SerializableAttribute()]
    public partial class Registro : Cavat.ServiceCavat.cambioPass {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ape1Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ape2Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int bloqueadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string cedulaPField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string correoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idPreguntaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idStatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idTipoDocField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idTipoUserField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int intentosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nombreDocField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int numNotariaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string respuestaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string telCelField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ape1 {
            get {
                return this.ape1Field;
            }
            set {
                if ((object.ReferenceEquals(this.ape1Field, value) != true)) {
                    this.ape1Field = value;
                    this.RaisePropertyChanged("ape1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ape2 {
            get {
                return this.ape2Field;
            }
            set {
                if ((object.ReferenceEquals(this.ape2Field, value) != true)) {
                    this.ape2Field = value;
                    this.RaisePropertyChanged("ape2");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int bloqueado {
            get {
                return this.bloqueadoField;
            }
            set {
                if ((this.bloqueadoField.Equals(value) != true)) {
                    this.bloqueadoField = value;
                    this.RaisePropertyChanged("bloqueado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string cedulaP {
            get {
                return this.cedulaPField;
            }
            set {
                if ((object.ReferenceEquals(this.cedulaPField, value) != true)) {
                    this.cedulaPField = value;
                    this.RaisePropertyChanged("cedulaP");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string correo {
            get {
                return this.correoField;
            }
            set {
                if ((object.ReferenceEquals(this.correoField, value) != true)) {
                    this.correoField = value;
                    this.RaisePropertyChanged("correo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idPregunta {
            get {
                return this.idPreguntaField;
            }
            set {
                if ((this.idPreguntaField.Equals(value) != true)) {
                    this.idPreguntaField = value;
                    this.RaisePropertyChanged("idPregunta");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idStatus {
            get {
                return this.idStatusField;
            }
            set {
                if ((this.idStatusField.Equals(value) != true)) {
                    this.idStatusField = value;
                    this.RaisePropertyChanged("idStatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idTipoDoc {
            get {
                return this.idTipoDocField;
            }
            set {
                if ((this.idTipoDocField.Equals(value) != true)) {
                    this.idTipoDocField = value;
                    this.RaisePropertyChanged("idTipoDoc");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idTipoUser {
            get {
                return this.idTipoUserField;
            }
            set {
                if ((this.idTipoUserField.Equals(value) != true)) {
                    this.idTipoUserField = value;
                    this.RaisePropertyChanged("idTipoUser");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int intentos {
            get {
                return this.intentosField;
            }
            set {
                if ((this.intentosField.Equals(value) != true)) {
                    this.intentosField = value;
                    this.RaisePropertyChanged("intentos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nombre {
            get {
                return this.nombreField;
            }
            set {
                if ((object.ReferenceEquals(this.nombreField, value) != true)) {
                    this.nombreField = value;
                    this.RaisePropertyChanged("nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nombreDoc {
            get {
                return this.nombreDocField;
            }
            set {
                if ((object.ReferenceEquals(this.nombreDocField, value) != true)) {
                    this.nombreDocField = value;
                    this.RaisePropertyChanged("nombreDoc");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int numNotaria {
            get {
                return this.numNotariaField;
            }
            set {
                if ((this.numNotariaField.Equals(value) != true)) {
                    this.numNotariaField = value;
                    this.RaisePropertyChanged("numNotaria");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string respuesta {
            get {
                return this.respuestaField;
            }
            set {
                if ((object.ReferenceEquals(this.respuestaField, value) != true)) {
                    this.respuestaField = value;
                    this.RaisePropertyChanged("respuesta");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string telCel {
            get {
                return this.telCelField;
            }
            set {
                if ((object.ReferenceEquals(this.telCelField, value) != true)) {
                    this.telCelField = value;
                    this.RaisePropertyChanged("telCel");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="wRespuesta", Namespace="http://schemas.datacontract.org/2004/07/wcfComun")]
    [System.SerializableAttribute()]
    public partial class wRespuesta : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Data.DataSet elDataSetField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int mensajeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Data.DataSet elDataSet {
            get {
                return this.elDataSetField;
            }
            set {
                if ((object.ReferenceEquals(this.elDataSetField, value) != true)) {
                    this.elDataSetField = value;
                    this.RaisePropertyChanged("elDataSet");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int mensaje {
            get {
                return this.mensajeField;
            }
            set {
                if ((this.mensajeField.Equals(value) != true)) {
                    this.mensajeField = value;
                    this.RaisePropertyChanged("mensaje");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceCavat.IServiceCavat")]
    public interface IServiceCavat {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCavat/AccesLogin", ReplyAction="http://tempuri.org/IServiceCavat/AccesLoginResponse")]
        Cavat.ServiceCavat.wRespuesta AccesLogin(Cavat.ServiceCavat.login log);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCavat/AccesLogin", ReplyAction="http://tempuri.org/IServiceCavat/AccesLoginResponse")]
        System.Threading.Tasks.Task<Cavat.ServiceCavat.wRespuesta> AccesLoginAsync(Cavat.ServiceCavat.login log);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCavat/ResgistroUser", ReplyAction="http://tempuri.org/IServiceCavat/ResgistroUserResponse")]
        int ResgistroUser(Cavat.ServiceCavat.Registro reg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCavat/ResgistroUser", ReplyAction="http://tempuri.org/IServiceCavat/ResgistroUserResponse")]
        System.Threading.Tasks.Task<int> ResgistroUserAsync(Cavat.ServiceCavat.Registro reg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCavat/VerCatalogo", ReplyAction="http://tempuri.org/IServiceCavat/VerCatalogoResponse")]
        Cavat.ServiceCavat.wRespuesta VerCatalogo(int opc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCavat/VerCatalogo", ReplyAction="http://tempuri.org/IServiceCavat/VerCatalogoResponse")]
        System.Threading.Tasks.Task<Cavat.ServiceCavat.wRespuesta> VerCatalogoAsync(int opc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCavat/VerCatConstruccion", ReplyAction="http://tempuri.org/IServiceCavat/VerCatConstruccionResponse")]
        Cavat.ServiceCavat.wRespuesta VerCatConstruccion(int opc, int municipio, int año);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCavat/VerCatConstruccion", ReplyAction="http://tempuri.org/IServiceCavat/VerCatConstruccionResponse")]
        System.Threading.Tasks.Task<Cavat.ServiceCavat.wRespuesta> VerCatConstruccionAsync(int opc, int municipio, int año);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceCavatChannel : Cavat.ServiceCavat.IServiceCavat, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceCavatClient : System.ServiceModel.ClientBase<Cavat.ServiceCavat.IServiceCavat>, Cavat.ServiceCavat.IServiceCavat {
        
        public ServiceCavatClient() {
        }
        
        public ServiceCavatClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceCavatClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceCavatClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceCavatClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Cavat.ServiceCavat.wRespuesta AccesLogin(Cavat.ServiceCavat.login log) {
            return base.Channel.AccesLogin(log);
        }
        
        public System.Threading.Tasks.Task<Cavat.ServiceCavat.wRespuesta> AccesLoginAsync(Cavat.ServiceCavat.login log) {
            return base.Channel.AccesLoginAsync(log);
        }
        
        public int ResgistroUser(Cavat.ServiceCavat.Registro reg) {
            return base.Channel.ResgistroUser(reg);
        }
        
        public System.Threading.Tasks.Task<int> ResgistroUserAsync(Cavat.ServiceCavat.Registro reg) {
            return base.Channel.ResgistroUserAsync(reg);
        }
        
        public Cavat.ServiceCavat.wRespuesta VerCatalogo(int opc) {
            return base.Channel.VerCatalogo(opc);
        }
        
        public System.Threading.Tasks.Task<Cavat.ServiceCavat.wRespuesta> VerCatalogoAsync(int opc) {
            return base.Channel.VerCatalogoAsync(opc);
        }
        
        public Cavat.ServiceCavat.wRespuesta VerCatConstruccion(int opc, int municipio, int año) {
            return base.Channel.VerCatConstruccion(opc, municipio, año);
        }
        
        public System.Threading.Tasks.Task<Cavat.ServiceCavat.wRespuesta> VerCatConstruccionAsync(int opc, int municipio, int año) {
            return base.Channel.VerCatConstruccionAsync(opc, municipio, año);
        }
    }
}
