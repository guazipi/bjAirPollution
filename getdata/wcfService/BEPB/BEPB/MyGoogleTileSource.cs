namespace BEPB
{
    using Microsoft.Maps.MapControl;
    using System;
    using System.Windows;

    public class MyGoogleTileSource : TileSource
    {
        public MyGoogleTileSource()
        {
            string absoluteUri = Application.get_Current().get_Host().get_Source().AbsoluteUri;
            if (absoluteUri.IndexOf("ClientBin") > 0)
            {
                base.UriFormat = absoluteUri.Substring(0, absoluteUri.IndexOf("ClientBin")) + "MapTiles/gs_{0}_{1}_{2}.png";
            }
            else
            {
                int num = absoluteUri.LastIndexOf("//");
                if (num > -1)
                {
                    absoluteUri = absoluteUri.Remove(num + 1);
                }
                base.UriFormat = absoluteUri + "MapTiles/gs_{0}_{1}_{2}.png";
            }
        }

        public override Uri GetUri(int x, int y, int zoomLevel)
        {
            return new Uri(string.Format(base.UriFormat, x, y, zoomLevel));
        }
    }
}

