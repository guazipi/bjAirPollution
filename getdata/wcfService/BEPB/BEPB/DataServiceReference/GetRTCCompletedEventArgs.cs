namespace BEPB.DataServiceReference
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;

    [GeneratedCode("System.ServiceModel", "4.0.0.0"), DebuggerStepThrough]
    public class GetRTCCompletedEventArgs : AsyncCompletedEventArgs
    {
        private object[] results;

        public GetRTCCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
        {
            this.results = results;
        }

        public List<TB_RTC> Result
        {
            get
            {
                base.RaiseExceptionIfNecessary();
                return (List<TB_RTC>) this.results[0];
            }
        }
    }
}

