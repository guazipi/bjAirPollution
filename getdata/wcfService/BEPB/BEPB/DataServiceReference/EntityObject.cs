namespace BEPB.DataServiceReference
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Runtime.Serialization;

    [DataContract(Name="EntityObject", Namespace="http://schemas.datacontract.org/2004/07/System.Data.Objects.DataClasses", IsReference=true), KnownType(typeof(TB_Alert)), KnownType(typeof(TB_Message)), DebuggerStepThrough, GeneratedCode("System.Runtime.Serialization", "4.0.0.0"), KnownType(typeof(TB_RTC))]
    public class EntityObject : StructuralObject
    {
        private BEPB.DataServiceReference.EntityKey EntityKeyField;

        [DataMember]
        public BEPB.DataServiceReference.EntityKey EntityKey
        {
            get
            {
                return this.EntityKeyField;
            }
            set
            {
                if (!object.ReferenceEquals(this.EntityKeyField, value))
                {
                    this.EntityKeyField = value;
                    base.RaisePropertyChanged("EntityKey");
                }
            }
        }
    }
}

