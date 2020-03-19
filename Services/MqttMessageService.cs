using Interfaces;
using MQTTnet;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MqttMessageService : IMessageService
    {

        IMqttServer mqttServer;
        public MqttMessageService(IMqttServer mqttServer)
        {
            this.mqttServer = mqttServer;
        }


        public async Task PublishtoAll(string message)
        {
          var result = new MqttApplicationMessageBuilder()
                                 .WithTopic($"app/all")
                                 .WithPayload(message)
                                 .WithAtLeastOnceQoS()
                                 .WithRetainFlag(false)
                                 .Build();

            await mqttServer.PublishAsync(result);
        }

        public async Task PublishtoGroup(string groupId, string message)
        {
            var result = new MqttApplicationMessageBuilder()
                                 .WithTopic($"app/{groupId}")
                                 .WithPayload(message)
                                 .WithAtLeastOnceQoS()
                                 .WithRetainFlag(false)
                                 .Build();

            await mqttServer.PublishAsync(result);
        }

        public Task PublishtoPersonal(string personalId, string groupId, string message)
        {
            throw new NotImplementedException();
        }
        //public static void MqttServer_ClientConnected(object sender, MqttClientConnectedEventArgs e)
        //{
        //    Console.WriteLine("client geldi");
        //}
    }

   
}
