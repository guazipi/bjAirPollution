namespace BEPB
{
    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows;
    using System.Windows.Media;

    public class CMapConfig : INotifyPropertyChanged
    {
        private Brush _FiveBorderBrush;
        private Thickness _FiveBorderThickness;
        private string _FiveName;
        private double _FiveOpacity;

        public event PropertyChangedEventHandler PropertyChanged;

        public CMapConfig()
        {
            this.FiveBorderBrush = new SolidColorBrush(Colors.get_Red());
            this.FiveBorderThickness = new Thickness(5.0, 5.0, 5.0, 5.0);
            this.FiveName = "试验五大区";
            this.FiveOpacity = 1.0;
        }

        public Brush FiveBorderBrush
        {
            get
            {
                return this._FiveBorderBrush;
            }
            set
            {
                this._FiveBorderBrush = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("FiveBorderBrush"));
                }
            }
        }

        public Thickness FiveBorderThickness
        {
            get
            {
                return this._FiveBorderThickness;
            }
            set
            {
                this._FiveBorderThickness = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("FiveBorderThickness"));
                }
            }
        }

        public string FiveName
        {
            get
            {
                return this._FiveName;
            }
            set
            {
                this._FiveName = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("FiveName"));
                }
            }
        }

        public double FiveOpacity
        {
            get
            {
                return this._FiveOpacity;
            }
            set
            {
                this._FiveOpacity = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("FiveOpacity"));
                }
            }
        }
    }
}

