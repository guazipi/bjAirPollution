namespace BEPB
{
    using Microsoft.Maps.MapControl;
    using Microsoft.Maps.MapControl.Core;
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows;

    public class BSMapMode : MercatorMode
    {
        public AirDataContext airDataContext;
        public bool bCanZoom = true;
        public bool bCanZoomIn = true;
        public bool bCanZoomOut;
        public double BeijingEast = 117.54;
        public double BeijingNorth = 41.1;
        public double BeijingSouth = 39.4;
        public double BeijingWest = 115.39;
        public Range<double> LatitudeRange;
        public double LeftFrameWidth;
        public Range<double> LongitudeRange;
        public double mapScale = 1.0;
        public Range<double> MapZoomRange;

        public BSMapMode(Range<double> ZoomRange)
        {
            this.MapZoomRange = ZoomRange;
        }

        public override bool ConstrainView(Location center, ref double zoomLevel, ref double heading, ref double pitch)
        {
            if ((this.LatitudeRange == null) || (this.LongitudeRange == null))
            {
                return false;
            }
            bool flag = false;
            if (center.Latitude < this.LatitudeRange.From)
            {
                center.Latitude = this.LatitudeRange.From;
                flag = true;
            }
            if (center.Latitude > this.LatitudeRange.To)
            {
                center.Latitude = this.LatitudeRange.To;
                flag = true;
            }
            if (center.Longitude < this.LongitudeRange.From)
            {
                center.Longitude = this.LongitudeRange.From;
                flag = true;
            }
            if (center.Longitude > this.LongitudeRange.To)
            {
                center.Longitude = this.LongitudeRange.To;
                flag = true;
            }
            return flag;
        }

        protected override Range<double> GetZoomRange(Location center)
        {
            return this.MapZoomRange;
        }

        public override void OnMouseDoubleClick(MapMouseEventArgs e)
        {
            if (this.bCanZoom && (this.ZoomLevel < this.MapZoomRange.To))
            {
                base.OnMouseDoubleClick(e);
                if (this.ZoomLevel < this.MapZoomRange.To)
                {
                    this.bCanZoomIn = true;
                }
                else
                {
                    this.bCanZoomIn = false;
                }
                if (this.ZoomLevel > this.MapZoomRange.From)
                {
                    this.bCanZoomOut = true;
                }
                else
                {
                    this.bCanZoomOut = false;
                }
                if (this.airDataContext != null)
                {
                    this.airDataContext.bCanZoomIn = this.bCanZoomIn;
                    this.airDataContext.bCanZoomOut = this.bCanZoomOut;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        public override void OnMouseWheel(MapMouseWheelEventArgs e)
        {
            if (((e.WheelDelta > 0.0) && (this.ZoomLevel >= this.MapZoomRange.To)) || ((e.WheelDelta < 0.0) && (this.ZoomLevel <= this.MapZoomRange.From)))
            {
                e.Handled = true;
            }
            else if (e.WheelDelta > 0.0)
            {
                this.ZoomIn();
            }
            else if (e.WheelDelta < 0.0)
            {
                this.ZoomOut();
            }
        }

        public void SetMapRange()
        {
            double latitude = this.Center.Latitude;
            double toValue = this.Center.Latitude;
            double longitude = this.Center.Longitude;
            double num4 = this.Center.Longitude;
            double num5 = 0.0;
            if (this.LeftFrameWidth > 0.0)
            {
                Location location2 = this.ViewportPointToLocation(new Point(0.0, 0.0));
                num5 = (this.ViewportPointToLocation(new Point(this.LeftFrameWidth, 0.0)).Longitude - location2.Longitude) / this.mapScale;
            }
            LocationRect rect = new LocationRect {
                West = this.BoundingRectangle.West,
                North = this.BoundingRectangle.North,
                East = this.BoundingRectangle.West + (this.BoundingRectangle.Width / this.mapScale),
                South = this.BoundingRectangle.North - (this.BoundingRectangle.Height / this.mapScale)
            };
            if ((this.BeijingNorth - this.BeijingSouth) < rect.Height)
            {
                latitude = this.Center.Latitude - (rect.North - this.BeijingNorth);
                toValue = this.Center.Latitude + (this.BeijingSouth - rect.South);
            }
            else
            {
                latitude = this.Center.Latitude - (rect.South - this.BeijingSouth);
                toValue = this.Center.Latitude + (this.BeijingNorth - rect.North);
            }
            if ((this.BeijingEast - this.BeijingWest) < (rect.Width - num5))
            {
                longitude = this.Center.Longitude - (rect.East - this.BeijingEast);
                num4 = this.Center.Longitude + (this.BeijingWest - rect.West);
            }
            else
            {
                longitude = (this.Center.Longitude - (rect.West - this.BeijingWest)) - num5;
                num4 = this.Center.Longitude + (this.BeijingEast - rect.East);
            }
            this.LatitudeRange = new Range<double>(latitude, toValue);
            this.LongitudeRange = new Range<double>(longitude, num4);
        }

        public void ZoomHome(bool bAnimating)
        {
            this.SetView(this.HomeCenter, this.HomeLevel, 0.0, 0.0, bAnimating);
            if (this.ZoomLevel < this.MapZoomRange.To)
            {
                this.bCanZoomIn = true;
            }
            else
            {
                this.bCanZoomIn = false;
            }
            if (this.ZoomLevel > this.MapZoomRange.From)
            {
                this.bCanZoomOut = true;
            }
            else
            {
                this.bCanZoomOut = false;
            }
            if (this.airDataContext != null)
            {
                this.airDataContext.bCanZoomIn = this.bCanZoomIn;
                this.airDataContext.bCanZoomOut = this.bCanZoomOut;
            }
        }

        public void ZoomIn()
        {
            if (this.bCanZoom && (this.ZoomLevel < this.MapZoomRange.To))
            {
                this.ZoomLevel++;
                if (this.ZoomLevel < this.MapZoomRange.To)
                {
                    this.bCanZoomIn = true;
                }
                else
                {
                    this.bCanZoomIn = false;
                }
                this.bCanZoomOut = true;
                if (this.airDataContext != null)
                {
                    this.airDataContext.bCanZoomIn = this.bCanZoomIn;
                    this.airDataContext.bCanZoomOut = this.bCanZoomOut;
                }
            }
        }

        public void ZoomOut()
        {
            if (this.ZoomLevel > this.MapZoomRange.From)
            {
                this.ZoomLevel--;
                if (this.ZoomLevel > this.MapZoomRange.From)
                {
                    this.bCanZoomOut = true;
                }
                else
                {
                    this.bCanZoomOut = false;
                }
                this.bCanZoomIn = true;
                if (this.airDataContext != null)
                {
                    this.airDataContext.bCanZoomIn = this.bCanZoomIn;
                    this.airDataContext.bCanZoomOut = this.bCanZoomOut;
                }
            }
        }

        public void ZoomTo(double ZoomLevel)
        {
            if (((this.MapZoomRange.From <= ZoomLevel) && (ZoomLevel <= this.MapZoomRange.To)) && (this.ZoomLevel != ZoomLevel))
            {
                this.ZoomLevel = ZoomLevel;
                if (this.ZoomLevel < this.MapZoomRange.To)
                {
                    this.bCanZoomIn = true;
                }
                else
                {
                    this.bCanZoomIn = false;
                }
                if (this.ZoomLevel > this.MapZoomRange.From)
                {
                    this.bCanZoomOut = true;
                }
                else
                {
                    this.bCanZoomOut = false;
                }
                if (this.airDataContext != null)
                {
                    this.airDataContext.bCanZoomIn = this.bCanZoomIn;
                    this.airDataContext.bCanZoomOut = this.bCanZoomOut;
                }
            }
        }

        public Location HomeCenter { get; set; }

        public double HomeLevel { get; set; }
    }
}

