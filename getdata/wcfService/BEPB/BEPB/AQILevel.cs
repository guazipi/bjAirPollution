namespace BEPB
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Media;

    public class AQILevel
    {
        public AQILevel(SolidColorBrush AQIColor, string AQI, string Level, string AQIDesc, string Health, string suggest)
        {
            this.AQIColor = AQIColor;
            this.AQI = AQI;
            this.Level = Level;
            this.AQIDesc = AQIDesc;
            this.Health = Health;
            this.suggest = suggest;
        }

        public string AQI { get; set; }

        public SolidColorBrush AQIColor { get; set; }

        public string AQIDesc { get; set; }

        public string Health { get; set; }

        public string Level { get; set; }

        public string suggest { get; set; }
    }
}

