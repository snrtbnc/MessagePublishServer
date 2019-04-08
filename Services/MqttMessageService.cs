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
        public MqttMessageService()
        {
            var optionsBuilder = new MqttServerOptionsBuilder()
    .WithConnectionBacklog(100);
    //.WithDefaultEndpointPort(1883);

            mqttServer = new MqttFactory().CreateMqttServer();
            mqttServer.ClientConnected += MqttServer_ClientConnected;
            mqttServer.StartAsync(optionsBuilder.Build());
        }


        public async Task PublishtoAll(string message)
        {
            var result = new MqttApplicationMessageBuilder()
                                   .WithTopic("app/osmanbar")
                                   .WithPayload(message)
                                   .WithAtLeastOnceQoS()
                                   .WithRetainFlag()
                                   .Build();

            await mqttServer.PublishAsync(result);
        }

        public Task PublishtoGroup(string groupId, string message)
        {
            throw new NotImplementedException();
        }

        public Task PublishtoPersonal(string personalId, string groupId, string message)
        {
            throw new NotImplementedException();
        }
        private static void MqttServer_ClientConnected(object sender, MqttClientConnectedEventArgs e)
        {
            Console.WriteLine("client geldi");
        }
    }

   
}
