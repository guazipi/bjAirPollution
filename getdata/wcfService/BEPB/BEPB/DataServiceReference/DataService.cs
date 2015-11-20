namespace BEPB.DataServiceReference
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.ServiceModel;

    [ServiceContract(Namespace="", ConfigurationName="DataServiceReference.DataService"), GeneratedCode("System.ServiceModel", "4.0.0.0")]
    public interface DataService
    {
        [OperationContract(AsyncPattern=true, Action="urn:DataService/DayForecast", ReplyAction="urn:DataService/DayForecastResponse")]
        IAsyncResult BeginDayForecast(AsyncCallback callback, object asyncState);
        [OperationContract(AsyncPattern=true, Action="urn:DataService/GetAlert", ReplyAction="urn:DataService/GetAlertResponse")]
        IAsyncResult BeginGetAlert(AsyncCallback callback, object asyncState);
        [OperationContract(AsyncPattern=true, Action="urn:DataService/GetRTC", ReplyAction="urn:DataService/GetRTCResponse")]
        IAsyncResult BeginGetRTC(AsyncCallback callback, object asyncState);
        [OperationContract(AsyncPattern=true, Action="urn:DataService/GetRTC24h", ReplyAction="urn:DataService/GetRTC24hResponse")]
        IAsyncResult BeginGetRTC24h(string Station, string Pollutant, AsyncCallback callback, object asyncState);
        [OperationContract(AsyncPattern=true, Action="urn:DataService/GetWebAlert", ReplyAction="urn:DataService/GetWebAlertResponse")]
        IAsyncResult BeginGetWebAlert(AsyncCallback callback, object asyncState);
        [OperationContract(AsyncPattern=true, Action="urn:DataService/GetWebCounts", ReplyAction="urn:DataService/GetWebCountsResponse")]
        IAsyncResult BeginGetWebCounts(AsyncCallback callback, object asyncState);
        [OperationContract(AsyncPattern=true, Action="urn:DataService/GetWebData", ReplyAction="urn:DataService/GetWebDataResponse")]
        IAsyncResult BeginGetWebData(AsyncCallback callback, object asyncState);
        [OperationContract(AsyncPattern=true, Action="urn:DataService/GetWebPredict", ReplyAction="urn:DataService/GetWebPredictResponse")]
        IAsyncResult BeginGetWebPredict(AsyncCallback callback, object asyncState);
        List<TB_Message> EndDayForecast(IAsyncResult result);
        List<TB_Alert> EndGetAlert(IAsyncResult result);
        List<TB_RTC> EndGetRTC(IAsyncResult result);
        List<TB_RTC> EndGetRTC24h(IAsyncResult result);
        string EndGetWebAlert(IAsyncResult result);
        string EndGetWebCounts(IAsyncResult result);
        string EndGetWebData(IAsyncResult result);
        string EndGetWebPredict(IAsyncResult result);
    }
}

