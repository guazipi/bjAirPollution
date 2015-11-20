namespace BEPB.DataServiceReference
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.Serialization;
    using System.Threading;

    [DebuggerStepThrough, DataContract(Name="StructuralObject", Namespace="http://schemas.datacontract.org/2004/07/System.Data.Objects.DataClasses", IsReference=true), KnownType(typeof(EntityObject)), KnownType(typeof(TB_RTC)), KnownType(typeof(TB_Alert)), GeneratedCode("System.Runtime.Serialization", "4.0.0.0"), KnownType(typeof(TB_Message))]
    public class StructuralObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

