using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Diagnostics;
using System.Text;

namespace Hospitality.Patient.API.PatientHostedService
{
    public class PatientHostedServicePublisher : IPatientHostedServicePublisher
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "ExaminationExchange", type: ExchangeType.Direct);

                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                channel.BasicPublish(exchange: "ExaminationExchange",
                               routingKey: "sentInfoForNotification",
                               basicProperties: null,
                               body: body);
                Debug.WriteLine($"PatientHostedServicePublisher: Send message to EmailService: {json}");
            }

        }
    }
}
