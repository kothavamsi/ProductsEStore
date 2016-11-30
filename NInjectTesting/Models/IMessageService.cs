using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NInjectTesting.Models
{
    public interface IMessageService
    {
         string GetHelloMessage();
    }

    public class WebMessageService : IMessageService
    {
        public string GetHelloMessage()
        {
            return "Hello from Google.com";
        }
    }

    public class DBMessageService : IMessageService
    {

        public string GetHelloMessage()
        {
            return "Hello from Sql Server";
        }
    }
}