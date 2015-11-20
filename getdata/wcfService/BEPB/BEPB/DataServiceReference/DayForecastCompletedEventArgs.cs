namespace BEPB.DataServiceReference
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;

    [DebuggerStepThrough, GeneratedCode("System.ServiceModel", "4.0.0.0")]
    public class DayForecastCompletedEventArgs : AsyncCompletedEventArgs
    {
        private object[] results;

        public DayForecastCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
        {
            this.results = results;
        }

        public List<TB_Message> Result
        {
            get
            {
                base.RaiseExceptionIfNecessary();
                return (List<TB_Message>) this.results[0];
            }
        }
    }
}

