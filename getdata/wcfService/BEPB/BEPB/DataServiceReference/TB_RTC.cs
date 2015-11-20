namespace BEPB.DataServiceReference
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Runtime.Serialization;

    [DataContract(Name="TB_RTC", Namespace="http://schemas.datacontract.org/2004/07/BEPB.Web", IsReference=true), DebuggerStepThrough, GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
    public class TB_RTC : EntityObject
    {
        private string AQIField;
        private float? AVG24hField;
        private DateTime Date_TimeField;
        private int? Day8hMaxEvalField;
        private float? Day8hMaxValueField;
        private float? Day8hValueField;
        private int? DayMaxEvalField;
        private float? DayMaxValueField;
        private int? Eval24hField;
        private int? EvalField;
        private int IDField;
        private string PollutantField;
        private string PriPollutantField;
        private string PriPollutantMobileField;
        private string QLevelField;
        private string QualityField;
        private string StationField;
        private float? ValueField;

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
        public float? AVG24h
        {
            get
            {
                return this.AVG24hField;
            }
            set
            {
                if (!this.AVG24hField.Equals(value))
                {
                    this.AVG24hField = value;
                    base.RaisePropertyChanged("AVG24h");
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
        public int? Day8hMaxEval
        {
            get
            {
                return this.Day8hMaxEvalField;
            }
            set
            {
                if (!this.Day8hMaxEvalField.Equals(value))
                {
                    this.Day8hMaxEvalField = value;
                    base.RaisePropertyChanged("Day8hMaxEval");
                }
            }
        }

        [DataMember]
        public float? Day8hMaxValue
        {
            get
            {
                return this.Day8hMaxValueField;
            }
            set
            {
                if (!this.Day8hMaxValueField.Equals(value))
                {
                    this.Day8hMaxValueField = value;
                    base.RaisePropertyChanged("Day8hMaxValue");
                }
            }
        }

        [DataMember]
        public float? Day8hValue
        {
            get
            {
                return this.Day8hValueField;
            }
            set
            {
                if (!this.Day8hValueField.Equals(value))
                {
                    this.Day8hValueField = value;
                    base.RaisePropertyChanged("Day8hValue");
                }
            }
        }

        [DataMember]
        public int? DayMaxEval
        {
            get
            {
                return this.DayMaxEvalField;
            }
            set
            {
                if (!this.DayMaxEvalField.Equals(value))
                {
                    this.DayMaxEvalField = value;
                    base.RaisePropertyChanged("DayMaxEval");
                }
            }
        }

        [DataMember]
        public float? DayMaxValue
        {
            get
            {
                return this.DayMaxValueField;
            }
            set
            {
                if (!this.DayMaxValueField.Equals(value))
                {
                    this.DayMaxValueField = value;
                    base.RaisePropertyChanged("DayMaxValue");
                }
            }
        }

        [DataMember]
        public int? Eval
        {
            get
            {
                return this.EvalField;
            }
            set
            {
                if (!this.EvalField.Equals(value))
                {
                    this.EvalField = value;
                    base.RaisePropertyChanged("Eval");
                }
            }
        }

        [DataMember]
        public int? Eval24h
        {
            get
            {
                return this.Eval24hField;
            }
            set
            {
                if (!this.Eval24hField.Equals(value))
                {
                    this.Eval24hField = value;
                    base.RaisePropertyChanged("Eval24h");
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
        public string Pollutant
        {
            get
            {
                return this.PollutantField;
            }
            set
            {
                if (!object.ReferenceEquals(this.PollutantField, value))
                {
                    this.PollutantField = value;
                    base.RaisePropertyChanged("Pollutant");
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
        public string PriPollutantMobile
        {
            get
            {
                return this.PriPollutantMobileField;
            }
            set
            {
                if (!object.ReferenceEquals(this.PriPollutantMobileField, value))
                {
                    this.PriPollutantMobileField = value;
                    base.RaisePropertyChanged("PriPollutantMobile");
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
        public string Station
        {
            get
            {
                return this.StationField;
            }
            set
            {
                if (!object.ReferenceEquals(this.StationField, value))
                {
                    this.StationField = value;
                    base.RaisePropertyChanged("Station");
                }
            }
        }

        [DataMember]
        public float? Value
        {
            get
            {
                return this.ValueField;
            }
            set
            {
                if (!this.ValueField.Equals(value))
                {
                    this.ValueField = value;
                    base.RaisePropertyChanged("Value");
                }
            }
        }
    }
}

