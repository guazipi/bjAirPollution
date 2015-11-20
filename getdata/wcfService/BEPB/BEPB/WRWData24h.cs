namespace BEPB
{
    using System;
    using System.Runtime.CompilerServices;

    public class WRWData24h
    {
        public WRWData24h(string Station, string Pollutant, float? Value, DateTime Date_Time, float? AVG_Value)
        {
            this.Station = Station;
            this.Pollutant = Pollutant;
            this.Value = Value;
            this.Date_Time_Hour = Date_Time;
            this.AVG_Value = AVG_Value;
        }

        public float? AVG_Value { get; set; }

        public DateTime Date_Time_Hour { get; set; }

        public string Pollutant { get; set; }

        public string Station { get; set; }

        public float? Value { get; set; }
    }
}

