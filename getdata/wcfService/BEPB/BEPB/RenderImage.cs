namespace BEPB
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Media.Imaging;

    public class RenderImage
    {
        public RenderImage(BitmapImage Image, string Desc)
        {
            this.Image = Image;
            this.Desc = Desc;
        }

        public string Desc { get; set; }

        public BitmapImage Image { get; set; }
    }
}

