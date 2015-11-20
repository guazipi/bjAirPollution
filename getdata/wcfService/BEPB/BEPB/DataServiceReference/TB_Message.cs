namespace BEPB.DataServiceReference
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Runtime.Serialization;

    [GeneratedCode("System.Runtime.Serialization", "4.0.0.0"), DebuggerStepThrough, DataContract(Name="TB_Message", Namespace="http://schemas.datacontract.org/2004/07/BEPB.Web", IsReference=true)]
    public class TB_Message : EntityObject
    {
        private string AQIField;
        private DateTime Date_TimeField;
        private string DescriptionField;
        private int IDField;
        private string PriPollutantField;
        private string PromptField;
        private string QLevelField;
        private string QualityField;
        private string zoneField;

        [DataMember]
        public string AQI
        {
            get
            {
                return this.AQIField;
            }
            set
            {
                if (!object.ReferenceEquals(this.AQIField, value))
                {
                    this.AQIField = value;
                    base.RaisePropertyChanged("AQI");
                }
            }
        }

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
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                if (!object.ReferenceEquals(this.DescriptionField, value))
                {
                    this.DescriptionField = value;
                    base.RaisePropertyChanged("Description");
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
        public string PriPollutant
        {
            get
            {
                return this.PriPollutantField;
            }
            set
            {
                if (!object.ReferenceEquals(this.PriPollutantField, value))
                {
                    this.PriPollutantField = value;
                    base.RaisePropertyChanged("PriPollutant");
                }
            }
        }

        [DataMember]
        public string Prompt
        {
            get
            {
                return this.PromptField;
            }
            set
            {
                if (!object.ReferenceEquals(this.PromptField, value))
                {
                    this.PromptField = value;
                    base.RaisePropertyChanged("Prompt");
                }
            }
        }

        [DataMember]
        public string QLevel
        {
            get
            {
                return this.QLevelField;
            }
            set
            {
                if (!object.ReferenceEquals(this.QLevelField, value))
                {
                    this.QLevelField = value;
                    base.RaisePropertyChanged("QLevel");
                }
            }
        }

        [DataMember]
        public string Quality
        {
            get
            {
                return this.QualityField;
            }
            set
            {
                if (!object.ReferenceEquals(this.QualityField, value))
                {
                    this.QualityField = value;
                    base.RaisePropertyChanged("Quality");
                }
            }
        }

        [DataMember]
        public string zone
        {
            get
            {
                return this.zoneField;
            }
            set
            {
                if (!object.ReferenceEquals(this.zoneField, value))
                {
                    this.zoneField = value;
                    base.RaisePropertyChanged("zone");
                }
            }
        }
    }
}

