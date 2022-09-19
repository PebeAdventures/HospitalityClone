namespace Hospitality.Examination.API.RabbitMQ
{
        public interface IRabbitMqService
        {
            void SendMessage<T>(T message);
        }
}
