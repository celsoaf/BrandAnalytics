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
        private static TwitterSyncService _instance;
        private static object _locker = new object();

        private TwitterSyncService()
        {

        }

        public static TwitterSyncService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        if (_instance == null)
                            _instance = new TwitterSyncService();
                    }
                }
                return _instance;
            }
        }

        private AutoResetEvent _autoResetEvent = new AutoResetEvent(true);
        private int? _runningToken;
        private List<int> _pending = new List<int>();
        private ITwitterService _service;

        public void StartStreaming(int token, string topic)
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

                _service = new TwitterService();
                _service.StartStreaming(topic);
            }

            Monitor.Exit(_locker);
        }

        public TopicModel StopStreaming(int token)
        {
            return StopService(token);
        }

        public void CancelStreaming(int token)
        {
            StopService(token);
        }

        private TopicModel StopService(int token)
        {
            Monitor.Enter(_locker);

            if (_runningToken == token)
            {
                var tm = _service.StopStreaming();
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