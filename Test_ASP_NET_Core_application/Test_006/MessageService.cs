using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_006.Services;

namespace Test_006
{
    public class MessageService
    {
        private readonly IMessageSender _sender;
        public MessageService(IMessageSender sender)
        {
            _sender = sender;
        }

        public string Send() => _sender.Send();
    }
}
