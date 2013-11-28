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
        public InArgument<string> Topic { get; set; }
        public OutArgument<ITwitterService> Instance { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var topic = Topic.Get(context);

            var service = new TwitterService();

            service.StartStreaming(topic);

            Instance.Set(context, service);
        }
    }
}