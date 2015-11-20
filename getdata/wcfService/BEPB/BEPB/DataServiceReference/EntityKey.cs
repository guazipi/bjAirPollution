namespace BEPB.DataServiceReference
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.Serialization;
    using System.Threading;

    [DataContract(Name="EntityKey", Namespace="http://schemas.datacontract.org/2004/07/System.Data", IsReference=true), DebuggerStepThrough, GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
    public class EntityKey : INotifyPropertyChanged
    {
        private string EntityContainerNameField;
        private List<EntityKeyMember> EntityKeyValuesField;
        private string EntitySetNameField;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [DataMember]
        public string EntityContainerName
        {
            get
            {
                return this.EntityContainerNameField;
            }
            set
            {
                if (!object.ReferenceEquals(this.EntityContainerNameField, value))
                {
                    this.EntityContainerNameField = value;
                    this.RaisePropertyChanged("EntityContainerName");
                }
            }
        }

        [DataMember]
        public List<EntityKeyMember> EntityKeyValues
        {
            get
            {
                return this.EntityKeyValuesField;
            }
            set
            {
                if (!object.ReferenceEquals(this.EntityKeyValuesField, value))
                {
                    this.EntityKeyValuesField = value;
                    this.RaisePropertyChanged("EntityKeyValues");
                }
            }
        }

        [DataMember]
        public string EntitySetName
        {
            get
            {
                return this.EntitySetNameField;
            }
            set
            {
                if (!object.ReferenceEquals(this.EntitySetNameField, value))
                {
                    this.EntitySetNameField = value;
                    this.RaisePropertyChanged("EntitySetName");
                }
            }
        }
    }
}

