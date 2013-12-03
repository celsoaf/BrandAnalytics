﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BrandAnalytics.Web.BrandAnalyticsClient {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BrandAnalyticsClient.IBrandAnalyticsService")]
    public interface IBrandAnalyticsService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrandAnalyticsService/CancelStudy", ReplyAction="http://tempuri.org/IBrandAnalyticsService/CancelStudyResponse")]
        void CancelStudy(int token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrandAnalyticsService/CancelStudy", ReplyAction="http://tempuri.org/IBrandAnalyticsService/CancelStudyResponse")]
        System.Threading.Tasks.Task CancelStudyAsync(int token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrandAnalyticsService/GetState", ReplyAction="http://tempuri.org/IBrandAnalyticsService/GetStateResponse")]
        string GetState(int token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrandAnalyticsService/GetState", ReplyAction="http://tempuri.org/IBrandAnalyticsService/GetStateResponse")]
        System.Threading.Tasks.Task<string> GetStateAsync(int token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrandAnalyticsService/RequestStudy", ReplyAction="http://tempuri.org/IBrandAnalyticsService/RequestStudyResponse")]
        int RequestStudy(string userName, string mark);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrandAnalyticsService/RequestStudy", ReplyAction="http://tempuri.org/IBrandAnalyticsService/RequestStudyResponse")]
        System.Threading.Tasks.Task<int> RequestStudyAsync(string userName, string mark);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrandAnalyticsService/SpyTopics", ReplyAction="http://tempuri.org/IBrandAnalyticsService/SpyTopicsResponse")]
        void SpyTopics(int token, string userName, string topics, int seconds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrandAnalyticsService/SpyTopics", ReplyAction="http://tempuri.org/IBrandAnalyticsService/SpyTopicsResponse")]
        System.Threading.Tasks.Task SpyTopicsAsync(int token, string userName, string topics, int seconds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrandAnalyticsService/RepeatSpyTopics", ReplyAction="http://tempuri.org/IBrandAnalyticsService/RepeatSpyTopicsResponse")]
        void RepeatSpyTopics(int token, string userName, string topics, int seconds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrandAnalyticsService/RepeatSpyTopics", ReplyAction="http://tempuri.org/IBrandAnalyticsService/RepeatSpyTopicsResponse")]
        System.Threading.Tasks.Task RepeatSpyTopicsAsync(int token, string userName, string topics, int seconds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrandAnalyticsService/Finalize", ReplyAction="http://tempuri.org/IBrandAnalyticsService/FinalizeResponse")]
        void Finalize(int token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrandAnalyticsService/Finalize", ReplyAction="http://tempuri.org/IBrandAnalyticsService/FinalizeResponse")]
        System.Threading.Tasks.Task FinalizeAsync(int token);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBrandAnalyticsServiceChannel : BrandAnalytics.Web.BrandAnalyticsClient.IBrandAnalyticsService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BrandAnalyticsServiceClient : System.ServiceModel.ClientBase<BrandAnalytics.Web.BrandAnalyticsClient.IBrandAnalyticsService>, BrandAnalytics.Web.BrandAnalyticsClient.IBrandAnalyticsService {
        
        public BrandAnalyticsServiceClient() {
        }
        
        public BrandAnalyticsServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BrandAnalyticsServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BrandAnalyticsServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BrandAnalyticsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void CancelStudy(int token) {
            base.Channel.CancelStudy(token);
        }
        
        public System.Threading.Tasks.Task CancelStudyAsync(int token) {
            return base.Channel.CancelStudyAsync(token);
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
        
        public void SpyTopics(int token, string userName, string topics, int seconds) {
            base.Channel.SpyTopics(token, userName, topics, seconds);
        }
        
        public System.Threading.Tasks.Task SpyTopicsAsync(int token, string userName, string topics, int seconds) {
            return base.Channel.SpyTopicsAsync(token, userName, topics, seconds);
        }
        
        public void RepeatSpyTopics(int token, string userName, string topics, int seconds) {
            base.Channel.RepeatSpyTopics(token, userName, topics, seconds);
        }
        
        public System.Threading.Tasks.Task RepeatSpyTopicsAsync(int token, string userName, string topics, int seconds) {
            return base.Channel.RepeatSpyTopicsAsync(token, userName, topics, seconds);
        }
        
        public void Finalize(int token) {
            base.Channel.Finalize(token);
        }
        
        public System.Threading.Tasks.Task FinalizeAsync(int token) {
            return base.Channel.FinalizeAsync(token);
        }
    }
}
