﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.Hosting;
using Hospitality.Examination.Application.Services;
using Microsoft.Extensions.Configuration;

namespace Hospitality.Examination.RabbitMQ
{
    public class RabbitMQConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private string? _queueName;
        private string? _hostName;
        private IUpdateExamination _updateExamination;
        private readonly IConfiguration _configuration;

        public RabbitMQConsumer(IUpdateExamination updateExamination, IConfiguration configuration)
        {
            _updateExamination = updateExamination;
            _configuration = configuration;
            _hostName = _configuration.GetValue<string>("EXAMINATION_RABBITMQ_URL");
            var factory = new ConnectionFactory { HostName = _hostName };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "ExaminationExchange", type: ExchangeType.Direct);
            _queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _queueName, exchange: "ExaminationExchange", routingKey: "sentAfterExaminationFinished");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                Debug.WriteLine($"Examination.API: Received message from HostedService: {content}");
                await _updateExamination.updateExaminationData(content);
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