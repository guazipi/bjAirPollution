namespace BEPB
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows;
    using System.Windows.Browser;
    using System.Windows.Controls;
    using System.Windows.Media;

    public class App : Application
    {
        private bool _contentLoaded;
        public List<AlertDesc> AlertLevelDescsList = new List<AlertDesc>();
        public List<SolidColorBrush> AQILevelColorsList = new List<SolidColorBrush>();
        public bool bLocalMapImage;
        public TextBox MapRange;
        public List<StationData> StationsList = new List<StationData>();
        public int userCount;
        public string WebCountsText = "";

        public App()
        {
            base.add_Startup(new StartupEventHandler(this, (IntPtr) this.Application_Startup));
            base.add_Exit(new EventHandler(this.Application_Exit));
            base.add_UnhandledException(new EventHandler<ApplicationUnhandledExceptionEventArgs>(this.Application_UnhandledException));
            this.InitializeComponent();
        }

        private void Application_Exit(object sender, EventArgs e)
        {
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            this.userCount++;
            foreach (KeyValuePair<string, string> pair in e.get_InitParams())
            {
                if (pair.Key == "WebCountsText")
                {
                    this.WebCountsText = pair.Value;
                }
                else if (pair.Key == "LocalMapImage")
                {
                    if (pair.Value == "1")
                    {
                        this.bLocalMapImage = true;
                    }
                    else
                    {
                        this.bLocalMapImage = false;
                    }
                }
                else if (pair.Key == "AQILevelColors")
                {
                    foreach (string str in pair.Value.Split(new char[] { '/' }))
                    {
                        string[] strArray2 = str.Split(new char[] { ';' });
                        this.AQILevelColorsList.Add(new SolidColorBrush(Color.FromArgb(0xff, byte.Parse(strArray2[0]), byte.Parse(strArray2[1]), byte.Parse(strArray2[2]))));
                    }
                }
                else if (pair.Key.Contains("AlertLevelDesc"))
                {
                    AlertDesc item = new AlertDesc();
                    foreach (string str2 in pair.Value.Split(new char[] { '/' }))
                    {
                        string str4;
                        string[] source = str2.Split(new char[] { '=' });
                        if (((source != null) && (source.Count<string>() == 2)) && ((str4 = source[0]) != null))
                        {
                            if (!(str4 == "Color"))
                            {
                                if (str4 == "Name")
                                {
                                    goto Label_0229;
                                }
                                if (str4 == "Desc")
                                {
                                    goto Label_0236;
                                }
                            }
                            else
                            {
                                string[] strArray5 = source[1].Split(new char[] { ';' });
                                item.AlertColor = new SolidColorBrush(Color.FromArgb(0xff, byte.Parse(strArray5[0]), byte.Parse(strArray5[1]), byte.Parse(strArray5[2])));
                            }
                        }
                        continue;
                    Label_0229:
                        item.AlertLevel = source[1];
                        continue;
                    Label_0236:
                        item.AlertDescText = source[1];
                    }
                    this.AlertLevelDescsList.Add(item);
                }
                else
                {
                    StationData data = new StationData();
                    foreach (string str3 in pair.Value.Split(new char[] { ';' }))
                    {
                        string[] strArray7 = str3.Split(new char[] { '=' });
                        if ((strArray7 != null) && (strArray7.Count<string>() == 2))
                        {
                            switch (strArray7[0])
                            {
                                case "StationType":
                                    data.Group = strArray7[1];
                                    break;

                                case "Name":
                                    data.Station = strArray7[1];
                                    break;

                                case "ShortName":
                                    data.ShortName = strArray7[1];
                                    break;

                                case "Lat":
                                    data.Lat = Convert.ToDouble(strArray7[1]);
                                    break;

                                case "Lon":
                                    data.Lon = Convert.ToDouble(strArray7[1]);
                                    break;

                                case "Area":
                                    data.Area = strArray7[1];
                                    break;

                                case "Zone":
                                    data.Zone = strArray7[1];
                                    break;

                                case "AdminRegion":
                                    data.District = strArray7[1];
                                    break;
                            }
                        }
                    }
                    this.StationsList.Add(data);
                }
            }
            base.set_RootVisual(new MainPage());
        }

        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            Action action = null;
            if (!Debugger.IsAttached)
            {
                e.set_Handled(true);
                if (action == null)
                {
                    action = () => this.ReportErrorToDOM(e);
                }
                Deployment.get_Current().get_Dispatcher().BeginInvoke(action);
            }
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            if (!this._contentLoaded)
            {
                this._contentLoaded = true;
                Application.LoadComponent(this, new Uri("/BEPB;component/App.xaml", UriKind.Relative));
            }
        }

        private void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
        {
            try
            {
                string str = (e.get_ExceptionObject().Message + e.get_ExceptionObject().StackTrace).Replace('"', '\'').Replace("\r\n", @"\n");
                HtmlPage.get_Window().Eval("throw new Error(\"Unhandled Error in Silverlight Application " + str + "\");");
            }
            catch (Exception)
            {
            }
        }
    }
}

