using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitterSpy.Models;
using TwitterSpy.Services;

namespace TwitterSpy.Activities
{
    public class TwitterCancelActivity : CodeActivity
    {
        public InArgument<int> Token { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var token = Token.Get(context);
            
            TwitterSyncService.Instance.CancelStreaming(token);
        }
    }
}