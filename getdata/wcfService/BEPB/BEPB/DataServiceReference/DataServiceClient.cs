namespace BEPB.DataServiceReference
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Net;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Threading;

    [DebuggerStepThrough, GeneratedCode("System.ServiceModel", "4.0.0.0")]
    public class DataServiceClient : ClientBase<DataService>, DataService
    {
        private ClientBase<DataService>.BeginOperationDelegate onBeginCloseDelegate;
        private ClientBase<DataService>.BeginOperationDelegate onBeginDayForecastDelegate;
        private ClientBase<DataService>.BeginOperationDelegate onBeginGetAlertDelegate;
        private ClientBase<DataService>.BeginOperationDelegate onBeginGetRTC24hDelegate;
        private ClientBase<DataService>.BeginOperationDelegate onBeginGetRTCDelegate;
        private ClientBase<DataService>.BeginOperationDelegate onBeginGetWebAlertDelegate;
        private ClientBase<DataService>.BeginOperationDelegate onBeginGetWebCountsDelegate;
        private ClientBase<DataService>.BeginOperationDelegate onBeginGetWebDataDelegate;
        private ClientBase<DataService>.BeginOperationDelegate onBeginGetWebPredictDelegate;
        private ClientBase<DataService>.BeginOperationDelegate onBeginOpenDelegate;
        private SendOrPostCallback onCloseCompletedDelegate;
        private SendOrPostCallback onDayForecastCompletedDelegate;
        private ClientBase<DataService>.EndOperationDelegate onEndCloseDelegate;
        private ClientBase<DataService>.EndOperationDelegate onEndDayForecastDelegate;
        private ClientBase<DataService>.EndOperationDelegate onEndGetAlertDelegate;
        private ClientBase<DataService>.EndOperationDelegate onEndGetRTC24hDelegate;
        private ClientBase<DataService>.EndOperationDelegate onEndGetRTCDelegate;
        private ClientBase<DataService>.EndOperationDelegate onEndGetWebAlertDelegate;
        private ClientBase<DataService>.EndOperationDelegate onEndGetWebCountsDelegate;
        private ClientBase<DataService>.EndOperationDelegate onEndGetWebDataDelegate;
        private ClientBase<DataService>.EndOperationDelegate onEndGetWebPredictDelegate;
        private ClientBase<DataService>.EndOperationDelegate onEndOpenDelegate;
        private SendOrPostCallback onGetAlertCompletedDelegate;
        private SendOrPostCallback onGetRTC24hCompletedDelegate;
        private SendOrPostCallback onGetRTCCompletedDelegate;
        private SendOrPostCallback onGetWebAlertCompletedDelegate;
        private SendOrPostCallback onGetWebCountsCompletedDelegate;
        private SendOrPostCallback onGetWebDataCompletedDelegate;
        private SendOrPostCallback onGetWebPredictCompletedDelegate;
        private SendOrPostCallback onOpenCompletedDelegate;

        public event EventHandler<AsyncCompletedEventArgs> CloseCompleted;

        public event EventHandler<DayForecastCompletedEventArgs> DayForecastCompleted;

        public event EventHandler<GetAlertCompletedEventArgs> GetAlertCompleted;

        public event EventHandler<GetRTC24hCompletedEventArgs> GetRTC24hCompleted;

        public event EventHandler<GetRTCCompletedEventArgs> GetRTCCompleted;

        public event EventHandler<GetWebAlertCompletedEventArgs> GetWebAlertCompleted;

        public event EventHandler<GetWebCountsCompletedEventArgs> GetWebCountsCompleted;

        public event EventHandler<GetWebDataCompletedEventArgs> GetWebDataCompleted;

        public event EventHandler<GetWebPredictCompletedEventArgs> GetWebPredictCompleted;

        public event EventHandler<AsyncCompletedEventArgs> OpenCompleted;

        public DataServiceClient()
        {
        }

        public DataServiceClient(string endpointConfigurationName) : base(endpointConfigurationName)
        {
        }

        public DataServiceClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
        {
        }

        public DataServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
        {
        }

        public DataServiceClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        IAsyncResult DataService.BeginDayForecast(AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginDayForecast(callback, asyncState);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        IAsyncResult DataService.BeginGetAlert(AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginGetAlert(callback, asyncState);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        IAsyncResult DataService.BeginGetRTC(AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginGetRTC(callback, asyncState);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        IAsyncResult DataService.BeginGetRTC24h(string Station, string Pollutant, AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginGetRTC24h(Station, Pollutant, callback, asyncState);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        IAsyncResult DataService.BeginGetWebAlert(AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginGetWebAlert(callback, asyncState);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        IAsyncResult DataService.BeginGetWebCounts(AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginGetWebCounts(callback, asyncState);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        IAsyncResult DataService.BeginGetWebData(AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginGetWebData(callback, asyncState);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        IAsyncResult DataService.BeginGetWebPredict(AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginGetWebPredict(callback, asyncState);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        List<TB_Message> DataService.EndDayForecast(IAsyncResult result)
        {
            return base.Channel.EndDayForecast(result);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        List<TB_Alert> DataService.EndGetAlert(IAsyncResult result)
        {
            return base.Channel.EndGetAlert(result);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        List<TB_RTC> DataService.EndGetRTC(IAsyncResult result)
        {
            return base.Channel.EndGetRTC(result);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        List<TB_RTC> DataService.EndGetRTC24h(IAsyncResult result)
        {
            return base.Channel.EndGetRTC24h(result);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        string DataService.EndGetWebAlert(IAsyncResult result)
        {
            return base.Channel.EndGetWebAlert(result);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        string DataService.EndGetWebCounts(IAsyncResult result)
        {
            return base.Channel.EndGetWebCounts(result);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        string DataService.EndGetWebData(IAsyncResult result)
        {
            return base.Channel.EndGetWebData(result);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        string DataService.EndGetWebPredict(IAsyncResult result)
        {
            return base.Channel.EndGetWebPredict(result);
        }

        public void CloseAsync()
        {
            this.CloseAsync(null);
        }

        public void CloseAsync(object userState)
        {
            if (this.onBeginCloseDelegate == null)
            {
                this.onBeginCloseDelegate = new ClientBase<DataService>.BeginOperationDelegate(this.OnBeginClose);
            }
            if (this.onEndCloseDelegate == null)
            {
                this.onEndCloseDelegate = new ClientBase<DataService>.EndOperationDelegate(this.OnEndClose);
            }
            if (this.onCloseCompletedDelegate == null)
            {
                this.onCloseCompletedDelegate = new SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }

        protected override DataService CreateChannel()
        {
            return new DataServiceClientChannel(this);
        }

        public void DayForecastAsync()
        {
            this.DayForecastAsync(null);
        }

        public void DayForecastAsync(object userState)
        {
            if (this.onBeginDayForecastDelegate == null)
            {
                this.onBeginDayForecastDelegate = new ClientBase<DataService>.BeginOperationDelegate(this.OnBeginDayForecast);
            }
            if (this.onEndDayForecastDelegate == null)
            {
                this.onEndDayForecastDelegate = new ClientBase<DataService>.EndOperationDelegate(this.OnEndDayForecast);
            }
            if (this.onDayForecastCompletedDelegate == null)
            {
                this.onDayForecastCompletedDelegate = new SendOrPostCallback(this.OnDayForecastCompleted);
            }
            base.InvokeAsync(this.onBeginDayForecastDelegate, null, this.onEndDayForecastDelegate, this.onDayForecastCompletedDelegate, userState);
        }

        public void GetAlertAsync()
        {
            this.GetAlertAsync(null);
        }

        public void GetAlertAsync(object userState)
        {
            if (this.onBeginGetAlertDelegate == null)
            {
                this.onBeginGetAlertDelegate = new ClientBase<DataService>.BeginOperationDelegate(this.OnBeginGetAlert);
            }
            if (this.onEndGetAlertDelegate == null)
            {
                this.onEndGetAlertDelegate = new ClientBase<DataService>.EndOperationDelegate(this.OnEndGetAlert);
            }
            if (this.onGetAlertCompletedDelegate == null)
            {
                this.onGetAlertCompletedDelegate = new SendOrPostCallback(this.OnGetAlertCompleted);
            }
            base.InvokeAsync(this.onBeginGetAlertDelegate, null, this.onEndGetAlertDelegate, this.onGetAlertCompletedDelegate, userState);
        }

        public void GetRTC24hAsync(string Station, string Pollutant)
        {
            this.GetRTC24hAsync(Station, Pollutant, null);
        }

        public void GetRTC24hAsync(string Station, string Pollutant, object userState)
        {
            if (this.onBeginGetRTC24hDelegate == null)
            {
                this.onBeginGetRTC24hDelegate = new ClientBase<DataService>.BeginOperationDelegate(this.OnBeginGetRTC24h);
            }
            if (this.onEndGetRTC24hDelegate == null)
            {
                this.onEndGetRTC24hDelegate = new ClientBase<DataService>.EndOperationDelegate(this.OnEndGetRTC24h);
            }
            if (this.onGetRTC24hCompletedDelegate == null)
            {
                this.onGetRTC24hCompletedDelegate = new SendOrPostCallback(this.OnGetRTC24hCompleted);
            }
            base.InvokeAsync(this.onBeginGetRTC24hDelegate, new object[] { Station, Pollutant }, this.onEndGetRTC24hDelegate, this.onGetRTC24hCompletedDelegate, userState);
        }

        public void GetRTCAsync()
        {
            this.GetRTCAsync(null);
        }

        public void GetRTCAsync(object userState)
        {
            if (this.onBeginGetRTCDelegate == null)
            {
                this.onBeginGetRTCDelegate = new ClientBase<DataService>.BeginOperationDelegate(this.OnBeginGetRTC);
            }
            if (this.onEndGetRTCDelegate == null)
            {
                this.onEndGetRTCDelegate = new ClientBase<DataService>.EndOperationDelegate(this.OnEndGetRTC);
            }
            if (this.onGetRTCCompletedDelegate == null)
            {
                this.onGetRTCCompletedDelegate = new SendOrPostCallback(this.OnGetRTCCompleted);
            }
            base.InvokeAsync(this.onBeginGetRTCDelegate, null, this.onEndGetRTCDelegate, this.onGetRTCCompletedDelegate, userState);
        }

        public void GetWebAlertAsync()
        {
            this.GetWebAlertAsync(null);
        }

        public void GetWebAlertAsync(object userState)
        {
            if (this.onBeginGetWebAlertDelegate == null)
            {
                this.onBeginGetWebAlertDelegate = new ClientBase<DataService>.BeginOperationDelegate(this.OnBeginGetWebAlert);
            }
            if (this.onEndGetWebAlertDelegate == null)
            {
                this.onEndGetWebAlertDelegate = new ClientBase<DataService>.EndOperationDelegate(this.OnEndGetWebAlert);
            }
            if (this.onGetWebAlertCompletedDelegate == null)
            {
                this.onGetWebAlertCompletedDelegate = new SendOrPostCallback(this.OnGetWebAlertCompleted);
            }
            base.InvokeAsync(this.onBeginGetWebAlertDelegate, null, this.onEndGetWebAlertDelegate, this.onGetWebAlertCompletedDelegate, userState);
        }

        public void GetWebCountsAsync()
        {
            this.GetWebCountsAsync(null);
        }

        public void GetWebCountsAsync(object userState)
        {
            if (this.onBeginGetWebCountsDelegate == null)
            {
                this.onBeginGetWebCountsDelegate = new ClientBase<DataService>.BeginOperationDelegate(this.OnBeginGetWebCounts);
            }
            if (this.onEndGetWebCountsDelegate == null)
            {
                this.onEndGetWebCountsDelegate = new ClientBase<DataService>.EndOperationDelegate(this.OnEndGetWebCounts);
            }
            if (this.onGetWebCountsCompletedDelegate == null)
            {
                this.onGetWebCountsCompletedDelegate = new SendOrPostCallback(this.OnGetWebCountsCompleted);
            }
            base.InvokeAsync(this.onBeginGetWebCountsDelegate, null, this.onEndGetWebCountsDelegate, this.onGetWebCountsCompletedDelegate, userState);
        }

        public void GetWebDataAsync()
        {
            this.GetWebDataAsync(null);
        }

        public void GetWebDataAsync(object userState)
        {
            if (this.onBeginGetWebDataDelegate == null)
            {
                this.onBeginGetWebDataDelegate = new ClientBase<DataService>.BeginOperationDelegate(this.OnBeginGetWebData);
            }
            if (this.onEndGetWebDataDelegate == null)
            {
                this.onEndGetWebDataDelegate = new ClientBase<DataService>.EndOperationDelegate(this.OnEndGetWebData);
            }
            if (this.onGetWebDataCompletedDelegate == null)
            {
                this.onGetWebDataCompletedDelegate = new SendOrPostCallback(this.OnGetWebDataCompleted);
            }
            base.InvokeAsync(this.onBeginGetWebDataDelegate, null, this.onEndGetWebDataDelegate, this.onGetWebDataCompletedDelegate, userState);
        }

        public void GetWebPredictAsync()
        {
            this.GetWebPredictAsync(null);
        }

        public void GetWebPredictAsync(object userState)
        {
            if (this.onBeginGetWebPredictDelegate == null)
            {
                this.onBeginGetWebPredictDelegate = new ClientBase<DataService>.BeginOperationDelegate(this.OnBeginGetWebPredict);
            }
            if (this.onEndGetWebPredictDelegate == null)
            {
                this.onEndGetWebPredictDelegate = new ClientBase<DataService>.EndOperationDelegate(this.OnEndGetWebPredict);
            }
            if (this.onGetWebPredictCompletedDelegate == null)
            {
                this.onGetWebPredictCompletedDelegate = new SendOrPostCallback(this.OnGetWebPredictCompleted);
            }
            base.InvokeAsync(this.onBeginGetWebPredictDelegate, null, this.onEndGetWebPredictDelegate, this.onGetWebPredictCompletedDelegate, userState);
        }

        private IAsyncResult OnBeginClose(object[] inValues, AsyncCallback callback, object asyncState)
        {
            return this.BeginClose(callback, asyncState);
        }

        private IAsyncResult OnBeginDayForecast(object[] inValues, AsyncCallback callback, object asyncState)
        {
            return ((DataService) this).BeginDayForecast(callback, asyncState);
        }

        private IAsyncResult OnBeginGetAlert(object[] inValues, AsyncCallback callback, object asyncState)
        {
            return ((DataService) this).BeginGetAlert(callback, asyncState);
        }

        private IAsyncResult OnBeginGetRTC(object[] inValues, AsyncCallback callback, object asyncState)
        {
            return ((DataService) this).BeginGetRTC(callback, asyncState);
        }

        private IAsyncResult OnBeginGetRTC24h(object[] inValues, AsyncCallback callback, object asyncState)
        {
            string station = (string) inValues[0];
            string pollutant = (string) inValues[1];
            return ((DataService) this).BeginGetRTC24h(station, pollutant, callback, asyncState);
        }

        private IAsyncResult OnBeginGetWebAlert(object[] inValues, AsyncCallback callback, object asyncState)
        {
            return ((DataService) this).BeginGetWebAlert(callback, asyncState);
        }

        private IAsyncResult OnBeginGetWebCounts(object[] inValues, AsyncCallback callback, object asyncState)
        {
            return ((DataService) this).BeginGetWebCounts(callback, asyncState);
        }

        private IAsyncResult OnBeginGetWebData(object[] inValues, AsyncCallback callback, object asyncState)
        {
            return ((DataService) this).BeginGetWebData(callback, asyncState);
        }

        private IAsyncResult OnBeginGetWebPredict(object[] inValues, AsyncCallback callback, object asyncState)
        {
            return ((DataService) this).BeginGetWebPredict(callback, asyncState);
        }

        private IAsyncResult OnBeginOpen(object[] inValues, AsyncCallback callback, object asyncState)
        {
            return this.BeginOpen(callback, asyncState);
        }

        private void OnCloseCompleted(object state)
        {
            if (this.CloseCompleted != null)
            {
                ClientBase<DataService>.InvokeAsyncCompletedEventArgs args = (ClientBase<DataService>.InvokeAsyncCompletedEventArgs) state;
                this.CloseCompleted(this, new AsyncCompletedEventArgs(args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnDayForecastCompleted(object state)
        {
            if (this.DayForecastCompleted != null)
            {
                ClientBase<DataService>.InvokeAsyncCompletedEventArgs args = (ClientBase<DataService>.InvokeAsyncCompletedEventArgs) state;
                this.DayForecastCompleted(this, new DayForecastCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private object[] OnEndClose(IAsyncResult result)
        {
            this.EndClose(result);
            return null;
        }

        private object[] OnEndDayForecast(IAsyncResult result)
        {
            List<TB_Message> list = ((DataService) this).EndDayForecast(result);
            return new object[] { list };
        }

        private object[] OnEndGetAlert(IAsyncResult result)
        {
            List<TB_Alert> list = ((DataService) this).EndGetAlert(result);
            return new object[] { list };
        }

        private object[] OnEndGetRTC(IAsyncResult result)
        {
            List<TB_RTC> list = ((DataService) this).EndGetRTC(result);
            return new object[] { list };
        }

        private object[] OnEndGetRTC24h(IAsyncResult result)
        {
            List<TB_RTC> list = ((DataService) this).EndGetRTC24h(result);
            return new object[] { list };
        }

        private object[] OnEndGetWebAlert(IAsyncResult result)
        {
            string str = ((DataService) this).EndGetWebAlert(result);
            return new object[] { str };
        }

        private object[] OnEndGetWebCounts(IAsyncResult result)
        {
            string str = ((DataService) this).EndGetWebCounts(result);
            return new object[] { str };
        }

        private object[] OnEndGetWebData(IAsyncResult result)
        {
            string str = ((DataService) this).EndGetWebData(result);
            return new object[] { str };
        }

        private object[] OnEndGetWebPredict(IAsyncResult result)
        {
            string str = ((DataService) this).EndGetWebPredict(result);
            return new object[] { str };
        }

        private object[] OnEndOpen(IAsyncResult result)
        {
            this.EndOpen(result);
            return null;
        }

        private void OnGetAlertCompleted(object state)
        {
            if (this.GetAlertCompleted != null)
            {
                ClientBase<DataService>.InvokeAsyncCompletedEventArgs args = (ClientBase<DataService>.InvokeAsyncCompletedEventArgs) state;
                this.GetAlertCompleted(this, new GetAlertCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnGetRTC24hCompleted(object state)
        {
            if (this.GetRTC24hCompleted != null)
            {
                ClientBase<DataService>.InvokeAsyncCompletedEventArgs args = (ClientBase<DataService>.InvokeAsyncCompletedEventArgs) state;
                this.GetRTC24hCompleted(this, new GetRTC24hCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnGetRTCCompleted(object state)
        {
            if (this.GetRTCCompleted != null)
            {
                ClientBase<DataService>.InvokeAsyncCompletedEventArgs args = (ClientBase<DataService>.InvokeAsyncCompletedEventArgs) state;
                this.GetRTCCompleted(this, new GetRTCCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnGetWebAlertCompleted(object state)
        {
            if (this.GetWebAlertCompleted != null)
            {
                ClientBase<DataService>.InvokeAsyncCompletedEventArgs args = (ClientBase<DataService>.InvokeAsyncCompletedEventArgs) state;
                this.GetWebAlertCompleted(this, new GetWebAlertCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnGetWebCountsCompleted(object state)
        {
            if (this.GetWebCountsCompleted != null)
            {
                ClientBase<DataService>.InvokeAsyncCompletedEventArgs args = (ClientBase<DataService>.InvokeAsyncCompletedEventArgs) state;
                this.GetWebCountsCompleted(this, new GetWebCountsCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnGetWebDataCompleted(object state)
        {
            if (this.GetWebDataCompleted != null)
            {
                ClientBase<DataService>.InvokeAsyncCompletedEventArgs args = (ClientBase<DataService>.InvokeAsyncCompletedEventArgs) state;
                this.GetWebDataCompleted(this, new GetWebDataCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnGetWebPredictCompleted(object state)
        {
            if (this.GetWebPredictCompleted != null)
            {
                ClientBase<DataService>.InvokeAsyncCompletedEventArgs args = (ClientBase<DataService>.InvokeAsyncCompletedEventArgs) state;
                this.GetWebPredictCompleted(this, new GetWebPredictCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnOpenCompleted(object state)
        {
            if (this.OpenCompleted != null)
            {
                ClientBase<DataService>.InvokeAsyncCompletedEventArgs args = (ClientBase<DataService>.InvokeAsyncCompletedEventArgs) state;
                this.OpenCompleted(this, new AsyncCompletedEventArgs(args.Error, args.Cancelled, args.UserState));
            }
        }

        public void OpenAsync()
        {
            this.OpenAsync(null);
        }

        public void OpenAsync(object userState)
        {
            if (this.onBeginOpenDelegate == null)
            {
                this.onBeginOpenDelegate = new ClientBase<DataService>.BeginOperationDelegate(this.OnBeginOpen);
            }
            if (this.onEndOpenDelegate == null)
            {
                this.onEndOpenDelegate = new ClientBase<DataService>.EndOperationDelegate(this.OnEndOpen);
            }
            if (this.onOpenCompletedDelegate == null)
            {
                this.onOpenCompletedDelegate = new SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }

        public System.Net.CookieContainer CookieContainer
        {
            get
            {
                IHttpCookieContainerManager property = base.InnerChannel.GetProperty<IHttpCookieContainerManager>();
                if (property != null)
                {
                    return property.get_CookieContainer();
                }
                return null;
            }
            set
            {
                IHttpCookieContainerManager property = base.InnerChannel.GetProperty<IHttpCookieContainerManager>();
                if (property == null)
                {
                    throw new InvalidOperationException("无法设置 CookieContainer。请确保绑定包含 HttpCookieContainerBindingElement。");
                }
                property.set_CookieContainer(value);
            }
        }

        private class DataServiceClientChannel : ClientBase<DataService>.ChannelBase<DataService>, DataService
        {
            public DataServiceClientChannel(ClientBase<DataService> client) : base(client)
            {
            }

            public IAsyncResult BeginDayForecast(AsyncCallback callback, object asyncState)
            {
                object[] args = new object[0];
                return base.BeginInvoke("DayForecast", args, callback, asyncState);
            }

            public IAsyncResult BeginGetAlert(AsyncCallback callback, object asyncState)
            {
                object[] args = new object[0];
                return base.BeginInvoke("GetAlert", args, callback, asyncState);
            }

            public IAsyncResult BeginGetRTC(AsyncCallback callback, object asyncState)
            {
                object[] args = new object[0];
                return base.BeginInvoke("GetRTC", args, callback, asyncState);
            }

            public IAsyncResult BeginGetRTC24h(string Station, string Pollutant, AsyncCallback callback, object asyncState)
            {
                object[] args = new object[] { Station, Pollutant };
                return base.BeginInvoke("GetRTC24h", args, callback, asyncState);
            }

            public IAsyncResult BeginGetWebAlert(AsyncCallback callback, object asyncState)
            {
                object[] args = new object[0];
                return base.BeginInvoke("GetWebAlert", args, callback, asyncState);
            }

            public IAsyncResult BeginGetWebCounts(AsyncCallback callback, object asyncState)
            {
                object[] args = new object[0];
                return base.BeginInvoke("GetWebCounts", args, callback, asyncState);
            }

            public IAsyncResult BeginGetWebData(AsyncCallback callback, object asyncState)
            {
                object[] args = new object[0];
                return base.BeginInvoke("GetWebData", args, callback, asyncState);
            }

            public IAsyncResult BeginGetWebPredict(AsyncCallback callback, object asyncState)
            {
                object[] args = new object[0];
                return base.BeginInvoke("GetWebPredict", args, callback, asyncState);
            }

            public List<TB_Message> EndDayForecast(IAsyncResult result)
            {
                object[] args = new object[0];
                return (List<TB_Message>) base.EndInvoke("DayForecast", args, result);
            }

            public List<TB_Alert> EndGetAlert(IAsyncResult result)
            {
                object[] args = new object[0];
                return (List<TB_Alert>) base.EndInvoke("GetAlert", args, result);
            }

            public List<TB_RTC> EndGetRTC(IAsyncResult result)
            {
                object[] args = new object[0];
                return (List<TB_RTC>) base.EndInvoke("GetRTC", args, result);
            }

            public List<TB_RTC> EndGetRTC24h(IAsyncResult result)
            {
                object[] args = new object[0];
                return (List<TB_RTC>) base.EndInvoke("GetRTC24h", args, result);
            }

            public string EndGetWebAlert(IAsyncResult result)
            {
                object[] args = new object[0];
                return (string) base.EndInvoke("GetWebAlert", args, result);
            }

            public string EndGetWebCounts(IAsyncResult result)
            {
                object[] args = new object[0];
                return (string) base.EndInvoke("GetWebCounts", args, result);
            }

            public string EndGetWebData(IAsyncResult result)
            {
                object[] args = new object[0];
                return (string) base.EndInvoke("GetWebData", args, result);
            }

            public string EndGetWebPredict(IAsyncResult result)
            {
                object[] args = new object[0];
                return (string) base.EndInvoke("GetWebPredict", args, result);
            }
        }
    }
}

