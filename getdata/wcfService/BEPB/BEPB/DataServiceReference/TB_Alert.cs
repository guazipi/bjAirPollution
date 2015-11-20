namespace BEPB.DataServiceReference
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Runtime.Serialization;

    [GeneratedCode("System.Runtime.Serialization", "4.0.0.0"), DataContract(Name="TB_Alert", Namespace="http://schemas.datacontract.org/2004/07/BEPB.Web", IsReference=true), DebuggerStepThrough]
    public class TB_Alert : EntityObject
    {
        private DateTime Date_TimeField;
        private int IDField;
        private string MContentField;
        private string PublisherField;
        private string TitleField;

        [DataMember]
        public DateTime Date_Time
        {
            get
            {
                return this.Date_TimeField;
            }
            set
            {
                if (!this.Date_TimeField.Equals(value))
                {
                    this.Date_TimeField = value;
                    base.RaisePropertyChanged("Date_Time");
                }
            }
        }

        [DataMember]
        public int ID
        {
            get
            {
                return this.IDField;
            }
            set
            {
                if (!this.IDField.Equals(value))
                {
                    this.IDField = value;
                    base.RaisePropertyChanged("ID");
                }
            }
        }

        [DataMember]
        public string MContent
        {
            get
            {
                return this.MContentField;
            }
            set
            {
                if (!object.ReferenceEquals(this.MContentField, value))
                {
                    this.MContentField = value;
                    base.RaisePropertyChanged("MContent");
                }
            }
        }

        [DataMember]
        public string Publisher
        {
            get
            {
                return this.PublisherField;
            }
            set
            {
                if (!object.ReferenceEquals(this.PublisherField, value))
                {
                    this.PublisherField = value;
                    base.RaisePropertyChanged("Publisher");
                }
            }
        }

        [DataMember]
        public string Title
        {
            get
            {
                return this.TitleField;
            }
            set
            {
                if (!object.ReferenceEquals(this.TitleField, value))
                {
                    this.TitleField = value;
                    base.RaisePropertyChanged("Title");
                }
            }
        }
    }
}

