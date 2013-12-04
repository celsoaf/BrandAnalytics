using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitterSpy.Services;

namespace TwitterSpy.Activities
{
    public class TwitterStartActivity : CodeActivity
    {
        public InArgument<int> Token { get; set; }
        public InArgument<string> Topic { get; set; }
        
        protected override void Execute(CodeActivityContext context)
        {
            var topic = Topic.Get(context);
            var token = Token.Get(context);

            TwitterSyncService.Instance.StartStreaming(token, topic);
        }
    }
}