namespace BEPB
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class AirDataContext : INotifyPropertyChanged
    {
        private bool _bCanZoomIn;
        private bool _bCanZoomOut;
        private Forecast _CurrentZoneForecast;
        private double _ZoomLevel;

        public event PropertyChangedEventHandler PropertyChanged;

        public AirDataContext()
        {
            this.bCanZoomIn = false;
            this.bCanZoomOut = false;
            this.MapConfig = new CMapConfig();
            this.AQIGroupNames = new List<string>();
            this.ForecastItemsSource = new ObservableCollection<Forecast>();
            this.ForecastItemsSource.Add(new Forecast("城六区", "--  --", "--  --"));
            this.ForecastItemsSource.Add(new Forecast("西北部", "--  --", "--  --"));
            this.ForecastItemsSource.Add(new Forecast("东北部", "--  --", "--  --"));
            this.ForecastItemsSource.Add(new Forecast("东南部", "--  --", "--  --"));
            this.ForecastItemsSource.Add(new Forecast("西南部", "--  --", "--  --"));
            this.WRWData24hList = new ObservableCollection<WRWData24h>();
        }

        public List<string> AQIGroupNames { get; set; }

        public bool bCanZoomIn
        {
            get
            {
                return this._bCanZoomIn;
            }
            set
            {
                this._bCanZoomIn = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("bCanZoomIn"));
                }
            }
        }

        public bool bCanZoomOut
        {
            get
            {
                return this._bCanZoomOut;
            }
            set
            {
                this._bCanZoomOut = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("bCanZoomOut"));
                }
            }
        }

        public Forecast CurrentZoneForecast
        {
            get
            {
                return this._CurrentZoneForecast;
            }
            set
            {
                this._CurrentZoneForecast = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("CurrentZoneForecast"));
                }
            }
        }

        public ObservableCollection<Forecast> ForecastItemsSource { get; set; }

        public CMapConfig MapConfig { get; set; }

        public ObservableCollection<WRWData24h> WRWData24hList { get; set; }

        public double ZoomLevel
        {
            get
            {
                return this._ZoomLevel;
            }
            set
            {
                this._ZoomLevel = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("ZoomLevel"));
                }
            }
        }
    }
}

