namespace BEPB.DataServiceReference
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;

    [GeneratedCode("System.ServiceModel", "4.0.0.0"), DebuggerStepThrough]
    public class GetAlertCompletedEventArgs : AsyncCompletedEventArgs
    {
        private object[] results;

        public GetAlertCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
        {
            this.results = results;
        }

        public List<TB_Alert> Result
        {
            get
            {
                base.RaiseExceptionIfNecessary();
                return (List<TB_Alert>) this.results[0];
            }
        }
    }
}

