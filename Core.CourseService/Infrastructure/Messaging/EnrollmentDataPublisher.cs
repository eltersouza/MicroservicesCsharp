using Aplication.Configurations;
using Aplication.DTOs;
using Aplication.Interfaces.Messaging;
using Confluent.Kafka;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Options;

namespace Core.CourseService.Infrastructure.Messaging
{
    public class EnrollmentDataPublisher : IEnrollmentDataPublisher
    {
        private readonly IValidator<Enrollment> _validator;
        private readonly KafkaConfiguration _kafkaConfiguration;

        public EnrollmentDataPublisher(IValidator<Enrollment> validator, IOptions<KafkaConfiguration> options)
        {
            _validator = validator;
            _kafkaConfiguration = options.Value;
        }

        public async Task<bool> PublishAsync(Enrollment enrollment)
        {
            bool result = false;

            ValidationResult validationResult = await _validator.ValidateAsync(enrollment);
            if (!validationResult.IsValid)
                return result;

            var config = new ProducerConfig
            {
                BootstrapServers = _kafkaConfiguration.BootstrapServers
            };

            using var producer = new ProducerBuilder<Null, string>(config).Build();

            var message = new Message<Null, string> { Value = enrollment.ToString()! };

            producer.Produce(_kafkaConfiguration.Topic, message, deliveryReport =>
            {
                Console.WriteLine(deliveryReport.Message.Value);
                result = !deliveryReport.Error.IsError;
            });
            producer.Flush();

            return result;
        }
    }
}
