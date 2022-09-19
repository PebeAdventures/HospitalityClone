using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using System.Diagnostics;

namespace HostedService
{
    public class ExaminationConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private IExaminationPublisher _examinationPublisher;
        private string? _queueName;

        public ExaminationConsumer(IExaminationPublisher examinationPublisher)
        {
            _examinationPublisher = examinationPublisher;
            var factory = new ConnectionFactory { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "ExaminationExchange", type: ExchangeType.Direct);
            _queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _queueName, exchange: "ExaminationExchange", routingKey: "sentForExamination");
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                Debug.WriteLine($"HostedService: Received message from Examination.API: {content}");
                _examinationPublisher.SendMessage(content);
            };

            _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);
            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
