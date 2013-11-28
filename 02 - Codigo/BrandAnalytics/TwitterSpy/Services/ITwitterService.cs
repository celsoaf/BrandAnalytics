using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterSpy.Models;

namespace TwitterSpy.Services
{
    public interface ITwitterService
    {
        void StartStreaming(string topic);
        TopicModel StopStreaming();
    }
}
