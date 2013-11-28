﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BrandAnalytics.Web.BrandAnaliticsInternal {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BrandAnaliticsInternal.IBrandAnalyticsClientService")]
    public interface IBrandAnalyticsClientService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrandAnalyticsClientService/GetState", ReplyAction="http://tempuri.org/IBrandAnalyticsClientService/GetStateResponse")]
        string GetState(int token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrandAnalyticsClientService/GetState", ReplyAction="http://tempuri.org/IBrandAnalyticsClientService/GetStateResponse")]
        System.Threading.Tasks.Task<string> GetStateAsync(int token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrandAnalyticsClientService/RequestStudy", ReplyAction="http://tempuri.org/IBrandAnalyticsClientService/RequestStudyResponse")]
        int RequestStudy(string userName, string mark);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrandAnalyticsClientService/RequestStudy", ReplyAction="http://tempuri.org/IBrandAnalyticsClientService/RequestStudyResponse")]
        System.Threading.Tasks.Task<int> RequestStudyAsync(string userName, string mark);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrandAnalyticsClientService/CancelStudy", ReplyAction="http://tempuri.org/IBrandAnalyticsClientService/CancelStudyResponse")]
        void CancelStudy(int token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrandAnalyticsClientService/CancelStudy", ReplyAction="http://tempuri.org/IBrandAnalyticsClientService/CancelStudyResponse")]
        System.Threading.Tasks.Task CancelStudyAsync(int token);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBrandAnalyticsClientServiceChannel : BrandAnalytics.Web.BrandAnaliticsInternal.IBrandAnalyticsClientService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BrandAnalyticsClientServiceClient : System.ServiceModel.ClientBase<BrandAnalytics.Web.BrandAnaliticsInternal.IBrandAnalyticsClientService>, BrandAnalytics.Web.BrandAnaliticsInternal.IBrandAnalyticsClientService {
        
        public BrandAnalyticsClientServiceClient() {
        }
        
        public BrandAnalyticsClientServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BrandAnalyticsClientServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BrandAnalyticsClientServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BrandAnalyticsClientServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetState(int token) {
            return base.Channel.GetState(token);
        }
        
        public System.Threading.Tasks.Task<string> GetStateAsync(int token) {
            return base.Channel.GetStateAsync(token);
        }
        
        public int RequestStudy(string userName, string mark) {
            return base.Channel.RequestStudy(userName, mark);
        }
        
        public System.Threading.Tasks.Task<int> RequestStudyAsync(string userName, string mark) {
            return base.Channel.RequestStudyAsync(userName, mark);
        }
        
        public void CancelStudy(int token) {
            base.Channel.CancelStudy(token);
        }
        
        public System.Threading.Tasks.Task CancelStudyAsync(int token) {
            return base.Channel.CancelStudyAsync(token);
        }
    }
}