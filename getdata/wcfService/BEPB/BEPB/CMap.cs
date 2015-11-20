namespace BEPB
{
    using Microsoft.Maps.MapControl;
    using Microsoft.Maps.MapControl.Overlays;
    using System;
    using System.Windows;
    using System.Windows.Media;

    public class CMap : Map
    {
        public CMap()
        {
            EventHandler<LoadingErrorEventArgs> handler = null;
            if (handler == null)
            {
                handler = delegate (object sender, LoadingErrorEventArgs e) {
                    try
                    {
                        (VisualTreeHelper.GetChild(this, 0) as MapLayer).get_Children().Remove(VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(this, 0), 5) as LoadingErrorMessage);
                    }
                    catch
                    {
                    }
                };
            }
            this.LoadingError += handler;
        }

        protected override void OnFirstFrame()
        {
            BSMapMode mode = this.Mode as BSMapMode;
            if (mode != null)
            {
                mode.SetMapRange();
            }
        }

        protected override void OnZoomLevelChanged(DependencyPropertyChangedEventArgs eventArgs)
        {
            if (this.Mode is BSMapMode)
            {
                base.Focus();
                BSMapMode mode = this.Mode as BSMapMode;
                if (mode != null)
                {
                    if (mode.airDataContext != null)
                    {
                        mode.airDataContext.ZoomLevel = base.ZoomLevel;
                    }
                    mode.SetMapRange();
                }
            }
        }
    }
}

