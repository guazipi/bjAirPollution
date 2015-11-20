namespace BEPB.DataServiceReference
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.Serialization;
    using System.Threading;

    [DataContract(Name="EntityKeyMember", Namespace="http://schemas.datacontract.org/2004/07/System.Data"), KnownType(typeof(List<TB_RTC>)), KnownType(typeof(StructuralObject)), KnownType(typeof(EntityObject)), KnownType(typeof(TB_RTC)), KnownType(typeof(List<EntityKeyMember>)), GeneratedCode("System.Runtime.Serialization", "4.0.0.0"), KnownType(typeof(List<TB_Message>)), KnownType(typeof(TB_Message)), DebuggerStepThrough, KnownType(typeof(List<TB_Alert>)), KnownType(typeof(TB_Alert)), KnownType(typeof(EntityKey))]
    public class EntityKeyMember : INotifyPropertyChanged
    {
        private string KeyField;
        private object ValueField;

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
        public string Key
        {
            get
            {
                return this.KeyField;
            }
            set
            {
                if (!object.ReferenceEquals(this.KeyField, value))
                {
                    this.KeyField = value;
                    this.RaisePropertyChanged("Key");
                }
            }
        }

        [DataMember]
        public object Value
        {
            get
            {
                return this.ValueField;
            }
            set
            {
                if (!object.ReferenceEquals(this.ValueField, value))
                {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
    }
}

