namespace BEPB
{
    using Microsoft.Maps.MapControl;
    using System;

    public class TiandituTileSource : TileSource
    {
        private BEPB.MapSource _MapSource;

        public TiandituTileSource()
        {
            base.UriFormat = "http://t{0}.tianditu.com/img_w/wmts?SERVICE=WMTS&REQUEST=GetTile&VERSION=1.0.0&LAYER=img&STYLE=default&TILEMATRIXSET=w&TILEMATRIX={3}&TILEROW={2}&TILECOL={1}&FORMAT=tiles";
            this.MapSource = BEPB.MapSource.IMG;
        }

        public override Uri GetUri(int x, int y, int zoomLevel)
        {
            return new Uri(string.Format(base.UriFormat, new object[] { x % 8, x, y, zoomLevel }));
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
                        base.UriFormat = "http://t{0}.tianditu.com/img_w/wmts?SERVICE=WMTS&REQUEST=GetTile&VERSION=1.0.0&LAYER=img&STYLE=default&TILEMATRIXSET=w&TILEMATRIX={3}&TILEROW={2}&TILECOL={1}&FORMAT=tiles";
                        return;

                    case BEPB.MapSource.TER:
                        base.UriFormat = "http://t{0}.tianditu.com/ter_w/wmts?SERVICE=WMTS&REQUEST=GetTile&VERSION=1.0.0&LAYER=ter&STYLE=default&TILEMATRIXSET=w&TILEMATRIX={3}&TILEROW={2}&TILECOL={1}&FORMAT=tiles";
                        return;

                    case BEPB.MapSource.VEC:
                        base.UriFormat = "http://t{0}.tianditu.com/vec_w/wmts?SERVICE=WMTS&REQUEST=GetTile&VERSION=1.0.0&LAYER=vec&STYLE=default&TILEMATRIXSET=w&TILEMATRIX={3}&TILEROW={2}&TILECOL={1}&FORMAT=tiles";
                        return;
                }
            }
        }
    }
}

