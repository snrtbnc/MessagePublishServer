using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MqttMessageService : IMessageService
    {
        public Task PublishtoAll(string message)
        {
            throw new NotImplementedException();
        }

        public Task PublishtoGroup(string groupId, string message)
        {
            throw new NotImplementedException();
        }

        public Task PublishtoPersonal(string personalId, string groupId, string message)
        {
            throw new NotImplementedException();
        }
    }
}
