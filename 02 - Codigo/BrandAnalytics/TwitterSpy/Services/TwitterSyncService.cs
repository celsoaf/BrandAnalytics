using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using TwitterSpy.Models;

namespace TwitterSpy.Services
{
    public class TwitterSyncService
    {
        private static AutoResetEvent _autoResetEvent = new AutoResetEvent(true);
        private static int? _runningToken;
        private static List<int> _pending = new List<int>();
        private static object _locker = new object();
        private static ITwitterService _instance;

        public static void StartStreaming(int token, string topic)
        {
            Monitor.Enter(_locker);

            _pending.Add(token);
            while (_runningToken != null && _pending.Contains(token))
            {
                Monitor.Exit(_locker);
                _autoResetEvent.WaitOne();
                Monitor.Enter(_locker);
            }

            if (_pending.Contains(token))
            {
                _runningToken = token;
                _pending.Remove(token);

                _instance = new TwitterService();
                _instance.StartStreaming(topic);
            }

            Monitor.Exit(_locker);
        }

        public static TopicModel StopStreaming(int token)
        {
            return StopService(token);
        }

        public static void CancelStreaming(int token)
        {
            StopService(token);
        }

        private static TopicModel StopService(int token)
        {
            Monitor.Enter(_locker);

            if (_runningToken == token)
            {
                var tm = _instance.StopStreaming();
                _runningToken = null;
                Monitor.Exit(_locker);
                _autoResetEvent.Set();

                return tm;
            }
            else if (_pending.Contains(token))
                _pending.Remove(token);

            Monitor.Exit(_locker);

            return null;
        }
    }
}