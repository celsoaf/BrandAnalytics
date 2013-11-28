using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToTwitter;
using LitJson;
using TwitterSpy.Models;

namespace TwitterSpy.Services
{
    public class TwitterService : ITwitterService
    {
        static ITwitterAuthorizer GetSingleUserAuth()
        {
            var auth = new SingleUserAuthorizer
            {
                Credentials = new InMemoryCredentials
                {
                    ConsumerKey = "YHYvr8QdAj9DZuL4WzVmQ",
                    ConsumerSecret = "BgOgJMzAlH11qHlnp0d8Ypy8yFjPyauFQj3XLHVM",
                    OAuthToken = "76287578-lOpDa6rMN5weoQBHtxk1zxLahvSwF5br3VBKpeK7h",
                    AccessToken = "a6IZzJNcUPMdzDxPtamVWjOEdXNddvISaGuzLHYtANUpY"
                }
            };

            return auth;
        }

        private Streaming currentStreaming;
        private TopicModel model;

        public void StartStreaming(string topic)
        {
            model = new TopicModel() { Topic = topic };

            var auth = GetSingleUserAuth();
            auth.Authorize();
            var twitterCtx = new TwitterContext(auth);

            currentStreaming = twitterCtx.Streaming.Where(s => s.Type == StreamingType.Filter &&
                    s.Track == topic)
                .StreamingCallback(sc =>
                {
                    if (!string.IsNullOrEmpty(sc.Content))
                        Process(sc);
                })
                .SingleOrDefault();
        }

        private void Process(StreamContent sc)
        {
            var json = JsonMapper.ToObject(sc.Content);

            var status = new Status(json);

            model.Tweets++;

            if (!model.Authors.Contains(status.User.ID))
                model.Authors.Add(status.User.ID);

            var terms = status.Text.Split(' ', '\n', '\r', '.', ',');
            foreach (var item in terms)
            {
                var term = model.Terms.FirstOrDefault(t => t.Term == item);
                if (term == null)
                    model.Terms.Add(new TermModel { Term = item, Count = 1 });
                else
                    term.Count++;
            }
        }

        public TopicModel StopStreaming()
        {
            currentStreaming.CloseStream();

            return model;
        }
    }
}