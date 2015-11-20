namespace BEPB
{
    using System;
    using System.Runtime.CompilerServices;

    public class IAQIData
    {
        public IAQIData()
        {
            this.Pollutant = "--";
            this.IAQI = "--";
            this.Quality = "--";
        }

        public string IAQI { get; set; }

        public string Pollutant { get; set; }

        public string Quality { get; set; }
    }
}

