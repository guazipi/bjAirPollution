namespace BEPB
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Media;

    public class AlertDesc
    {
        public AlertDesc()
        {
        }

        public AlertDesc(SolidColorBrush AlertColor, string AlertLevel, string AlertDescText)
        {
            this.AlertColor = AlertColor;
            this.AlertLevel = AlertLevel;
            this.AlertDescText = AlertDescText;
        }

        public SolidColorBrush AlertColor { get; set; }

        public string AlertDescText { get; set; }

        public string AlertLevel { get; set; }
    }
}

