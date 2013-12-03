using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitterSpy.Models;
using TwitterSpy.Services;

namespace TwitterSpy.Activities
{
    public class TwitterStopActivity : CodeActivity
    {
        public InArgument<int> Token { get; set; }
        public OutArgument<TopicModel> Topic { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var token = Token.Get(context);
            var topic = TwitterSyncService.StopStreaming(token);

            Topic.Set(context, topic);
        }
    }
}