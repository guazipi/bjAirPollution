namespace BEPB.DataServiceReference
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;

    [DebuggerStepThrough, GeneratedCode("System.ServiceModel", "4.0.0.0")]
    public class GetRTC24hCompletedEventArgs : AsyncCompletedEventArgs
    {
        private object[] results;

        public GetRTC24hCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
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

