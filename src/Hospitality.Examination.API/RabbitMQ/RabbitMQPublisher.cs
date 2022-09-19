using RabbitMQ.Client;
using Newtonsoft.Json;
using System.Text;
using System.Diagnostics;

namespace Hospitality.Examination.API.RabbitMQ
{
    public class RabbitMQPublisher : IRabbitMqService
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
							   routingKey: "sentForExamination",
							   basicProperties: null,
							   body: body);
				Debug.WriteLine($"ExaminationAPI:  Send message to HostedService: {json}");
			}
		}
	}
}
