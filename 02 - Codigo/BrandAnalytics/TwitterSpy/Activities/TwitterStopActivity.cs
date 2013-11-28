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
        public InArgument<ITwitterService> Instance { get; set; }
        public OutArgument<TopicModel> Topic { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var instance = Instance.Get(context);

            var topic = instance.StopStreaming();

            Topic.Set(context, topic);
        }
    }
}