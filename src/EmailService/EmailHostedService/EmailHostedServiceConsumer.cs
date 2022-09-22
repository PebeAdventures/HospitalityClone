using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Diagnostics;
using System.Text;
using Hospitality.Common.DTO.Patient;
using Newtonsoft.Json;

namespace EmailService.EmailHostedService
{
    public class EmailHostedServiceConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private string? _queueName;
        private IEmailSender _emailSender;


        public EmailHostedServiceConsumer(IEmailSender emailSender)
        {
            _emailSender = emailSender;

            var factory = new ConnectionFactory { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "ExaminationExchange", type: ExchangeType.Direct);
            _queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _queueName, exchange: "ExaminationExchange", routingKey: "sentInfoForNotification");
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                Debug.WriteLine($"EmailHostedServiceConsumer: Received message from PatientHostedServicePublisher: {content}");

                PatientNotificationDTO examinationExecutionDto = JsonConvert.DeserializeObject<PatientNotificationDTO>(content);

                string messageText = "";
                if (examinationExecutionDto.ExaminationDescription == "")
                {
                     messageText = $"Hello, {examinationExecutionDto.PatientName} {examinationExecutionDto.PatientSurname}! \n" +
                                         $"Your examination \"{examinationExecutionDto.ExaminationTypeName}\" was finished. You could check result in your account. \n" +
                                         $"Kind regards,\nHospitality";
                } else
                {
                     messageText = $"Hello, {examinationExecutionDto.PatientName} {examinationExecutionDto.PatientSurname}! \n" +
                                         $"Your examination \"{examinationExecutionDto.ExaminationTypeName}\" was finished.\nResults\n{examinationExecutionDto.ExaminationDescription}\n" +
                                         $"Kind regards,\nHospitality";
                }
                var message = new Message(new string[] { examinationExecutionDto.Email }, "Client message", messageText);

                _emailSender.SendEmail(message);
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
