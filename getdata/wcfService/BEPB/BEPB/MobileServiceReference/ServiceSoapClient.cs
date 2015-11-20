namespace BEPB.MobileServiceReference
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Net;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Threading;

    [DebuggerStepThrough, GeneratedCode("System.ServiceModel", "4.0.0.0")]
    public class ServiceSoapClient : ClientBase<ServiceSoap>, ServiceSoap
    {
        private ClientBase<ServiceSoap>.BeginOperationDelegate onBeginCloseDelegate;
        private ClientBase<ServiceSoap>.BeginOperationDelegate onBeginGetAlertDelegate;
        private ClientBase<ServiceSoap>.BeginOperationDelegate onBeginGetDataDelegate;
        private ClientBase<ServiceSoap>.BeginOperationDelegate onBeginGetPredictDelegate;
        private ClientBase<ServiceSoap>.BeginOperationDelegate onBeginOpenDelegate;
        private SendOrPostCallback onCloseCompletedDelegate;
        private ClientBase<ServiceSoap>.EndOperationDelegate onEndCloseDelegate;
        private ClientBase<ServiceSoap>.EndOperationDelegate onEndGetAlertDelegate;
        private ClientBase<ServiceSoap>.EndOperationDelegate onEndGetDataDelegate;
        private ClientBase<ServiceSoap>.EndOperationDelegate onEndGetPredictDelegate;
        private ClientBase<ServiceSoap>.EndOperationDelegate onEndOpenDelegate;
        private SendOrPostCallback onGetAlertCompletedDelegate;
        private SendOrPostCallback onGetDataCompletedDelegate;
        private SendOrPostCallback onGetPredictCompletedDelegate;
        private SendOrPostCallback onOpenCompletedDelegate;

        public event EventHandler<AsyncCompletedEventArgs> CloseCompleted;

        public event EventHandler<GetAlertCompletedEventArgs> GetAlertCompleted;

        public event EventHandler<GetDataCompletedEventArgs> GetDataCompleted;

        public event EventHandler<GetPredictCompletedEventArgs> GetPredictCompleted;

        public event EventHandler<AsyncCompletedEventArgs> OpenCompleted;

        public ServiceSoapClient()
        {
        }

        public ServiceSoapClient(string endpointConfigurationName) : base(endpointConfigurationName)
        {
        }

        public ServiceSoapClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
        {
        }

        public ServiceSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
        {
        }

        public ServiceSoapClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        IAsyncResult ServiceSoap.BeginGetAlert(AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginGetAlert(callback, asyncState);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        IAsyncResult ServiceSoap.BeginGetData(AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginGetData(callback, asyncState);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        IAsyncResult ServiceSoap.BeginGetPredict(AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginGetPredict(callback, asyncState);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        string ServiceSoap.EndGetAlert(IAsyncResult result)
        {
            return base.Channel.EndGetAlert(result);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        string ServiceSoap.EndGetData(IAsyncResult result)
        {
            return base.Channel.EndGetData(result);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        string ServiceSoap.EndGetPredict(IAsyncResult result)
        {
            return base.Channel.EndGetPredict(result);
        }

        public void CloseAsync()
        {
            this.CloseAsync(null);
        }

        public void CloseAsync(object userState)
        {
            if (this.onBeginCloseDelegate == null)
            {
                this.onBeginCloseDelegate = new ClientBase<ServiceSoap>.BeginOperationDelegate(this.OnBeginClose);
            }
            if (this.onEndCloseDelegate == null)
            {
                this.onEndCloseDelegate = new ClientBase<ServiceSoap>.EndOperationDelegate(this.OnEndClose);
            }
            if (this.onCloseCompletedDelegate == null)
            {
                this.onCloseCompletedDelegate = new SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }

        protected override ServiceSoap CreateChannel()
        {
            return new ServiceSoapClientChannel(this);
        }

        public void GetAlertAsync()
        {
            this.GetAlertAsync(null);
        }

        public void GetAlertAsync(object userState)
        {
            if (this.onBeginGetAlertDelegate == null)
            {
                this.onBeginGetAlertDelegate = new ClientBase<ServiceSoap>.BeginOperationDelegate(this.OnBeginGetAlert);
            }
            if (this.onEndGetAlertDelegate == null)
            {
                this.onEndGetAlertDelegate = new ClientBase<ServiceSoap>.EndOperationDelegate(this.OnEndGetAlert);
            }
            if (this.onGetAlertCompletedDelegate == null)
            {
                this.onGetAlertCompletedDelegate = new SendOrPostCallback(this.OnGetAlertCompleted);
            }
            base.InvokeAsync(this.onBeginGetAlertDelegate, null, this.onEndGetAlertDelegate, this.onGetAlertCompletedDelegate, userState);
        }

        public void GetDataAsync()
        {
            this.GetDataAsync(null);
        }

        public void GetDataAsync(object userState)
        {
            if (this.onBeginGetDataDelegate == null)
            {
                this.onBeginGetDataDelegate = new ClientBase<ServiceSoap>.BeginOperationDelegate(this.OnBeginGetData);
            }
            if (this.onEndGetDataDelegate == null)
            {
                this.onEndGetDataDelegate = new ClientBase<ServiceSoap>.EndOperationDelegate(this.OnEndGetData);
            }
            if (this.onGetDataCompletedDelegate == null)
            {
                this.onGetDataCompletedDelegate = new SendOrPostCallback(this.OnGetDataCompleted);
            }
            base.InvokeAsync(this.onBeginGetDataDelegate, null, this.onEndGetDataDelegate, this.onGetDataCompletedDelegate, userState);
        }

        public void GetPredictAsync()
        {
            this.GetPredictAsync(null);
        }

        public void GetPredictAsync(object userState)
        {
            if (this.onBeginGetPredictDelegate == null)
            {
                this.onBeginGetPredictDelegate = new ClientBase<ServiceSoap>.BeginOperationDelegate(this.OnBeginGetPredict);
            }
            if (this.onEndGetPredictDelegate == null)
            {
                this.onEndGetPredictDelegate = new ClientBase<ServiceSoap>.EndOperationDelegate(this.OnEndGetPredict);
            }
            if (this.onGetPredictCompletedDelegate == null)
            {
                this.onGetPredictCompletedDelegate = new SendOrPostCallback(this.OnGetPredictCompleted);
            }
            base.InvokeAsync(this.onBeginGetPredictDelegate, null, this.onEndGetPredictDelegate, this.onGetPredictCompletedDelegate, userState);
        }

        private IAsyncResult OnBeginClose(object[] inValues, AsyncCallback callback, object asyncState)
        {
            return this.BeginClose(callback, asyncState);
        }

        private IAsyncResult OnBeginGetAlert(object[] inValues, AsyncCallback callback, object asyncState)
        {
            return ((ServiceSoap) this).BeginGetAlert(callback, asyncState);
        }

        private IAsyncResult OnBeginGetData(object[] inValues, AsyncCallback callback, object asyncState)
        {
            return ((ServiceSoap) this).BeginGetData(callback, asyncState);
        }

        private IAsyncResult OnBeginGetPredict(object[] inValues, AsyncCallback callback, object asyncState)
        {
            return ((ServiceSoap) this).BeginGetPredict(callback, asyncState);
        }

        private IAsyncResult OnBeginOpen(object[] inValues, AsyncCallback callback, object asyncState)
        {
            return this.BeginOpen(callback, asyncState);
        }

        private void OnCloseCompleted(object state)
        {
            if (this.CloseCompleted != null)
            {
                ClientBase<ServiceSoap>.InvokeAsyncCompletedEventArgs args = (ClientBase<ServiceSoap>.InvokeAsyncCompletedEventArgs) state;
                this.CloseCompleted(this, new AsyncCompletedEventArgs(args.Error, args.Cancelled, args.UserState));
            }
        }

        private object[] OnEndClose(IAsyncResult result)
        {
            this.EndClose(result);
            return null;
        }

        private object[] OnEndGetAlert(IAsyncResult result)
        {
            string str = ((ServiceSoap) this).EndGetAlert(result);
            return new object[] { str };
        }

        private object[] OnEndGetData(IAsyncResult result)
        {
            string str = ((ServiceSoap) this).EndGetData(result);
            return new object[] { str };
        }

        private object[] OnEndGetPredict(IAsyncResult result)
        {
            string str = ((ServiceSoap) this).EndGetPredict(result);
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
                ClientBase<ServiceSoap>.InvokeAsyncCompletedEventArgs args = (ClientBase<ServiceSoap>.InvokeAsyncCompletedEventArgs) state;
                this.GetAlertCompleted(this, new GetAlertCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnGetDataCompleted(object state)
        {
            if (this.GetDataCompleted != null)
            {
                ClientBase<ServiceSoap>.InvokeAsyncCompletedEventArgs args = (ClientBase<ServiceSoap>.InvokeAsyncCompletedEventArgs) state;
                this.GetDataCompleted(this, new GetDataCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnGetPredictCompleted(object state)
        {
            if (this.GetPredictCompleted != null)
            {
                ClientBase<ServiceSoap>.InvokeAsyncCompletedEventArgs args = (ClientBase<ServiceSoap>.InvokeAsyncCompletedEventArgs) state;
                this.GetPredictCompleted(this, new GetPredictCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnOpenCompleted(object state)
        {
            if (this.OpenCompleted != null)
            {
                ClientBase<ServiceSoap>.InvokeAsyncCompletedEventArgs args = (ClientBase<ServiceSoap>.InvokeAsyncCompletedEventArgs) state;
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
                this.onBeginOpenDelegate = new ClientBase<ServiceSoap>.BeginOperationDelegate(this.OnBeginOpen);
            }
            if (this.onEndOpenDelegate == null)
            {
                this.onEndOpenDelegate = new ClientBase<ServiceSoap>.EndOperationDelegate(this.OnEndOpen);
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

        private class ServiceSoapClientChannel : ClientBase<ServiceSoap>.ChannelBase<ServiceSoap>, ServiceSoap
        {
            public ServiceSoapClientChannel(ClientBase<ServiceSoap> client) : base(client)
            {
            }

            public IAsyncResult BeginGetAlert(AsyncCallback callback, object asyncState)
            {
                object[] args = new object[0];
                return base.BeginInvoke("GetAlert", args, callback, asyncState);
            }

            public IAsyncResult BeginGetData(AsyncCallback callback, object asyncState)
            {
                object[] args = new object[0];
                return base.BeginInvoke("GetData", args, callback, asyncState);
            }

            public IAsyncResult BeginGetPredict(AsyncCallback callback, object asyncState)
            {
                object[] args = new object[0];
                return base.BeginInvoke("GetPredict", args, callback, asyncState);
            }

            public string EndGetAlert(IAsyncResult result)
            {
                object[] args = new object[0];
                return (string) base.EndInvoke("GetAlert", args, result);
            }

            public string EndGetData(IAsyncResult result)
            {
                object[] args = new object[0];
                return (string) base.EndInvoke("GetData", args, result);
            }

            public string EndGetPredict(IAsyncResult result)
            {
                object[] args = new object[0];
                return (string) base.EndInvoke("GetPredict", args, result);
            }
        }
    }
}

