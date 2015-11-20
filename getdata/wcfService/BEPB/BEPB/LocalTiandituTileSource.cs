namespace BEPB
{
    using Microsoft.Maps.MapControl;
    using System;
    using System.Windows;

    public class LocalTiandituTileSource : TileSource
    {
        private BEPB.MapSource _MapSource;

        public LocalTiandituTileSource()
        {
            base.UriFormat = new Uri(Application.get_Current().get_Host().get_Source(), "../MapTiles").AbsoluteUri + "/IMG/Tianditu_{0}_{1}_{2}.png";
            this.MapSource = BEPB.MapSource.IMG;
        }

        public override Uri GetUri(int x, int y, int zoomLevel)
        {
            return new Uri(string.Format(base.UriFormat, x, y, zoomLevel));
        }

        public BEPB.MapSource MapSource
        {
            get
            {
                return this._MapSource;
            }
            set
            {
                this._MapSource = value;
                switch (this._MapSource)
                {
                    case BEPB.MapSource.IMG:
                        base.UriFormat = new Uri(Application.get_Current().get_Host().get_Source(), "../MapTiles").AbsoluteUri + "/IMG/Tianditu_{0}_{1}_{2}.png";
                        return;

                    case BEPB.MapSource.TER:
                        base.UriFormat = new Uri(Application.get_Current().get_Host().get_Source(), "../MapTiles").AbsoluteUri + "/TER/Tianditu_{0}_{1}_{2}.png";
                        return;

                    case BEPB.MapSource.VEC:
                        base.UriFormat = new Uri(Application.get_Current().get_Host().get_Source(), "../MapTiles").AbsoluteUri + "/VEC/Tianditu_{0}_{1}_{2}.png";
                        return;
                }
            }
        }
    }
}

