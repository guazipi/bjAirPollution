namespace BEPB.MobileServiceReference
{
    using System;
    using System.CodeDom.Compiler;
    using System.ServiceModel;

    [GeneratedCode("System.ServiceModel", "4.0.0.0"), ServiceContract(ConfigurationName="MobileServiceReference.ServiceSoap")]
    public interface ServiceSoap
    {
        [OperationContract(AsyncPattern=true, Action="http://tempuri.org/GetAlert", ReplyAction="*"), XmlSerializerFormat(SupportFaults=true)]
        IAsyncResult BeginGetAlert(AsyncCallback callback, object asyncState);
        [XmlSerializerFormat(SupportFaults=true), OperationContract(AsyncPattern=true, Action="http://tempuri.org/GetData", ReplyAction="*")]
        IAsyncResult BeginGetData(AsyncCallback callback, object asyncState);
        [OperationContract(AsyncPattern=true, Action="http://tempuri.org/GetPredict", ReplyAction="*"), XmlSerializerFormat(SupportFaults=true)]
        IAsyncResult BeginGetPredict(AsyncCallback callback, object asyncState);
        string EndGetAlert(IAsyncResult result);
        string EndGetData(IAsyncResult result);
        string EndGetPredict(IAsyncResult result);
    }
}

