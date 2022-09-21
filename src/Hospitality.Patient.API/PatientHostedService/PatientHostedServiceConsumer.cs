using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Diagnostics;
using System.Text;
using Hospitality.Common.DTO.Examination;
using Newtonsoft.Json;

namespace Hospitality.Patient.API.PatientHostedService
{
    public class PatientHostedServiceConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private string? _queueName;
        private IPatientService _patientService;
        private IPatientHostedServicePublisher _publisherService;

        public PatientHostedServiceConsumer(IPatientService patientService, IPatientHostedServicePublisher publisherService)
        {
            _patientService = patientService;
            _publisherService = publisherService;
            var factory = new ConnectionFactory { HostName = "localhost" };
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
                Debug.WriteLine($"PatientHostedServiceConsumer: Received message from HostedService: {content}");

                PatientNotificationDTO patientInfoForNotification = await preparePatientInfoForNotification(content);
                _publisherService.SendMessage(patientInfoForNotification);

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

        private async Task<PatientNotificationDTO> preparePatientInfoForNotification(string context)
        {
            ExaminationExecutionDto examinationExecution = JsonConvert.DeserializeObject<ExaminationExecutionDto>(context);

            PatientNotificationDTO patientInfoForNotification = await _patientService.GetPatientByIDAsync(examinationExecution.PatientId);
            patientInfoForNotification.Status = examinationExecution.Status;
            patientInfoForNotification.ExaminationDescription = examinationExecution.Description;
            return patientInfoForNotification;
        }
    }
}
