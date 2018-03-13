using System;

namespace Test_006.Services
{
    public class MessageSender : IMessageSender
    {
        public string Send() => Environment.UserName;
    }
}