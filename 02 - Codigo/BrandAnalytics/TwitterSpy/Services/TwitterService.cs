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

        private TwitterContext twitterCtx;
        private Streaming currentStreaming;
        private TopicModel model;

        public void StartStreaming(string topic)
        {
            model = new TopicModel() { Topic = topic };

            var auth = GetSingleUserAuth();
            auth.Authorize();
            twitterCtx = new TwitterContext(auth);

            currentStreaming = twitterCtx.Streaming.Where(s => s.Type == StreamingType.Filter &&
                    s.Track == topic /* && s.Language == "pt" */)
                .StreamingCallback(sc =>
                {
                    if (!string.IsNullOrEmpty(sc.Content))
                        Process(sc);
                })
                .SingleOrDefault();
        }

        private object locker = new object();
        private void Process(StreamContent sc)
        {
            if (sc.Error != null)
                return;

            var json = JsonMapper.ToObject(sc.Content);

            var status = new Status(json);

            if (!string.IsNullOrEmpty(status.Text))
            {
                lock (locker)
                {
                    model.Tweets++;

                    if (!model.Authors.Contains(status.User.Name))
                        model.Authors.Add(status.User.Name);

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
            }
        }

        public TopicModel StopStreaming()
        {
            if (currentStreaming != null)
                currentStreaming.CloseStream();
            twitterCtx.Dispose();

            return model;
        }
    }
}