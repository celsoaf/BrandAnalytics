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
        public InArgument<string[]> Topics { get; set; }
        public OutArgument<ITwitterService[]> Instances { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var topics = Topics.Get(context);

            var list = new List<ITwitterService>();

            foreach (var item in topics)
            {
                var service = new TwitterService();

                service.StartStreaming(item);

                list.Add(service);
            }

            Instances.Set(context, list.ToArray());
        }
    }
}